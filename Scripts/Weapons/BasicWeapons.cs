using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicWeapons : MonoBehaviour
{
    public Laser laserPrefab;
    public float laserWaitingTime;
    private float laserGap;
    public Transform[] positionsShooter; //define o array das posições de onde saira o tiro
  
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public virtual void Start() //virtual: se alguma classe que herda esse metodo quiser alterar esse metodo ele pode
    {
        this.laserGap = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.laserGap += Time.deltaTime; //adiciona o valor de 1 ao laserGap a cada frame
        if (this.laserGap >= laserWaitingTime) //qunado laserGap >= 1 atirar e zer o valor de laserGap
        {
            this.laserGap = 0;
            Shooter();
            
        }
    }

    protected void CreatLaser(Vector2 _position)
    {
        //logica de tiro que instancia o laser
        Instantiate(this.laserPrefab, _position, Quaternion.identity);
    }

    //protected é usado para proteger o metodo, assim ele pode ser acessado pela propria classe, ou classes que herdam a classe orinal
    //abstract diz o metodo existe, mas é implementado em outra classe
    protected abstract void Shooter();

    public void Enable()
    {
        this.gameObject.SetActive(true);
    }
    
    public void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
