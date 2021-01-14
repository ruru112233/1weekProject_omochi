﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mainCamera, rotationCamera;

    public GameObject noboruText;

    public GameObject ganerateManager;

    public GameObject menu;

    public Stage1 stage1;

    public bool noboruFlag = false;

    public bool check1Flag = false;
    public bool check2Flag = false;
    public bool check3Flag = false;
    public bool check4Flag = false;
    public bool check5Flag = false;

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
        menu.SetActive(true);
        noboruText.SetActive(false);
        check1Flag = false;
        check2Flag = false;
        check3Flag = false;
        check4Flag = false;
        check5Flag = false;
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
