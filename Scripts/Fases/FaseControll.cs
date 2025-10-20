using UnityEngine;

public class FaseControll : MonoBehaviour
{
    [SerializeField]
    private Fase[] fase;
    
    private int indiceCurrentfase;
    private Fase currentFase;

    [SerializeField]
    private EnemyControll enemyControll; 

    private void Start()
    {
        this.indiceCurrentfase = 0;
        StartCurrentFase();
    }

    private void StartCurrentFase()
    {
        this.currentFase = this.fase[this.indiceCurrentfase];
        this.enemyControll.Config(this, this.currentFase.EnemyControllConfig);
    }

    public void FinishFase()
    {   
        if (HaveNextFase())
        {
            Debug.Log("Fase" + this.currentFase.Name + "foi concluida");
            this.indiceCurrentfase++;
            StartCurrentFase(); 
        }
        else
        {
            Debug.Log("Jogo Concluido");
        }

    }

    private bool HaveNextFase()
    {
        if (this.indiceCurrentfase <(this.fase.Length - 1))
        {
            return true;
        }
        return false;
    }
}
