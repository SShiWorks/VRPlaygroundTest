using FPS.Player;
using UnityEngine;

namespace FPS.BUFF
{
    public class BuffGun : MonoBehaviour
    {
        public AudioClip buffAudio;
        private AudioSource _audioSource;


        private void OnTriggerEnter(Collider other)
        {
            if (PlayerManage.API.IsPlayerRightHand(other))
            {
                if (PlayerManage.API.rightHand.activeSelf) //
                {
                    //
                    PlayerManage.API.GunChangeFromRightHand();
                    Destroy(gameObject, 0.3f);
                }
            }

            if (!PlayerManage.API.IsPlayerLeftHand(other)) return;
            print("枪支升级了！");
            _audioSource.clip = buffAudio;
            _audioSource.Play();
            PlayerManage.API.currentAttack += 20f;
            Destroy(gameObject, 0.5f);
        }

        // Start is called before the first frame update
        void Start()
        {
            _audioSource = GetComponent<AudioSource>() == null
                ? gameObject.AddComponent<AudioSource>()
                : GetComponent<AudioSource>();
        }
    }
}