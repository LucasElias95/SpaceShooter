using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControll : MonoBehaviour
{
    [SerializeField]
    private WeaponAlternateShooter alternateShooter; //disparos alternados

    [SerializeField]
    private WeaponDoubleShooter doubleShooter; //disparos dulpos

    private BasicWeapons actualWeapon; //define o tipo de disparo atual

    private void Awake()
    {
        this.alternateShooter.Disable();
        this.doubleShooter.Disable();
    }

    public void EquipAlternate()
    {   
        this.ActualWeapon = this.alternateShooter; //equipa o disparo alternado

    }

    public void EquipDouble()
    {
        this.ActualWeapon = this.doubleShooter; //equipa o disparo duplo
    }

    private BasicWeapons ActualWeapon //controla qual o tipo de disparo está sendo usado
    {
        set
        {   
            if (this.actualWeapon != null)
            {
                this.actualWeapon.Disable();
            }

            this.actualWeapon = value;
            this.actualWeapon.Enable();
        }
    }

}
