using UnityEngine;

public class PointAndClickMovement : IPlayerMovement
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
         if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = touch.position;
            Vector2 worldPosition = this.camera.ScreenToWorldPoint(touchPosition);

            Vector2 newPosition = Vector2.Lerp(this.playerTransform.position, worldPosition, (this.movementVelocity * Time.deltaTime));
            this.rigidbody2D.position = newPosition;
        }
    }

}
