using UnityEngine;

public class PowerUpSpreadShooter : PowerUpCollectible
{
   public override EffectPowerUp EffectPowerUp
    {
        get {
            return new EffectPowerUpSpreadShooter(DurationSeconds); 
        }
    }
   
}
