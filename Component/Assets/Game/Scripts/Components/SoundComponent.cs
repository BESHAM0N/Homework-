using UnityEngine;

namespace Component
{
    public class SoundComponent : MonoBehaviour
    {
        [SerializeField] private AudioClip _sound;  
        [SerializeField] private AudioSource _audioSource; 
      
        public void PlaySound()
        {
            if (_sound == null)
            {
                Debug.LogWarning("SoundComponent: Аудиоклип не назначен!");
                return;
            }
            
            _audioSource.PlayOneShot(_sound);
        }
    }
}