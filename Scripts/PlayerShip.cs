using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShip : MonoBehaviour
{
    [SerializeField]
    private bool mouseMovementPrefs;

    public Rigidbody2D rigibody;

    public float velocity;
    private const int maxLife = 5;
    private int lifes;

    [SerializeField]
    private WeaponControll weaponControll;

    public SpriteRenderer spriteRenderer;

    [SerializeField]
    private Shield shield;

    private EffectPowerUp currentPowerUp;

    private GameOver gameOverScreen; 
    private AudioControll audioControll;

    private IPlayerMovement playerMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.audioControll = GameObject.FindObjectOfType<AudioControll>();
        this.lifes = maxLife;
        ScoreController.Score = 0;

        GameObject gameOverObject = GameObject.FindGameObjectWithTag("GameOver");
        this.gameOverScreen = gameOverObject.GetComponent<GameOver>();
        this.gameOverScreen.Hide();

        //EquipWeaponsSpread();
        EquipWeaponsAlternate();
        //EquipWeaponsDouble();
        this.shield.Disable();

        #if Unity_ANDROID
        //executado dentro do android
        this.playerMovement = new PointAndClickMovement();

        #else
        // executado em outra plataforma
        if (this.mouseMovementPrefs)
        {
            this.playerMovement = new MouseMovement();
        }
        else
        {
             this.playerMovement = new KeyboardMovement();
        }
        
        #endif

       
        this.playerMovement.Config(this.rigibody, this.transform, this.velocity);
    }

    // Update is called once per frame
    void Update()
    {
        this.playerMovement.Atualizar();

        LimitScreen();

        if (this.currentPowerUp != null) //se powerUp atual diferente de null, recebe um powerUp
        {
            this.currentPowerUp.Upadate_(); //Atualiza o valor de tempo restante do uso do powerUp
            if (!this.currentPowerUp.Active) //Quando o tempo de uso acaba ele deixa de ser ativo então chama esse if
            {
                this.currentPowerUp.Remove(this); //remove o powerUp
                this.currentPowerUp = null; //passa o valor de null ao powerUp atual, para poder receber um powerUp em outro momento
            }
        }
    }

    public void EquipWeaponsAlternate()
    {
        this.weaponControll.EquipAlternate();
    }

        public void EquipWeaponsDouble()
    {
        this.weaponControll.EquipDouble();
    }

    public void EquipWeaponsSpread()
    {
        this.weaponControll.EquipSpread();
    }

    public void ActiveShield()
    {
        this.shield.Enable();
    }

    public void RemoveShield()
    {
        this.shield.Disable();
    }

    private void LimitScreen()
    {
        Vector2 currentPosition = this.transform.position;

        float halfWidth = Width / 2f;
        float halfHeight = Height / 2f;

        Camera camera = Camera.main;
        Vector2 lowerLeftLimit = camera.ViewportToWorldPoint(Vector2.zero); //(0, 0)
        Vector2 upperRightLimit = camera.ViewportToWorldPoint(Vector2.one); //(1, 1)

        float leftReferencePoint = currentPosition.x - halfWidth;
        float rightReferencePoint = currentPosition.x + halfHeight;

        if (leftReferencePoint < lowerLeftLimit.x) //saindo pela esquerda
        {
            this.transform.position = new Vector2(lowerLeftLimit.x + halfWidth, currentPosition.y); //pega o limite minimo de x reposiciona a posição do sprite
        }
        else if (rightReferencePoint > upperRightLimit.x) //saindo pela direita
        {
            this.transform.position = new Vector2(upperRightLimit.x - halfWidth, currentPosition.y); // trás a nava para a esquerda (qunado passa do limite positivo em x ele calcula o valor maximo de x - a metade da largura do sprite)
        }

        currentPosition = this.transform.position; //atualiza a posição atual do jogador, para poder fazer uma nova validação (evita erro ao se mover em duas direções ao mesmo tempo)

        float upperReferencePoint = currentPosition.y + halfHeight;
        float lowerReferencePoint = currentPosition.y - halfHeight;

        if (upperReferencePoint > upperRightLimit.y)
        {
            this.transform.position = new Vector2(currentPosition.x, upperRightLimit.y - halfHeight);//desce a nave (limite superior - metado do valor da altura total do sprite)
        }
        else if (lowerReferencePoint < lowerLeftLimit.y)
        {
            this.transform.position = new Vector2(currentPosition.x, lowerLeftLimit.y + halfHeight); //sobe a nave (limite inferior + metado do valor da altura total do sprite)
        }

     
    
    }

    private float Width
    {
        get
        {
            Bounds bounds = this.spriteRenderer.bounds; //acessa os limites do sprite
            Vector3 spriteSize = bounds.size; //busca o valor do tamanho dele
            return spriteSize.x; //retur + eixo x é utilizado para retornar o tamanho da largura
        }
    }

    private float Height
    {
        get
        {
            Bounds bounds = this.spriteRenderer.bounds;
            Vector3 spriteSize = bounds.size;
            return spriteSize.y; //retorna a altura
        }
    }

    //Se um objeto com collider com a tag Enemy enconstar no collider do Player uma vida é retirada
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            Enemy enemy = collider.GetComponent<Enemy>(); //busco o objeto com o script Enemy
            ColliderEnemy(enemy);
        }

        else if (collider.CompareTag("Meteor"))
        {
            Meteor meteor = collider.GetComponent<Meteor>(); //busco o objeto com o script Meteor
            ColliderMeteor(meteor);   
        }

        else if (collider.CompareTag("LifeItem"))
        {
            LifeItem lifeItem = collider.GetComponent<LifeItem>();
            CollectedLifeItem(lifeItem);

        }
        else if (collider.CompareTag("PowerUp"))
        {
            PowerUpCollectible powerUp = collider.GetComponent<PowerUpCollectible>();
            CollectedPowerUp(powerUp);
        }
    }

    private void ColliderEnemy(Enemy enemy)
    {   
        if (this.shield.Active)
        {   audioControll.PlayDamageShieldAudio();
            this.shield.Damaged();
        }
        else
        {   audioControll.PlayDamagePlayerdAudio();
            Lifes--;
        }
            enemy.Damage();  
    }

    private void ColliderMeteor(Meteor meteor)
    {
        if (this.shield.Active)
        {   audioControll.PlayDamageShieldAudio();
            this.shield.Damaged();
        }
        else
        {
            audioControll.PlayDamagePlayerdAudio();
            Lifes--;
        }    
        meteor.Killed(false); 
    }

    private void CollectedLifeItem(LifeItem lifeItem)
    {
        Lifes += lifeItem.LifeRecharge;
        lifeItem.Collected();
    }

    private void CollectedPowerUp(PowerUpCollectible powerUp)
    {
        if (this.currentPowerUp != null)
        {
            this.currentPowerUp.Remove(this);
        }

        EffectPowerUp effectPowerUp = powerUp.EffectPowerUp;
        effectPowerUp.Application(this);
        powerUp.Collected();
        this.currentPowerUp = effectPowerUp;
    }

    public int Lifes
    {
        get
        {
            return this.lifes;
        }
        set
        {
            this.lifes = value;
            if (this.lifes > maxLife)
            {
                this.lifes = maxLife;
            }

            if (this.lifes < 1)
            {
                this.lifes = 0;
                this.gameObject.SetActive(false);
                gameOverScreen.Show();

                this.audioControll.PlayGameOverAudio();
            }
        }
    }

}
