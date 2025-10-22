using UnityEngine;
using Com.MustacheGameStudioTV.SpawnPoints;
[CreateAssetMenu(fileName = "Fase", menuName = "SpaceShooter/Fases/Fase")]
public class Fase : ScriptableObject
{
    public delegate void FaseFinishedDelegate();
    public FaseFinishedDelegate _FaseFinished;
  [SerializeField]
  private string name;

  [SerializeField]
  private ControladorInimigo controladorInimigo;

  public string Name{
    get{
        return this.name;
    }
  }

public ControladorInimigo ControladorInimigo{
    get{
        return this.controladorInimigo;
    }
}

public void Iniciar()
{
    this.controladorInimigo.OndasInimigoConcluidas += FaseFinished;
    this.controladorInimigo.Iniciar();
}

public void Atualizar()
{
    this.controladorInimigo.Atualizar();
}

private void FaseFinished()
{
    this.controladorInimigo.OndasInimigoConcluidas -= FaseFinished;
   
    if(this._FaseFinished != null){
    this._FaseFinished.Invoke();
   }
}
 
}
