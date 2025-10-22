using UnityEngine;

public class InfinityBackGround : MonoBehaviour
{
    public Renderer renderer;
    public float velocity;

    private Material material;
    private Vector2 offsetMaterial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.material = this.renderer.material;
        this.offsetMaterial = this.material.GetTextureOffset("_BaseMap");
    }

    // Update is called once per frame
    void Update()
    {
        this.offsetMaterial.y -= this.velocity * Time.deltaTime;
        this.material.SetTextureOffset("_BaseMap", this.offsetMaterial);
    }
}
