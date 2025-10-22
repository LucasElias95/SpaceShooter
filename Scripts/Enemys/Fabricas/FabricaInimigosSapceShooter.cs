using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.MustacheGameStudioTV.SpawnPoints;

[CreateAssetMenu(fileName = "NovaFabricaDeInimigos", menuName = "SpaceShooter/Enemys/Fabrica/NovaFabrica")]
public class FabricaInimigosSapceShooter : FabricaInimigo
{
    [SerializeField]
    private Enemy prefabEnemy;

    [SerializeField]
    private EnemyProperties enemyProperties;

    public override InimigoBase CriarInimigo(Vector3 posicao)
    {
        Enemy newEnemy = Instantiate(this.prefabEnemy, posicao, Quaternion.identity);
        newEnemy.Config(this.enemyProperties);
        return newEnemy;
    }
}
