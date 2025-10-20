using UnityEngine;

public class AudioControll : MonoBehaviour
{

    [SerializeField]
    private AudioClip damageShield;
    
    [SerializeField]
    private AudioClip damagePlayer;

    [SerializeField]
    private AudioClip gameOver;

    [SerializeField]
    private AudioClip enemyExplosion;

    [SerializeField]
    private AudioClip laser;

    [SerializeField]
    private AudioClip collectedPowerUp;

    [SerializeField]
    private AudioClip collectedLifeItem;
    
    [SerializeField]
    private AudioSource audioSource;

    public void PlayDamageShieldAudio()
    {
        PlayAudio(this.damageShield);
    }

    public void PlayDamagePlayerdAudio()
    {
        PlayAudio(this.damagePlayer);
    }

    public void PlayGameOverAudio()
    {
        PlayAudio(this.gameOver);
    }

    public void PlayEnemyExplosiondAudio()
    {
        PlayAudio(this.enemyExplosion);
    }

    public void PlayLaserAudio()
    {
        PlayAudio(this.laser, 0.3f);
    }

    public void PlayCollectedPowerUpAudio()
    {
        PlayAudio(this.collectedPowerUp);
    }    

    public void PlayCollectedLifeItemAudio()
    {
        PlayAudio(this.collectedLifeItem);
    }  

    private void PlayAudio(AudioClip audioClip, float volume = 1)
    {
        this.audioSource.PlayOneShot(audioClip, volume); //PlayOneShot faz com que o audio executado não pause o som que já está tocando
    }
}
