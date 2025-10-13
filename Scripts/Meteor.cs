using UnityEngine;

public class Meteor : MonoBehaviour
{
    [Header("Referências")]
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody2D;

    [Header("Atributos do Meteoro")]
    public float minVelocity = 1f;
    public float maxVelocity = 3f;
    public int life = 1;

    [SerializeField] private float velocityY;

    [Header("Drop de Vida")]
    [SerializeField, Range(0, 100)]
    private float chanceDropItem = 10f;
    [SerializeField] private LifeItem lifeItemPrefab;

    [SerializeField, Range(0, 100)] private float chancePowerUp;
    [SerializeField] private PowerUpCollectible [] powerUpsPrefab;

    [Header("Partículas")]
    public ParticleSystem explosionParticlePrefab;

    void Start()
    {
        // Garante que há um Rigidbody2D no meteoro
        if (rigidbody2D == null)
            rigidbody2D = GetComponent<Rigidbody2D>();

        if (rigidbody2D == null)
            Debug.LogWarning("⚠️ Nenhum Rigidbody2D encontrado em " + gameObject.name);

        // Define a velocidade inicial
        this.velocityY = Random.Range(this.minVelocity, this.maxVelocity);

        // Corrige a posição caso o meteoro esteja fora da tela
        AjustarPosicaoInicial();
    }

    void Update()
    {
        // Aplica movimento vertical
        if (rigidbody2D != null)
        {
            rigidbody2D.linearVelocity = new Vector2(0, -this.velocityY);
        }

        // Destroi o meteoro se sair da tela
        Camera camera = Camera.main;
        Vector3 cameraPosition = camera.WorldToViewportPoint(this.transform.position);
        if (cameraPosition.y < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void AjustarPosicaoInicial()
    {
        Vector2 currentPosition = this.transform.position;
        float halfWidth = Width / 2f;
        float leftReferencePoint = currentPosition.x - halfWidth;
        float rightReferencePoint = currentPosition.x + halfWidth;

        Camera camera = Camera.main;
        Vector2 lowerLeftLimit = camera.ViewportToWorldPoint(Vector2.zero);
        Vector2 upperRightLimit = camera.ViewportToWorldPoint(Vector2.one);

        if (leftReferencePoint < lowerLeftLimit.x) // saiu pela esquerda
        {
            float positionX = lowerLeftLimit.x + halfWidth;
            this.transform.position = new Vector2(positionX, currentPosition.y);
        }
        else if (rightReferencePoint > upperRightLimit.x) // saiu pela direita
        {
            float positionX = upperRightLimit.x - halfWidth;
            this.transform.position = new Vector2(positionX, currentPosition.y);
        }
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
        if (this.life <= 0)
        {
            Killed(true);
        }
    }

    public void Killed(bool defeated)
    {
        if (defeated)
        {
            DropItem();
            DropPowerUp();
        }

        // Cria partículas de explosão
        if (explosionParticlePrefab != null)
        {
            ParticleSystem explosionParticle = Instantiate(explosionParticlePrefab, this.transform.position, Quaternion.identity);
            Destroy(explosionParticle.gameObject, 1f);
        }

        Destroy(this.gameObject);
    }

    private void DropItem()
    {
        float dropRandom = Random.Range(0f, 100f);
        if (dropRandom <= this.chanceDropItem && lifeItemPrefab != null)
        {
            Instantiate(this.lifeItemPrefab, this.transform.position, Quaternion.identity);
        }
    }

    private void DropPowerUp()
    {
        float randomChance = Random.Range(0f, 100f);
        if (randomChance <= this.chancePowerUp)
        {
            int randomIndicePowerUp = Random.Range(0, this.powerUpsPrefab.Length);
            PowerUpCollectible powerUpsPrefab = this.powerUpsPrefab[randomIndicePowerUp];
            Instantiate(powerUpsPrefab, this.transform.position, Quaternion.identity);
        }
    }
}
