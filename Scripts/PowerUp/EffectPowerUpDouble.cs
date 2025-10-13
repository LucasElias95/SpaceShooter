using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPowerUpDouble : EffectPowerUp
{
   public override void Application(PlayerShip player)
   {
    player.EquipWeaponsDouble();
   }
}
