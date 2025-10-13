using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpCollectible : MonoBehaviour
{
    public abstract EffectPowerUp EffectPowerUp { get; }

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private float gapTimeBetweenBlink;

    [SerializeField]
    private int totalBlink;
    [SerializeField]
    private float gapTimeToAutoDestroy;

    private float countTimeToAutodestroy;

    private bool autoDestroy;

    [SerializeField]
    private float  lessBlinkTime;

    public void Start()
    {
        this.countTimeToAutodestroy = 0;
        this.autoDestroy = false;
    }

    public void Update()
    {
        if (!this.autoDestroy)
        {
            
            this.countTimeToAutodestroy += Time.deltaTime;
            if (this.countTimeToAutodestroy >= this.gapTimeToAutoDestroy)
            {
                InicializeAutoDestroy();
            }
        }    
    }

    public void Collected()
    {
        Destroy(this.gameObject);
    }

    private void InicializeAutoDestroy()
    {
        this.autoDestroy = true;
        StartCoroutine(AutoDestroy());
    }

    private IEnumerator AutoDestroy()
    {
        int countBlink = 0;
        do
        {
            
            this.spriteRenderer.enabled = !this.spriteRenderer.enabled; //recebe o valor diferente do atual

            //esperar um intervalo de tempo
            yield return new WaitForSeconds(this.gapTimeBetweenBlink);
            countBlink++;
            this.gapTimeBetweenBlink -= countBlink * this.lessBlinkTime;            

        } while (countBlink < this.totalBlink);
        Destroy(this.gameObject);
    }

}
//o do faz o codigo repetir o laço até as condições determinadas, no caso ele repete o laço ate o countBlink ser igual ao totalBlink
