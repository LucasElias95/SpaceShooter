using UnityEngine;

public class Laser : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float velocityY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Direction = this.transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        Camera camera = Camera.main;
        Vector3 cameraPosition = camera.WorldToViewportPoint(this.transform.position);
        //a parte de cima referencia a posição da tela, a aprte de baixo verifica se ele passou do limite da tela
        if (cameraPosition.y > 1)
        {
            Destroy(this.gameObject);
        }
    }

    public Vector2 Direction
    {
        set
        {
            this.transform.up = value;
            this.rigidbody.linearVelocity = value.normalized * this.velocityY;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.CompareTag("Enemy"))
        {
            //destruit o inimigo
            Enemy enemy = collider.GetComponent<Enemy>(); //busca o obejeto inimigo no script inimigo 
            enemy.Damage(); 
            //destruir o laser
            Destroy(this.gameObject);
        }

         if (collider.CompareTag("Meteor"))
        {
            //destruit o inimigo
            Meteor meteor = collider.GetComponent<Meteor>(); //busca o obejeto inimigo no script meteor 
            meteor.Damage(); 
            //destruir o laser
            Destroy(this.gameObject);
        }
    }
}
