﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    // キャラの移動
    float speed = 2.0f;
    Rigidbody rb;
    bool moveFlag = true;

    // 登る
    bool climbFlag = false;
    bool climbFlag1 = false;
    float climbTime = 0;

    //方向転換のスピード
    float angleSpeed = 200;

    // ステージスタート位置
    GameObject startPos;

    // 死んだときに生成するオブジェクト
    public GameObject deadObj;

    Animator anime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anime = GetComponent<Animator>();
        startPos = GameObject.Find("StartPos");
    }

    // Update is called once per frame
    void Update()
    {
        // 死んだ時のテスト用
        if (Input.GetKeyDown(KeyCode.I))
        {
            Instantiate(deadObj, 
                        new Vector3(transform.position.x, transform.position.y, transform.position.z), 
                        Quaternion.identity);
            transform.position = 
                new Vector3(startPos.transform.position.x,startPos.transform.position.y,startPos.transform.position.z);
            transform.rotation =
                Quaternion.Euler(startPos.transform.rotation.x, startPos.transform.rotation.y, startPos.transform.rotation.z);
        }

        if (climbFlag && moveFlag)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                moveFlag = false;
                rb.useGravity = false;
                climbFlag1 = true;
                anime.SetTrigger("Climb");
            }
        }

        if (climbFlag1)
        {
            
            climbTime += Time.deltaTime;

            if (climbTime <= 1.0f)
            {
                transform.position += transform.forward * 2.0f * Time.deltaTime;
                transform.position += new Vector3(0, 1.1f * Time.deltaTime, 0);
            }
            else
            {
                rb.useGravity = true;
                moveFlag = true;
                climbFlag1 = false;
                climbTime = 0;
            }
        }

        // ゲームオーバー
        if (transform.position.y <= 0.6f)
        {
            GameManager.instance.gameOver.SetActive(true);
            StartCoroutine(GameOver());
        }
    }

    private void FixedUpdate()
    {
        if (moveFlag)
        {
            //WSキー、↑↓キーで移動する
            float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
            //前進の後退
            //後退は前進の3分の1のスピードになる
            if (z > 0)
            {
                transform.position += transform.forward * z;
                anime.SetBool("Run", true);
                anime.SetBool("Walk", false);
            }
            else if (z < 0)
            {
                transform.position += transform.forward * z / 3;
                anime.SetBool("Run", false);
                anime.SetBool("Walk", true);

            }
            else
            {
                anime.SetBool("Run", false);
                anime.SetBool("Walk", false);
            }

            //ADキー、←→キーで方向を替える
            float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * angleSpeed;
            transform.Rotate(Vector3.up * x);

        }
        
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            climbFlag = true;
            GameManager.instance.noboruFlag = true;
        }

        if (other.gameObject.tag == "Goal")
        {

            GameManager.instance.gameClear.SetActive(true);

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            climbFlag = false;
            GameManager.instance.noboruFlag = false;
        }
    }

}
