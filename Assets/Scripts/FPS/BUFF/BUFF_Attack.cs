using FPS.Player;
using UnityEngine;

namespace FPS.BUFF
{
    public class BuffAttack : MonoBehaviour
    {

        private AudioSource _buffAttackAudio;
    
        private void OnTriggerEnter(Collider other)
        {
            if (!PlayerManage.API.IsPlayerLeftHand(other)) return;
            //audioSource.PlayOneShot(BUFFAudio);
            print("攻击力提升了！");
            PlayerManage.API.buffCount ++;
            _buffAttackAudio.Play ();
            PlayerManage.API.currentAttack += 10;
            Destroy(this.gameObject,0.5F);
        }

        // Start is called before the first frame update
        void Start()
        {
            _buffAttackAudio = GetComponent<AudioSource>();
        }

    }
}
