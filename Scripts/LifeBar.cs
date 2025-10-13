using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    [SerializeField] private GameObject[] lifeIcons;

    public void ShowLife(int lifes)
    {
        for (int i = 0; i < this.lifeIcons.Length; i++) //o for percorre todos os indices do array
        {
            if (i < lifes) //i é menor que o valor de vida a barra  é ativa, quado o indece é maior que o valor da vida o icone desativa
            {
                this.lifeIcons[i].SetActive(true); //pega a vida que está na posição i e ativa o estado
            }
            else 
            {
                this.lifeIcons[i].SetActive(false);
            }
        }
    }
}
