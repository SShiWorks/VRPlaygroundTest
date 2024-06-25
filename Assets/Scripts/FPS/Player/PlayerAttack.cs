using System;
using UnityEngine;
using Zinnia.Action;

namespace FPS.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        private bool _isCouldFire;
        public GameObject couldFire;

        public void Fire(bool isFire)
        {
            _isCouldFire = couldFire.GetComponent<BooleanAction>().Value;
            print(_isCouldFire);
            if (!PlayerManage.API.gunSelf.activeSelf) return;
            if (!_isCouldFire) return;
            var bullet = Instantiate(PlayerManage.API.bulletPrefab, PlayerManage.API.firePos);
            //子弹的速度
            bullet.AddComponent<Rigidbody>().useGravity = false;
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 20;
            //_isCouldFire = false;
        }
    }
}