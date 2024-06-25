using UnityEngine;

namespace FPS
{
    public class MusicManager : MonoBehaviour
    {
        private AudioSource _audioSource;//音频源
        public void Control_bgMUSIC()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.mute = !_audioSource.mute;
        }
    }
}
