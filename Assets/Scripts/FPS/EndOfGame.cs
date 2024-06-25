using System.Collections;
using System.Collections.Generic;
using FPS.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FPS
{
    public class EndOfGame : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other) //
        {
            print("完成挑战");
            //TODO：替换为开启vrkit的UI组件
            BackLevelToMain();
        }

        public void BackLevelToMain()
        {
            SceneManager.LoadScene("1park");
        }
    }
}