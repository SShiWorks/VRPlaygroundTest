using System.Collections;
using System.Collections.Generic;
using FPS.Player;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    private float _timeVic; //胜利条件
    private float _itemVic; //胜利条件
    private float _enemyVic; //胜利条件
    private float _healthyVic; //胜利条件
    private float _buffVic; //胜利条件

    public Text txtTimeVic;
    public Text txtItemVic;
    public Text txtEnemyVic;

    public Text txtHealthyVic;
    public Text txtBuffvic;

    // Start is called before the first frame update
    void Awake()
    {
        _timeVic = PlayerManage.API.timeUse; //胜利条件
        _itemVic = PlayerManage.API.itemTakeCount;
        _enemyVic = PlayerManage.API.enemyDefeatedCount;
        _healthyVic = PlayerManage.API.currentHealth;
        _buffVic = PlayerManage.API.buffCount;

        _timeVic = (int)(500 - _timeVic); //胜利条件
        _itemVic *= 2;
        _enemyVic = (float)(_enemyVic * 3.5);
        _healthyVic = (int)(_healthyVic * 0.8);
        _buffVic = (float)(_buffVic * 2.5);
    }

    // Update is called once per frame
    void Update()
    {
        txtEnemyVic.text = _enemyVic.ToString(); //胜利条件
        txtItemVic.text = _itemVic.ToString();
        txtTimeVic.text = _timeVic.ToString();
        txtHealthyVic.text = _healthyVic.ToString();
        txtBuffvic.text = _buffVic.ToString();
    }
}