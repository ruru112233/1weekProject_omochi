using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void Stage1()
    {
        SceneManager.LoadScene("Stage1Scene");
    }

    public void Stage2()
    {
        SceneManager.LoadScene("Stage2Scene");
    }

   
}
