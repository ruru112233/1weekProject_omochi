﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFlag2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.check2Flag = true;

            if (transform.childCount != 0)
            {
                AudioManager.instance.PlaySE(0);
                GameObject check = transform.GetChild(0).gameObject;
                Destroy(check);
            }
        }
    }
}
