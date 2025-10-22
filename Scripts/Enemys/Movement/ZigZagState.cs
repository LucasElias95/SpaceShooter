using UnityEngine;

public class ZigZagState : MovementBaseState
{
   
    private float movimentTime;

   public override void Atualizar()
   {
    this.movimentTime += Time.deltaTime;
   }


   public float MovimentTime{
    get{
        return this.movimentTime;
    }
   }

}
