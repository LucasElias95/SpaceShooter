using UnityEngine;

public class EffectPowerUpShield : EffectPowerUp
{
    public EffectPowerUpShield(float durationSeconds) : base(durationSeconds)
   {
      
   }
    public override void Application(PlayerShip player)
    {
        player.ActiveShield();
    }
    
    public override void Remove(PlayerShip player)
   {
      player.RemoveShield();
   }
}
