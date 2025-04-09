using System.Collections.Generic;
using UnityEngine;

namespace Component
{
    public sealed class SoundComponent : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private SoundEntry[] _soundEntries;
        private Dictionary<SoundType, AudioClip> _soundDictionary;

        private void Awake()
        {
            _soundDictionary = new Dictionary<SoundType, AudioClip>();
            foreach (var entry in _soundEntries)
            {
                if (!_soundDictionary.ContainsKey(entry.SoundType) && entry.Clip != null)
                    _soundDictionary.Add(entry.SoundType, entry.Clip);
            }
        }

        public void PlaySound(SoundType soundType)
        {
            if (_soundDictionary.TryGetValue(soundType, out AudioClip clip) && clip != null)
                _audioSource.PlayOneShot(clip);
        }
    }
}