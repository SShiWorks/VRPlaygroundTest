using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class DoorController : MonoBehaviour
{
    public Transform doorLeft;
    public Transform doorRight;
    public float minAngle;
    public float maxAngle;
    public float angleSpeed;
    private bool isOpening;
    private bool isColsing;

    private void Update()
    {
        DealBoorMove();
    }

    private void DealBoorMove()
    {
        if (isOpening)
        {
            if (doorLeft.rotation.y < maxAngle)
            {
                doorLeft.Rotate(0, angleSpeed * Time.deltaTime, 0);
                doorRight.Rotate(0, -angleSpeed * Time.deltaTime, 0);
                if (doorLeft.rotation.y <= minAngle)
                {
                    isOpening = false;
                    doorLeft.Rotate(0, maxAngle, 0);
                    doorRight.Rotate(0, -maxAngle, 0);
                }
            }
        }

        if (isColsing)
        {
            if (doorLeft.rotation.y > minAngle)
            {
                doorLeft.Rotate(0, -angleSpeed * Time.deltaTime, 0);
                doorRight.Rotate(0, angleSpeed * Time.deltaTime, 0);
                if (doorLeft.rotation.y <= 0)
                {
                    isColsing = false;
                    doorLeft.Rotate(0, 0, 0);
                    doorRight.Rotate(0, 0, 0);
                }
            }
        }
    }

    public void TriggerOpen()
    {
        if (!isOpening)
        {
            isColsing = false;
            isOpening = true;
        }
    }

    /// <summary>
    /// 不满足开门条件时调用
    /// </summary>
    public void EndOpen()
    {
        isOpening = false;
        Invoke("TriggerClose", 2f);

    }
    public void TriggerClose()
    {
        isColsing = true;
    }

}