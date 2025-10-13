using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPowerUpAlternate : EffectPowerUp
{
   public EffectPowerUpAlternate(float durationSeconds) : base(durationSeconds)
   {
      
   }

   public override void Application(PlayerShip player)
   {
    player.EquipWeaponsAlternate();
   }

   public override void Remove(PlayerShip player)
   {
      player.EquipWeaponsAlternate();
   }
}
