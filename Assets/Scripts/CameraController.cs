using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            MainCameraOn();
        }
    }

    private void FixedUpdate()
    {
        // 時計回り
        if (Input.GetKey(KeyCode.Q))
        {
            MainCameraOFF();

            transform.RotateAround(target.transform.position, new Vector3(0, 1, 0), 60.0f * Time.deltaTime);

        }

        // 反時計回り
        if (Input.GetKey(KeyCode.E))
        {
            MainCameraOFF();
            transform.RotateAround(target.transform.position, new Vector3(0, -1, 0), 60.0f * Time.deltaTime);
        }

    }

    void MainCameraOn()
    {
        GameManager.instance.mainCamera.SetActive(true);
        GameManager.instance.rotationCamera.SetActive(false);
    }

    void MainCameraOFF()
    {
        GameManager.instance.mainCamera.SetActive(false);
        GameManager.instance.rotationCamera.SetActive(true);
    }
}
