using UnityEngine;
[CreateAssetMenu(fileName = "ConstantMovement", menuName = "SpaceShooter/Enemys/Movement/ConstantMovement")]
public class ConstantMovement : BaseMovement
{


    public override Vector2 CalculateCurrentVelocity(MovementBaseState stateMovement)
    {
        return this.movementVelocity;
    }

    public override MovementBaseState CreateMovimentState()
    {
        return null;
    }

}
