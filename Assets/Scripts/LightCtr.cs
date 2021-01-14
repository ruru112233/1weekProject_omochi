using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCtr : MonoBehaviour
{
    public GameObject lightObj;

    // Start is called before the first frame update
    void Start()
    {
        lightObj.SetActive(false);

        StartCoroutine(LightOn());

    }

    IEnumerator LightOn()
    {
        yield return new WaitForSeconds(1.0f);

        lightObj.SetActive(true);
    }

}
