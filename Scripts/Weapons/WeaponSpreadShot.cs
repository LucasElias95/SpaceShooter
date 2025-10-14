using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpreadShot : BasicWeapons
{
    [SerializeField, Range(0f, 30f)] //range serve para configurar na unity através de uma barra 
    private float angleBetweenShots;

    [SerializeField, Range(1, 30)]
    private int numberOfShooters;

    protected override void Shooter()
        {
            Vector2 positionShooter = this.positionsShooter[0].position;

            // Calcula o ângulo inicial (para centralizar o arco)
            float startAngle = -((numberOfShooters - 1) * angleBetweenShots) / 2f;

            for (int i = 0; i < this.numberOfShooters; i++)
            {
                // ângulo relativo ao centro
                float currentAngle = startAngle + (i * angleBetweenShots);

                // calcula direção do tiro
                Quaternion rotation = Quaternion.AngleAxis(currentAngle, Vector3.forward);
                Vector2 direction = rotation * Vector3.up;

                // cria o laser
                Laser laser = CreatLaser(positionShooter);

                // define direção e velocidade
                laser.Direction = direction;

            }
        }

    private Vector2 CalculateShotDirection(int indiceShots)
    {
        int indiceShootArc;
        if ((this.numberOfShooters % 2) == 0) //se a sobra for igual a 0 o número é par, % faz referencia ao valor que sobra da conta
        {   //se for par não utiliza o indice 0 no calculo do angulo
            indiceShootArc = indiceShots +1;
        }
        else
        {
            indiceShootArc = indiceShots;
        }


        indiceShootArc = Mathf.CeilToInt(indiceShootArc /2f); //divide o número por 2 e arredonda para cima

        float angle = (this.angleBetweenShots * indiceShots);
        if ((indiceShots % 2) != 0) //se for impar ele inverte o valor do angulo
        {
            angle *= -1;
        }

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Vector2 direction = rotation * Vector3.up; //Vector3.up != this.transform.up Vector3 é sempre para cima
        return direction;
    }
}
