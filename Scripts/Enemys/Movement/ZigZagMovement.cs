using UnityEngine;

[CreateAssetMenu(fileName = "ZigZagMovement", menuName = "SpaceShooter/Enemys/Movement/ZigZagMovement")]
public class ZigZagMovement : BaseMovement
{
    [SerializeField]
    private float amplitudeMovimentacaoX;

    public override Vector2 CalculateCurrentVelocity(MovementBaseState stateMovement)
    {
        ZigZagState zigZagState = (ZigZagState)stateMovement;


        float velocityX = Mathf.Sin(zigZagState.MovimentTime * this.movementVelocity.x) * this.amplitudeMovimentacaoX;


        return new Vector2(velocityX, this.movementVelocity.y);
    }

     public override MovementBaseState CreateMovimentState()
    {
        return new ZigZagState();
    }
}
