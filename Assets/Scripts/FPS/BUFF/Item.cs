using System;
using FPS.Player;
using UnityEngine;

namespace FPS.BUFF
{
    public class Item : MonoBehaviour
    {
        private AudioSource _coinAudio; //硬币音效

        private void Start()
        {
            _coinAudio = GetComponent<AudioSource>(); //获取音效组件
        }

        private void OnTriggerEnter(Collider other)
        {
            print("按E键拾取");
            if (!PlayerManage.API.IsPlayerLeftHand(other)) return;
            _coinAudio.Play(); //播放音效
            PlayerManage.API.itemTakeCount++; //硬币数量+1
            print("现在有" + PlayerManage.API.itemTakeCount + "个硬币");
            Destroy(this.gameObject, 0.5F); //销毁硬币
        }
    }
}