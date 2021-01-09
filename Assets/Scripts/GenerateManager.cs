using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateManager : MonoBehaviour
{
    // ブロックのプレハブ
    public GameObject brockPrefab;

    short[][] blocks =
        {
            new short [] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            new short [] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0 },
            new short [] { 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
            new short [] { 0, 0, 0, 0, 0, 1, 1, 0, 0, 0 },
            new short [] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
            new short [] { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
            new short [] { 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
            new short [] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            new short [] { 0, 0, 0, 1, 1, 0, 0, 1, 0, 0 },
            new short [] { 0, 0, 0, 0, 1, 0, 0, 1, 0, 0 },
            new short [] { 0, 0, 0, 0, 1, 0, 0, 1, 0, 0 },
            new short [] { 0, 0, 0, 0, 1, 1, 1, 1, 0, 0 },
            new short [] { 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
            new short [] { 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
            new short [] { 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
            new short [] { 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },

        };

    short[][] blocks2 =
        {
            new short [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new short [] { 0, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
            new short [] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
            new short [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new short [] { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
            new short [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new short [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new short [] { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
            new short [] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
            new short [] { 0, 0, 0, 0, 1, 0, 0, 1, 0, 0 },
            new short [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new short [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new short [] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
            new short [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new short [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new short [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },

        };


    // ブロックを生成する位置
    short pos1 = 0;
    short pos2 = 0;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("BlockGenerate",0,1.0f);
        InvokeRepeating("BlockGenerate2", 0.5f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BlockGenerate()
    {

        if (pos1 < blocks.Length)
        {
            for (short i = pos1; i < pos1 + 1; i++)
            {
                for (short j = 0; j < blocks[i].Length; j++)
                {
                    if (blocks[i][j] == 1)
                    {
                        Instantiate(brockPrefab, new Vector3(j, 10, i), Quaternion.identity);
                    }

                }

            }
            pos1++;
        }
        
        
    }

    void BlockGenerate2()
    {

        if (pos2 < blocks2.Length)
        {
            for (short i = pos2; i < pos2 + 1; i++)
            {
                for (short j = 0; j < blocks2[i].Length; j++)
                {
                    if (blocks2[i][j] == 1)
                    {
                        Instantiate(brockPrefab, new Vector3(j, 10, i), Quaternion.identity);
                    }

                }

            }
            pos2++;
        }


    }



}
