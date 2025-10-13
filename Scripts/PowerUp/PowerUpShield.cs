using UnityEngine;

public class PowerUpShield : PowerUpCollectible
{
    public override EffectPowerUp EffectPowerUp
    {
        get{
            return new EffectPowerUpShield();
        }
    }
}
