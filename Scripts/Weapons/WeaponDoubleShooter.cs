using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDoubleShooter : BasicWeapons
{
    protected override void Shooter()
    {
        CreatLaser(this.positionsShooter[0].position);
        CreatLaser(this.positionsShooter[1].position);
    }
}
