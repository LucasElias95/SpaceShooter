using UnityEngine;

public class LifeItem : MonoBehaviour
{

[SerializeField] private int lifeRecharge;
[SerializeField] private ParticleSystem particlePrefab;

public int LifeRecharge
{
    get
    {
        return this.lifeRecharge;
    }
}

public void Collected()
{
    AudioControll audioControll = GameObject.FindObjectOfType<AudioControll>();
    audioControll.PlayCollectedLifeItemAudio();
    //cria e destroi a particula
    ParticleSystem particle = Instantiate(this.particlePrefab, this.transform.position, Quaternion.identity);
    Destroy(particle.gameObject, 1f);

    //destroi o item
    Destroy(this.gameObject);
}

}
