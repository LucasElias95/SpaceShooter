using UnityEngine;

public class KeyboardMovement : IPlayerMovement
{
    private Rigidbody2D rigidbody2D;
    private float movementVelocity;

    public void Config(Rigidbody2D rigidbody2D, Transform playerTransform, float movementVelocity)
    {
       this.rigidbody2D = rigidbody2D;
       this.movementVelocity = movementVelocity;
    }

    public void Atualizar()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float velocidadeX = (horizontal * this.movementVelocity);
        float velocidadeY = (vertical * this.movementVelocity);

        this.rigidbody2D.linearVelocity = new Vector2(velocidadeX, velocidadeY);
    }
}
