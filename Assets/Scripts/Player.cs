using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    Animator anime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (climbFlag1)
        {
            climbTime += Time.deltaTime;

            if (climbTime <= 1.0f)
            {
                transform.position += transform.forward * 1.0f * Time.deltaTime;
                transform.position += new Vector3(0, 1.0f * Time.deltaTime, 0);

            }
            else
            {
                rb.useGravity = true;
                moveFlag = true;
                climbFlag1 = false;
                climbTime = 0;
            }
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
            }
            else
            {
                transform.position += transform.forward * z / 3;
            }
            //ADキー、←→キーで方向を替える
            float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * angleSpeed;
            transform.Rotate(Vector3.up * x);

            if (climbFlag)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    moveFlag = false;
                    rb.useGravity = false;
                    climbFlag1 = true;
                }
            }
        }
        

    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            climbFlag = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            climbFlag = false;
        }
    }

}
