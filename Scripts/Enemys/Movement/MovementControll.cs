using UnityEngine;

public class MovementControll
{
    private BaseMovement movement;
    private MovementBaseState stateMovement;


    public MovementControll(BaseMovement movement)
    {
        this.movement = movement;
        this.stateMovement = this.movement.CreateMovimentState();
    }

    public void Atualizar()
    {
        if (this.stateMovement != null)
        {
            this.stateMovement.Atualizar();
        }
        
    }

    public Vector2 CalculateCurrentVelocity()
    {
      return this.movement.CalculateCurrentVelocity(this.stateMovement);
    }
}
