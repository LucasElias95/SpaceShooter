using UnityEngine;

[CreateAssetMenu(fileName = "NovaConfiguração", menuName = "SapceShooter/Enemys/enemyProperties")]
public class EnemyProperties : ScriptableObject
{
    [SerializeField]
    private float minVelocity;
    [SerializeField]
    private float maxVelocity;
    [SerializeField]
    private int maxLife;
    

    public float MinVelocity{
        get{
            return this.minVelocity;
        }
    }
    
    public float MaxVelocity{
        get{
            return this.maxVelocity;
        }
    }

    public int MaxLife{
        get{
            return this.maxLife;
        }
    }
}
