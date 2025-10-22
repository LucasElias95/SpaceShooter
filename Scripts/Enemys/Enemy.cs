using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.MustacheGameStudioTV.SpawnPoints;

public class Enemy : InimigoBase
{
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody;
    public ParticleSystem explosionParticlePrefab;

    private int life;
    private EnemyProperties enemyProperties;

    private MovementControll movementControll;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 currentPosition = this.transform.position;
        float halfWidth = Width / 2f;
        float leftReferencePoint = currentPosition.x - halfWidth;
        float rightReferencePoint = currentPosition.x + halfWidth;

        Camera camera = Camera.main;
        Vector2 lowerLeftLimit = camera.ViewportToWorldPoint(Vector2.zero);
        Vector2 upperRightLimit = camera.ViewportToWorldPoint(Vector2.one);

        if (leftReferencePoint < lowerLeftLimit.x)//inimigo saiu pela esquerda
        {
            float positionX = lowerLeftLimit.x + halfWidth;
            this.transform.position = new Vector2(positionX, currentPosition.y);
        }
        else if (rightReferencePoint > upperRightLimit.x) //se saiu pelo lado direito da tela
        {
            float positionX = upperRightLimit.x - halfWidth;
            this.transform.position = new Vector2(positionX, currentPosition.y);
        }

        
    }
    //ViewPort é a área que determina a borda da camera
    // Update is called once per frame
    void Update()
    {
        this.movementControll.Atualizar();
        this.rigidbody.linearVelocity = this.movementControll.CalculateCurrentVelocity();
        
        Camera camera = Camera.main;
        Vector3 cameraPosition = camera.WorldToViewportPoint(this.transform.position); //transforma a posição do enimigo na posição limite da camera
        if (cameraPosition.y <0)
        {
            //se a posição da camera for menor que 0 o inimigo saiu da area da camera
            PlayerShip player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShip>();
            player.Lifes--; // diminui uma vida do jogador quando o inimigo não é destruido
            Killed(false); //destroi o inimigo, mas não conta ponto
        }
    }

    public void Config(EnemyProperties enemyProperties)
    {
        this.enemyProperties = enemyProperties;
        this.life = this.enemyProperties.MaxLife;
        this.movementControll = new MovementControll(this.enemyProperties._BaseMovement);
    }

    private float Width
    {
        get
        {
            Bounds bounds = this.spriteRenderer.bounds;
            Vector3 spriteSize = bounds.size;
            return spriteSize.x;
        }
    }

    public void Damage()
    {
        this.life--;
        if (this.life <=0)
        {
            Killed(true); //true define que conta pontos ao jogador
        }
    }

    private void Killed(bool defeated) // só será contado a pontuação qunado defeated receber true 
    {
        Destruir();
        if (defeated)
        {
            ScoreController.Score++;
        }

        AudioControll audioControll = GameObject.FindObjectOfType<AudioControll>();
        audioControll.PlayEnemyExplosiondAudio();

        ParticleSystem explosionParticle = Instantiate(this.explosionParticlePrefab, this.transform.position, Quaternion.identity);
        Destroy(explosionParticle.gameObject, 1f); //destroi a particula depois de 1 segundo    
        Destroy(this.gameObject);
    }
}
