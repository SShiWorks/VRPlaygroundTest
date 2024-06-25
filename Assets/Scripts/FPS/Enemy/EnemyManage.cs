using FPS.Player;
using NUnit.Framework;
using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace FPS.Enemy
{
    /// <summary>
    /// 敌人管理
    /// </summary>
    public class EnemyManage : MonoBehaviour
    {
        private GameObject _playerPos; // 玩家位置变量.
        private NavMeshAgent _enemyNav; //敌人身上寻路组件
        private Animator _animator; //动画控制器
        private float _currentHealth = 100; //敌人当前血量
        public AudioClip deathClip; //死亡音效
        private AudioSource _enemyAudio; //音效
        private bool _isDead; //是否死亡
        private ParticleSystem _hitParticles; //受击效果
        private static readonly int Dead = Animator.StringToHash("Dead");
        public static EnemyManage API;
        public int enemyAttack = 10; //敌人攻击力
        public float attackCd = 1f; //攻击间隔
        private float _attackTimer; //计时器

        /// <summary>
        /// 每帧更新
        /// </summary>
        private void Update()
        {
            MoveToPlayer();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Start()
        {
            API = this;
            _enemyAudio = GetComponent<AudioSource>(); //音效
            _animator = GetComponent<Animator>(); //获取动画控制器
            _enemyNav = GetComponent<NavMeshAgent>(); //获取寻路组件
            _hitParticles = GetComponentInChildren<ParticleSystem>(); //特效物作为敌人的子物体，根据受击点调整位置
        }

        /// <summary>
        /// 移动到玩家
        /// </summary>
        private void MoveToPlayer()
        {
            _playerPos = PlayerManage.API.headsetAlias; //获取玩家位置
            // 如果主角和敌人都存活
            if (_currentHealth > 0 && PlayerManage.API.currentHealth > 0)
            {
                // 使用寻路组件朝玩家位置寻路
                _enemyNav.SetDestination(_playerPos.transform.position);
            }
            else
            {
                //主角或敌人死亡，停止寻路，禁用寻路组件
                _enemyNav.enabled = false;
            }
        }

        public void EnemyTakeDamage(float damage, Vector3 hitPoint)
        {
            if (_isDead) return;
            _currentHealth -= damage;
            //播放受击音效
            _hitParticles.transform.position = hitPoint;
            _hitParticles.Play();

            if (_currentHealth > 0) return;
            _enemyAudio.clip = deathClip;
            _enemyAudio.Play();
            PlayerManage.API.enemyDefeatedCount++;
            _animator.SetTrigger(Dead);
            Destroy(gameObject, 1.5f);
        }

        private void Attack()
        {
            if (Time.time - _attackTimer < attackCd) return;
            _attackTimer = Time.time;

            _animator.SetTrigger("Attack");
            PlayerManage.API.PlayerTakeDamage(enemyAttack);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!PlayerManage.API.IsPlayerLeftHand(other) || !PlayerManage.API.IsPlayerRightHand(other)) return;
            {
                Attack();
            }
        }
    }
}