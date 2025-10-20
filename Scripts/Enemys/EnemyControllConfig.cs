using UnityEngine;

[CreateAssetMenu(fileName = "New Configuration", menuName = "SpaceShooter/Enemys/New Configuration Enemy Controll")]
public class EnemyControllConfig : ScriptableObject
{
    [SerializeField]
    private EnemyConfig[] enemyConfig;
    [SerializeField]
    private float timeToCreate;
    [SerializeField]
    private int totalEnemys;

    public EnemyConfig[] EnemyConfig
    {
        get{
            return this.enemyConfig;
        }
    }

    public float TimeToCreate{
        get{
            return this.timeToCreate;
        }
    }

    public int TotalEnemys
    {
        get{
            return this.totalEnemys;
        }
    }
}
