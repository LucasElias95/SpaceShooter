using UnityEngine;

public class EffectPowerUpSpreadShooter : EffectPowerUp
{
   public EffectPowerUpSpreadShooter(float durationSeconds) : base(durationSeconds)
   {
      
   }

   public override void Application(PlayerShip player)
   {
    player.EquipWeaponsSpread();
   }

   public override void Remove(PlayerShip player)
   {
      player.EquipWeaponsAlternate();
   }
}
