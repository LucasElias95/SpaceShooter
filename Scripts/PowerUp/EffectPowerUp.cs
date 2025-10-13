using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectPowerUp
{
  private float durationSeconds;

  public EffectPowerUp(float durationSeconds)
  {
    this.durationSeconds = durationSeconds;
  }

  public abstract void Application(PlayerShip player);
  public abstract void Remove(PlayerShip player);

  public void Upadate_()
  {
    if (Active)
    {
      this.durationSeconds -= Time.deltaTime;
      Debug.Log("Tempo restante " + this.durationSeconds);
    }
    
  }

  public bool Active
  {
    get
    {
      return (this.durationSeconds > 0); // funciona como se fosse um if que retonar verdadeiro qunado duration maior que 0 ou false caso contrario
    }
  }
}
