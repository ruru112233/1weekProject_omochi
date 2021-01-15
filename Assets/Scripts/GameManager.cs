using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject mainCamera, rotationCamera;

    public GameObject noboruText;

    public GameObject ganerateManager;

    public GameObject gameClear, gameOver;

    public GameObject menu;

    public Stage1 stage1;

    public bool noboruFlag = false;

    public bool check1Flag = false;
    public bool check2Flag = false;
    public bool check3Flag = false;
    public bool check4Flag = false;
    public bool check5Flag = false;

    public bool commentEnd = false;

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
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        rotationCamera = GameObject.FindGameObjectWithTag("RotationCamera");
        noboruText = GameObject.FindGameObjectWithTag("Noboru");

        mainCamera.SetActive(true);
        rotationCamera.SetActive(false);

        if (menu != null)
        {
            menu.SetActive(true);
        }

        if (gameClear != null) gameClear.SetActive(false);
        if (gameOver != null) gameOver.SetActive(false);

        noboruText.SetActive(false);
        check1Flag = false;
        check2Flag = false;
        check3Flag = false;
        check4Flag = false;
        check5Flag = false;

        AudioManager.instance.PlayBGM(0);

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

        // リトライ
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

}
