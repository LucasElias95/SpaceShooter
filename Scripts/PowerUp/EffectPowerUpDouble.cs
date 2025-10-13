using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPowerUpDouble : EffectPowerUp
{
   public EffectPowerUpDouble(float durationSeconds) : base(durationSeconds)
   {
      
   }

   public override void Application(PlayerShip player)
   {
    player.EquipWeaponsDouble();
   }

   public override void Remove(PlayerShip player)
   {
      player.EquipWeaponsAlternate();
   }
}
