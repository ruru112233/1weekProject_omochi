using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mainCamera, rotationCamera;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCamera.SetActive(true);
        rotationCamera.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
