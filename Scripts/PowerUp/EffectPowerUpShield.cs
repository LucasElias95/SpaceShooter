using UnityEngine;

public class EffectPowerUpShield : EffectPowerUp
{
    public override void Application(PlayerShip player)
    {
        player.ActiveShield();
    }
    
}
