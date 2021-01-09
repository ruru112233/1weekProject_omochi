using System.Collections;
using System.Collections.Generic;
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
        
    }

    private void FixedUpdate()
    {
        // 時計回り
        if (Input.GetKey(KeyCode.Q))
        {
            transform.RotateAround(target.transform.position, new Vector3(0, 1, 0), 20.0f * Time.deltaTime);
        }

        // 反時計回り
        if (Input.GetKey(KeyCode.E))
        {
            transform.RotateAround(target.transform.position, new Vector3(0, -1, 0), 20.0f * Time.deltaTime);
        }

    }
}
