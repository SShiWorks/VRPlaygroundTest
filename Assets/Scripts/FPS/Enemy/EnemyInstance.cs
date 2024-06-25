using System;
using System.Collections;
using FPS.Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FPS.Enemy
{
    public class EnemyInstance : MonoBehaviour
    {
        public GameObject enemyPrefab; // 敌人物体预制
        public float spawnTime = 3f; // 敌人出生间隔时间
        public Transform[] spawnPoints; //出生点
        public int enemyCountMax = 5; //最大敌人数量
        public Transform posParent;
        private void Start()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            var enemyCount = +1;
            if (enemyCountMax < enemyCount) yield return new WaitForSeconds(1);
            // 玩家已死，不创建了
            if (PlayerManage.API.currentHealth <= 0f) //如果玩家死亡
            {
                yield return new WaitForSeconds(spawnTime); //等待
            }

            // 随机出生点索引
            var spawnPointIndex = Random.Range(0, spawnPoints.Length);
            // 创建敌人
            var enemyA = Instantiate(
                enemyPrefab,
                spawnPoints[spawnPointIndex].position,
                spawnPoints[spawnPointIndex].rotation);
            enemyA.transform.parent = posParent;
            yield return new WaitForSeconds(spawnTime); //等待
        }
    }
}