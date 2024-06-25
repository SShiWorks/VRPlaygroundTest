using System;
using System.Timers;
using FPS.Enemy;
using UnityEngine;

namespace FPS.Player
{
    public class Bullet : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            print("子弹碰撞！"+other.tag+" "+other.name);
            if (!other.gameObject.CompareTag("Enemy")) return;
            var damage = PlayerManage.API.currentAttack;
            var pos = transform.position;
            print("敌人受到了伤害！");
            other.gameObject.GetComponent<EnemyManage>().EnemyTakeDamage(damage, pos);
            Destroy(gameObject);
        }

        private float _timer;

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= 2)
            {
                Destroy(gameObject);
            }
        }
    }
}