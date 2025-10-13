using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPowerUpAlternate : EffectPowerUp
{
   public override void Application(PlayerShip player)
   {
    player.EquipWeaponsAlternate();
   }
}
