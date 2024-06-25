using FPS.Player;
using UnityEngine;

namespace BUFF
{
    public class BuffHealth : MonoBehaviour
    {
        private AudioSource _buffHealthAudio;
        private const int HealthUp = 20;

        private void OnTriggerEnter(Collider other)
        {
            if (!PlayerManage.API.IsPlayerLeftHand(other)) return;
            PlayerManage.API.buffCount++;
            _buffHealthAudio.Play ();
            //audioSource.PlayOneShot(BUFFAudio);
            print("生命恢复了！");
            PlayerManage.API.currentHealth += HealthUp;

            Destroy(this.gameObject,0.5f);
        }
        void Awake ()
        {//初始化
            _buffHealthAudio = GetComponent<AudioSource>();
        }

    }
}
