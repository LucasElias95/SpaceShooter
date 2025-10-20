using UnityEngine;
[CreateAssetMenu(fileName = "Fase", menuName = "SpaceShooter/Fases/Fase")]
public class Fase : ScriptableObject
{
  [SerializeField]
  private string name;

  [SerializeField]
  private EnemyControllConfig enemyControllConfig;

  public string Name{
    get{
        return this.name;
    }
  }

  public EnemyControllConfig EnemyControllConfig{
    get{
        return this.enemyControllConfig;
    }
  }
}
