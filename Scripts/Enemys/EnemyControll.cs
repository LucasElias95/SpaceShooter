using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyControll : MonoBehaviour
{
    private EnemyControllConfig enemyControllConfig;
    private float timeSpawn;
    private bool enemysCreated;
    private int numberOfEnemysCrated;
    private List<Enemy> enemys;
    private FaseControll faseControll;

 
    // Update is called once per frame
   private void Update()
    {
        if (this.enemysCreated)
        {
            return;
        }
        //criar um novo inimigo toda vez que o tempo for maior ou igual a que 1
        this.timeSpawn += Time.deltaTime; // a cada frame o valor é acrescido em +1
        if (this.timeSpawn >= this.enemyControllConfig.TimeToCreate)
        {
            this.timeSpawn = 0; // retorna o tempo a 0
            this.numberOfEnemysCrated ++;
            CreateEnemy();

            if (this.numberOfEnemysCrated >= this.enemyControllConfig.TotalEnemys)
            {
                this.enemysCreated = true;
            }
        }
    }

    private void CreateEnemy()
    {
         EnemyConfig enemyConfig = GetConfigRandomEnemy();
            Enemy prefabEnemy = enemyConfig.EnemyPrefab;
            //instancia o inimigo
            Vector2 enemyPosition = GetRandomPositionForEnemy();
            Enemy newEnemy = Instantiate(prefabEnemy, enemyPosition, Quaternion.identity);
            newEnemy.Config(this, enemyConfig.EnemyProperties);
            this.enemys.Add(newEnemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        if (this.enemys.Contains(enemy))
        {
            this.enemys.Remove(enemy);
            if (this.enemysCreated && (this.enemys.Count == 0))
            {
                //fase concluida
                this.faseControll.FinishFase();
            }
        }
    }

    private Vector2 GetRandomPositionForEnemy()
    {
         Vector2 maxPosition = Camera.main.ViewportToWorldPoint(new Vector2(1, 2)); //define os valores maximos dos eixos x e y do cenario
            Vector2 minPosition = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //define os valores minimos dos eixos x e y do cenario

            float positionX = Random.Range(minPosition.x, maxPosition.x); //instancia um inimigo no eixo x dentro dos limites definidos
            Vector2 enemyPosition = new Vector2(positionX, maxPosition.y); //instancia um inimigo no eixo y dentro dos limites definidos
            return enemyPosition;
    }

    private EnemyConfig GetConfigRandomEnemy()
    {
        EnemyConfig[] enemyConfigs = this.enemyControllConfig.EnemyConfig;
        if((enemyConfigs == null) || (enemyConfigs.Length == 0))
        {
            return null;
        }
        int randomIndice = Random.Range(0, enemyConfigs.Length);
        return enemyConfigs[randomIndice];
    }

    public void Config(FaseControll faseControll, EnemyControllConfig enemyControllConfig)
    {
        this.faseControll = faseControll;
        this.enemyControllConfig = enemyControllConfig;

        this.timeSpawn = 0; //valor inicia em zero
        this.enemysCreated = false;
        this.numberOfEnemysCrated = 0;
        this.enemys = new List<Enemy>();
    }
}
