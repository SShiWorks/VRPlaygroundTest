using System.Collections;
using UnityEngine;

public class CarControll : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject carCamera;
    public GameObject playAliases;
    private float _timer;
    private bool _isCar;

    public Transform cachePlayer;
    public AudioClip carAudio;
    private AudioSource _audioSource;
    // Update is called once per frame
    void Update()
    {
        if (_isCar)
        {
            playAliases.transform.position = carCamera.transform.position;
            playAliases.transform.rotation = carCamera.transform.rotation;
            _timer += Time.deltaTime;
        }
        CameraReset();

    }
    private void Start()
    {
        _audioSource = cachePlayer.gameObject.AddComponent<AudioSource>();
        _audioSource.clip = carAudio;
        _audioSource.Play();
    }
    public void DriveCar()
    {
        _isCar = true;

    }
    private void CameraReset()
    {


        if (_timer > 10)
        {
            _isCar = false;
            playAliases.transform.SetPositionAndRotation(cachePlayer.position, cachePlayer.rotation);
            _timer = 0;
        }

    }
}
