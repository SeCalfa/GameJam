using UnityEngine;

namespace Game.Code.Logic.Audio
{
    public class SoundManager : MonoBehaviour
    {
        private AudioSource _audioSource1;
        private AudioSource _audioSource2;
        private AudioSource _audioSource3;

        private void Awake()
        {
            _audioSource1 = gameObject.AddComponent<AudioSource>();
            _audioSource2 = gameObject.AddComponent<AudioSource>();
            _audioSource3 = gameObject.AddComponent<AudioSource>();
        }
        
        private void PlaySound(AudioSource audioSource) => 
            audioSource.PlayOneShot(audioSource.clip);

        private void StopSound(AudioSource audioSource) => 
            audioSource.Stop();
        
        
    }
}