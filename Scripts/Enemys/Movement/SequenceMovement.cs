using UnityEngine;

[CreateAssetMenu(fileName = "SequenceMoviment", menuName = "SpaceShooter/Enemys/Movement/SequenceMoviment")]
public class SequenceMovement : BaseMovement
{
    [SerializeField]
    private EnemyStepMovement[] enemyStepMovement;
    [SerializeField]
    private float timeStepMovement;

    public override Vector2 CalculateCurrentVelocity(MovementBaseState stateMovement)
    {
        SequenceMovementState sequenceMovementState = (SequenceMovementState)stateMovement;
        EnemyStepMovement currentEnemyStep = sequenceMovementState.CurrentStep;

        if (sequenceMovementState.CurrentTime >= this.timeStepMovement)
        {
            sequenceMovementState.AdvancedNextStep();
        }

        if (currentEnemyStep == EnemyStepMovement.Up)
        {
            return new Vector2(0, this.movementVelocity.y);
        }
        else if(currentEnemyStep == EnemyStepMovement.Down)
        {
            return new Vector2(0, -this.movementVelocity.y);
        }
        else if (currentEnemyStep == EnemyStepMovement.LeftToRight)
        {
            return new Vector2(this.movementVelocity.x, 0);
        }
        else
        {
            return new Vector2(-this.movementVelocity.x, 0);
        }
    }

    public override MovementBaseState CreateMovimentState()
    {
        return new SequenceMovementState(this. enemyStepMovement);
    }
}
