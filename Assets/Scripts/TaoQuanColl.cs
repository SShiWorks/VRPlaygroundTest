using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaoQuanColl : MonoBehaviour
{
    public Text text;
    public int Score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Score.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TaoQuanObj")
        {
            Debug.Log("TaoQuanColl");
            Score += 1;

           Destroy(other.gameObject);
        }
    }
}
