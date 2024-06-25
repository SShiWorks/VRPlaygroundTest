using FPS.Enemy;
using FPS.Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace FPS
{
    public class UIManager : MonoBehaviour
    {
        public GameObject popPanel; //弹出面板
        public GameObject textTip; //提示文本
        public GameObject army; //提示文本

        public void InvokeClick()
        {
            Time.timeScale = 1f;
            Invoke(nameof(CloseAllUIPanel), 0.1f);
        }
        private void CloseAllUIPanel()
        {
            popPanel.SetActive(false);
        }

        private void NextG()
        {
            army.SetActive(true); //开启提示
            textTip.SetActive(true); //开启提示
        }


        // Update is called once per frame
        void Update()
        {
            if (PlayerManage.API.itemTakeCount >= 5) //如果硬币数量大于等于5
            {
                NextG(); //开启提示
            }
        }
        private void Start()
        {
            //Time.timeScale = 0;
        }
    }
}