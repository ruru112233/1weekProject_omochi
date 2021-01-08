using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateManager : MonoBehaviour
{
    // ブロックのプレハブ
    public GameObject brockPrefab;

    int[][] blocks =
        {
            new int [] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            new int [] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0 },
            new int [] { 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
            new int [] { 0, 0, 0, 0, 0, 1, 1, 0, 0, 0 },
            new int [] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
            new int [] { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
            new int [] { 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
            new int [] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            new int [] { 0, 0, 0, 1, 1, 0, 0, 1, 0, 0 },
            new int [] { 0, 0, 0, 0, 1, 0, 0, 1, 0, 0 },
            new int [] { 0, 0, 0, 0, 1, 0, 0, 1, 0, 0 },
            new int [] { 0, 0, 0, 0, 1, 1, 1, 1, 0, 0 },
            new int [] { 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
            new int [] { 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
            new int [] { 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
            new int [] { 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },

        };


    // ブロックを生成する位置
    int pos = 0;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("BlockGenerate",0,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    void BlockGenerate()
    {
        pos++;
        Instantiate(brockPrefab, new Vector3(pos, 10, pos), Quaternion.identity);
    }
    */

    void BlockGenerate()
    {

        if (pos < blocks.Length)
        {
            for (int i = pos; i < pos + 1; i++)
            {
                for (int j = 0; j < blocks[i].Length; j++)
                {
                    if (blocks[i][j] == 1)
                    {
                        Instantiate(brockPrefab, new Vector3(j, 10, i), Quaternion.identity);
                    }

                }

            }
            pos++;
        }
        
        
    }




}
