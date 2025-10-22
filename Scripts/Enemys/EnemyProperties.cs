using UnityEngine;

[CreateAssetMenu(fileName = "NovaConfiguração", menuName = "SpaceShooter/Enemys/enemyProperties")]
public class EnemyProperties : ScriptableObject
{
    [SerializeField]
    private BaseMovement baseMovement;
    
    [SerializeField]
    private int maxLife;
    

    public BaseMovement _BaseMovement{
        get{
            return this.baseMovement;
        }
    }
    

    public int MaxLife{
        get{
            return this.maxLife;
        }
    }
}
