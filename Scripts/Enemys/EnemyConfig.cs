using UnityEngine;

[CreateAssetMenu(fileName = "NovaConfiguração", menuName = "SpaceShooter/Enemys/enemyConfig")]
public class EnemyConfig : ScriptableObject
{
 
    [SerializeField]
    private Enemy enemyPrefab;

    [SerializeField]
    private EnemyProperties enemyProperties;

    public Enemy EnemyPrefab{
        get{
            return this.enemyPrefab;
        }
    }

    public EnemyProperties EnemyProperties{
        get{
            return this.enemyProperties;
        }
    }
}
