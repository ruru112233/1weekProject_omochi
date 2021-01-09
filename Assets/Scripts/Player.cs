using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x > 0)
        {
            x = 1;
        }
        else if (x < 0)
        {
            x = -1;
        }

        if (z > 0)
        {
            z = 1;
        }
        else if (z < 0)
        {
            z = -1;
        }


        if (x == 1.0f) transform.position += new Vector3(speed * Time.deltaTime, 0,0);
        if (x == -1.0f) transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        if (z == 1.0f) transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        if (z == -1.0f) transform.position -= new Vector3(0, 0, speed * Time.deltaTime);

    }
}
