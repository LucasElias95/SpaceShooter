using UnityEngine;

[CreateAssetMenu(fileName = "NovaConfiguração", menuName = "SapceShooter/Meteors/meteorsProperties")]
public class MeteorsProperties : ScriptableObject
{
    [Header("Atributos")]
    [SerializeField]
    private float minVelocity; //1
    [SerializeField]
    private float maxVelocity; //3
    [SerializeField]
    private int maxLifes;

    [Header("Drops")]
    [SerializeField, Range(0f, 100f)]
    private float chanceDropLifeItem;
    [SerializeField]
    private LifeItem lifeItemprefab;
    [SerializeField, Range(0f, 100f)]
    private float chanceDropPowerUp;
    [SerializeField]
    private PowerUpCollectible[] powerUpPrefabs;

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
            return this.maxLifes;
        }
    }
    
    public float ChanceDropLifeItem{
        get{
            return this.chanceDropLifeItem;
        }
    }

     public LifeItem LifeItemPrefab{
        get{
            return this.lifeItemprefab;
        }
    }
    
    public float ChanceDropPowerUp{
        get{
            return this.chanceDropPowerUp;
        }
    }

    public PowerUpCollectible[] PowerUpPrefabs{
        get{
            return this.powerUpPrefabs;
        }
    }
}
