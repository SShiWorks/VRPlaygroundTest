using FPS.Player;
using UnityEngine;

namespace FPS.BUFF
{
    public class BuffBullet : MonoBehaviour
    {
        private AudioSource _buffBulletAudio;
    
        private void OnTriggerEnter(Collider other)
        {
            if (!PlayerManage.API.IsPlayerLeftHand(other)) return;
            PlayerManage.API.buffCount ++;
            _buffBulletAudio.Play ();
            print("子弹恢复了！");
            PlayerManage.API.currentBullet = PlayerManage.API.bulletMax;
            Destroy(gameObject,0.5f);
        }
        void Awake ()
        {//初始化
            _buffBulletAudio = GetComponent<AudioSource>();
        }

    }
}
