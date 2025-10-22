using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaseControll : MonoBehaviour
{
    [SerializeField]
    private Fase[] fase;
    
    private int indiceCurrentfase;
    private Fase currentFase;

    private void Start()
    {
        this.indiceCurrentfase = -1;
        AdvacendNextFase();
    }

    private void Update()
    {
        if (this.currentFase != null)
        {
            this.currentFase.Atualizar();
        }
    }

    private void StartCurrentFase()
    {
        this.currentFase = this.fase[this.indiceCurrentfase];
        this.currentFase._FaseFinished += FinishFase;
        this.currentFase.Iniciar();
    }

    public void FinishFase()
    {   this.currentFase._FaseFinished -= FinishFase;
        if (HaveNextFase())
        {
           AdvacendNextFase();
        }
        else
        {
            Debug.Log("Jogo Concluido");
        }

    }

    private void AdvacendNextFase()
    { 
        AnimationFaseTransition.Instance.FinishAnimationFaseTransition += FinishTransitionFase;

        Fase nextFase = this.fase[this.indiceCurrentfase + 1];
        AnimationFaseTransition.Instance.Show(nextFase.name);
        
    }

    private void FinishTransitionFase()
    {
        AnimationFaseTransition.Instance.FinishAnimationFaseTransition -= FinishTransitionFase;
        this.indiceCurrentfase++;
        StartCurrentFase(); 
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
