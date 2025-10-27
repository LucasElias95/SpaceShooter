using UnityEngine;

public interface IPlayerMovement
{
    void Config(Rigidbody2D rigidbody2D, Transform playerTransform, float movementVelocity);

    void Atualizar();
} 
