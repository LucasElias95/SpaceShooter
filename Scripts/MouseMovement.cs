using UnityEngine;

public class MouseMovement : IPlayerMovement
{


    private Rigidbody2D rigidbody2D;
    private float movementVelocity;

    private Transform playerTransform;
    private Camera camera;

    public void Config(Rigidbody2D rigidbody2D, Transform playerTransform, float movementVelocity)
    {
        this.camera = Camera.main;
        this.rigidbody2D = rigidbody2D;
        this.playerTransform = playerTransform;
        this.movementVelocity = movementVelocity;
    }

    public void Atualizar()
    {
        Vector2 _mousePosition = Input.mousePosition;
        Vector2 worldPosition = this.camera.ScreenToWorldPoint(_mousePosition);

        Vector2 newPosition = Vector2.Lerp(this.playerTransform.position, worldPosition, (this.movementVelocity * Time.deltaTime));
        this.rigidbody2D.position = newPosition;
    }
 
}
