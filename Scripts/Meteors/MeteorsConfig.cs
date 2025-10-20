using UnityEngine;

[CreateAssetMenu(fileName = "NovaConfiguração", menuName = "SapceShooter/Meteors/meteorsConfig")]
public class MeteorsConfig : ScriptableObject
{
  
   
    [SerializeField]
    private Meteor meteorPrefab;

    [SerializeField]
    private MeteorsProperties meteorProperties;

    public Meteor MeteorPrefab{
        get{
            return this.meteorPrefab;
        }
    }

    public MeteorsProperties MeteorProperties{
        get{
            return this.meteorProperties;
        }
    }
}
