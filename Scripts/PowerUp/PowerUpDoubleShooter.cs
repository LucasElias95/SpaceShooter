using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDoubleShooter : PowerUpCollectible
{
    public override EffectPowerUp EffectPowerUp
    {
        get {
            return new EffectPowerUpDouble(); 
        }
    }
}
