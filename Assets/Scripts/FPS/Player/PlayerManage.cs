using UnityEngine;
using UnityEngine.UI;

namespace FPS.Player
{
    public class PlayerManage : MonoBehaviour
    {
        public static PlayerManage API; //单例接口
        public GameObject player;
        public GameObject hpBar;
        public GameObject bulletBar;
        public int currentHealth = 100;


        public int buffCount; //buff数量
        public int playerHealthMax = 100; //玩家最大生命值
        public int bulletMax = 15; //子弹最大数量
        public int currentBullet = 15; //当前子弹数量
        public int itemTakeCount; //物品数量
        public int enemyDefeatedCount; //敌人击败数量

        public float currentAttack = 20f; //当前攻击力
        public float timeUse; //使用时间

        public Image damageImage; //受伤图片
        public AudioSource audioSource; //音频源
        public AudioClip damageClip; //受伤音效

        public Transform firePos; //开火位置
        public GameObject bulletPrefab; //子弹预制体
        public GameObject gunModel; //枪模型
        public GameObject gunSelf; //自身隐藏的枪
        public GameObject rightHand; //VRTK右手
        public GameObject leftHand; //VRTK左手
        public GameObject headsetAlias; //VRTK头部别名
        public GameObject leftHandCollider; //左手碰撞盒
        public GameObject rightHandCollider; //右手碰撞盒

        private Image _hPFillAmount;
        private Image _bulletFillAmount;
        
        
        private void Start()
        {
            _hPFillAmount = hpBar.GetComponent<Image>();
            _bulletFillAmount = bulletBar.GetComponent<Image>();
            gunSelf.SetActive(false);
            rightHand.SetActive(true);
        }

        private void Awake()
        {
            API = this; //单例接口实例化
            Cursor.visible = false; //显示鼠标
            Cursor.lockState = CursorLockMode.Locked; //解锁鼠标
        }

        private void Update()
        {
            UIChange();
            Victory();
        }

        /// <summary>
        /// 判断是否是玩家 检测的是右手的碰撞盒
        /// </summary>
        /// <param name="other">右手的基础碰撞盒，无标签</param>
        /// <returns>如果有碰撞，返回真</returns>
        public bool IsPlayerRightHand(Collider other)
        {
            return other.gameObject==rightHandCollider;//
        }

        /// <summary>
        /// 判断是否是玩家 检测的是左手的碰撞盒
        /// </summary>
        /// <param name="other">左手的基础碰撞盒，无标签</param>
        /// <returns>如果有碰撞，返回真</returns>
        public bool IsPlayerLeftHand(Collider other)
        {
            //碰撞的部分的父物体是否是左手
            return other.gameObject == leftHandCollider;
        }

        public void GunChangeFromRightHand()
        {
            gunSelf.SetActive(true);
            rightHand.SetActive(false);
        }

        private void Victory()
        {
            if (itemTakeCount >= 5)
            {
                timeUse = Time.time; //结束计时


                //   Cursor.visible = true; //显示鼠标
                //    Cursor.lockState = CursorLockMode.None; //解锁鼠标
            }
        }

        private void UIChange()
        {
            _hPFillAmount.fillAmount = (float)currentHealth / playerHealthMax; //生命条变化
            _bulletFillAmount.fillAmount = (float)currentBullet / bulletMax; //子弹条变化
        }

        /// <summary>
        /// player受到攻击
        /// </summary>
        public void PlayerTakeDamage(int damage)
        {
            currentHealth -= damage; //玩家生命值减少
            audioSource.clip = damageClip; //音效 
            audioSource.Play(); //播放音效
            damageImage.color = new Color(1, 0, 0, 0.1f); //受伤图片颜色
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, 5f * Time.deltaTime); //受伤图片颜色渐变
            if (currentHealth > 0) return; //如果玩家生命值小于等于0
            hpBar.SetActive(false); //生命条不活动
            bulletBar.SetActive(false); //子弹条不活动    
        }
    }
}