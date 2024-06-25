using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject PeopleCam1;
    public GameObject CarCam2;
    private bool isCaring = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isCaring)
        {
            PeopleCam1.SetActive(false);
            CarCam2.SetActive(true);
            Invoke("ExitCar", 10f);
        }
    }
    public void ExitCar()
    {
        isCaring = false;
        CarCam2.SetActive(false);
        PeopleCam1.SetActive(true);
    }
}
