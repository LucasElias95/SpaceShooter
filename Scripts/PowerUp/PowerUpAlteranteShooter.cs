using UnityEngine;

public class PowerUpAlteranteShooter : PowerUpCollectible
{
    public override EffectPowerUp EffectPowerUp
    {
        get{
            return new EffectPowerUpAlternate();
        }
    }
}
