using UnityEngine;

public abstract class BaseMovement : ScriptableObject
{
    [SerializeField]
    protected Vector2 movementVelocity;

    public abstract Vector2 CalculateCurrentVelocity(MovementBaseState stateMovement);

    public abstract MovementBaseState CreateMovimentState();
}
