using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    public Enemy enemy1; //Enemy é o script do inimigo enemy é o nome da variavel usada no script atual
    public Enemy enemy2;
    private Enemy prefabEnemy; //criar uma variavel de inimigo para ser instanciado
    private float timeSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.timeSpawn = 0; //valor inicia em zero
    }

    // Update is called once per frame
    void Update()
    {
        //criar um novo inimigo toda vez que o tempo for maior ou igual a que 1
        this.timeSpawn += Time.deltaTime; // a cada frame o valor é acrescido em +1
        if (this.timeSpawn >= 1f)
        {
            this.timeSpawn = 0; // retorna o tempo a 0

            Vector2 maxPosition = Camera.main.ViewportToWorldPoint(new Vector2(1, 2)); //define os valores maximos dos eixos x e y do cenario
            Vector2 minPosition = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //define os valores minimos dos eixos x e y do cenario

            float positionX = Random.Range(minPosition.x, maxPosition.x); //instancia um inimigo no eixo x dentro dos limites definidos
            Vector2 enemyPosition = new Vector2(positionX, maxPosition.y); //instancia um inimigo no eixo y dentro dos limites definidos

            
            //define a porcentagem de chance de cada inimigo ser instanciado
            float chance = Random.Range(0f, 100f);
            if (chance <= 20)
            {
                prefabEnemy = this.enemy2;
            }
            else
            {
                prefabEnemy = this.enemy1;
            }
            //instancia o inimigo
            Instantiate(this.prefabEnemy, enemyPosition, Quaternion.identity);
        }
    }
}
