using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mainCamera, rotationCamera;

    public GameObject noboruText;

    public GameObject ganerateManager;

    public Stage1 stage1;

    public bool noboruFlag = false;

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
        rotationCamera.SetActive(false);
        noboruText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (noboruFlag)
        {
            noboruText.SetActive(true);
        }
        else
        {
            noboruText.SetActive(false);
        }
    }
}
