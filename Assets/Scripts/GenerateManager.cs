using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateManager : MonoBehaviour
{
    // ブロックのプレハブ
    public GameObject brockPrefab;

    // ブロックを生成する位置
    float pos = 0;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("BlockGenerate",0,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BlockGenerate()
    {
        pos++;
        Instantiate(brockPrefab, new Vector3(pos, 10, pos), Quaternion.identity);
    }

    
}
