using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // キャラの移動
    float speed = 2.0f;
    Rigidbody rb;

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
        
    }

    private void FixedUpdate()
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
    }
}
