using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAlternateShooter : BasicWeapons
{
    private Transform positionNextShooter; // definie a posição atual do tiro
    
    public override void Start()//override soprepoem o metodo ao metodo original, no metodo basic eu uso o virtual para poder alterar o metodo
    {
        base.Start(); //base chama o Start() do script base "BasicWeapons"
        this.positionNextShooter = this.positionsShooter[0]; //inicia com a arma de posição 0
    }

    protected override void Shooter()
    {
        //criar o laser
        CreatLaser(this.positionNextShooter.position);

        //alternar o local de onde sai o disparo
        if (this.positionNextShooter == this.positionsShooter[0])
        {
            this.positionNextShooter = this.positionsShooter[1];
        }
        else
        {
             this.positionNextShooter = this.positionsShooter[0];
        }
                
        
    }
}
