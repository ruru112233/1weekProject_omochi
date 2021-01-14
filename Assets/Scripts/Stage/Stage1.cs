using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Stage1 : MonoBehaviour
{
    // ブロックのプレハブ
    public GameObject brockPrefab, goalPrefab, checkPrefab, tagNashi;

    // 右上のブロックマップ
    byte[][] blocks =
        {
            //            1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17
            new byte [] { 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 1
            new byte [] { 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 2
            new byte [] { 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 3
            new byte [] { 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 4
            new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 5
            new byte [] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 6
            new byte [] { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 7
            new byte [] { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 8
            new byte [] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 }, // 9
            new byte [] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 }, // 10
            new byte [] { 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 11
            new byte [] { 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 12
            new byte [] { 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 13
            new byte [] { 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 14
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 15
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 16

        };

    byte[][] blocksA =
        {
            //            1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17
            new byte [] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 1
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 2
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 3
            new byte [] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 4
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 5
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 6
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 7
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 8
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 4, 1, 0, 0, 0, 0, 0, 0, 0, 0 }, // 9
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 4, 1, 0, 0, 0, 0, 0, 0, 0, 0 }, // 10
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 11
            new byte [] { 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 12
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 13
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 14
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 15
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 16

        };

    byte[][] blocksB =
        {
            //            1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 1
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 2
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 3
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 4
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 5
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 6
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 7
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 8
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 2, 0, 0, 0, 0, 0, 0 }, // 9
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 2, 0, 0, 0, 0, 0, 0 }, // 10
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 11
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 12
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 13
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 14
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 15
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 16

        };

    byte[][] blocksC =
        {
            //            1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 1
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 2
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 3
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 4
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 5
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 6
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 7
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 8
            new byte [] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 9
            new byte [] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 10
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 11
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 12
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 13
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 14
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 15
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 16
        };

    // 左下のブロックマップ
    byte[][] blocks2 =
        {
            //           17 16 15 14 13 12 11 10  9  8  7  6  5  4  3  2  1
          　new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1 }, // 1
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1 }, // 2
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 1 }, // 3
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 }, // 4
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 }, // 5
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 3, 0, 0, 1 }, // 6
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 }, // 7
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 }, // 8
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1 }, // 9
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 10
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 11
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 12
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 13
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 14
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 15
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 16
        };


    // ブロックを生成する位置
    int pos1 = 0;
    int pos2 = 0;
    int pos3 = 0;
    int pos4 = 0;
    int pos5 = 0;

    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("BlockGenerate",0,0.5f);
        InvokeRepeating("BlockGenerateA", 1, 0.5f);
        InvokeRepeating("BlockGenerateB", 2, 0.5f);
        InvokeRepeating("BlockGenerate2", 0, 0.5f);
        //InvokeRepeating("BlockGenerate5",0,0.5f);
        //InvokeRepeating("BlockGenerate4", 3, 0.5f);
        //Invoke("BlockGenerate5", 0);

        StartCoroutine(BlockGenerateC());

    }

    // Update is called once per frame
    void Update()
    {

    }

    // 右上
    void BlockGenerate()
    {
        if (pos1 < blocks.Length)
        {
            for (int i = pos1; i < pos1 + 1; i++)
            {
                for (int j = 0; j < blocks[i].Length; j++)
                {
                    if (blocks[i][j] == 1)
                    {
                        Instantiate(brockPrefab, new Vector3(j + 1, 10, i), Quaternion.identity);
                    }
                    
                }

            }
            pos1++;
        }
    }

    // 右上A
    void BlockGenerateA()
    {
        if (pos2 < blocksA.Length)
        {
            for (int i = pos2; i < pos2 + 1; i++)
            {
                for (int j = 0; j < blocksA[i].Length; j++)
                {
                    if (blocksA[i][j] == 1)
                    {
                        Instantiate(brockPrefab, new Vector3(j + 1, 10, i), Quaternion.identity);
                    }
                    else if (blocksA[i][j] == 4)
                    {
                        Instantiate(tagNashi, new Vector3(j + 1, 10, i), Quaternion.identity);
                    }

                }

            }
            pos2++;
        }
    }

    // 右上B
    void BlockGenerateB()
    {
        if (pos3 < blocksB.Length)
        {
            for (int i = pos3; i < pos3 + 1; i++)
            {
                for (int j = 0; j < blocksB[i].Length; j++)
                {
                    if (blocksB[i][j] == 1)
                    {
                        Instantiate(brockPrefab, new Vector3(j + 1, 10, i), Quaternion.identity);
                    }
                    else if (blocksB[i][j] == 2)
                    {
                        Instantiate(goalPrefab, new Vector3(j + 1, 10, i), Quaternion.identity);
                    }
                    else if (blocksB[i][j] == 3)
                    {
                        Instantiate(checkPrefab, new Vector3(j + 1, 10, i), Quaternion.identity);
                    }
                }
            }
            pos3++;
        }
    }

    // 右上C
    IEnumerator BlockGenerateC()
    {
        yield return new WaitUntil(() => GameManager.instance.check1Flag);

        for (int i = 0; i < blocksC.Length; i++)
        {
            for (int j = 0; j < blocksC[i].Length; j++)
            {
                if (blocksC[i][j] == 1)
                {
                    Instantiate(brockPrefab, new Vector3(j + 1, 10, i), Quaternion.identity);
                }
                else if (blocksC[i][j] == 2)
                {
                    Instantiate(goalPrefab, new Vector3(j + 1, 10, i), Quaternion.identity);
                }
                else if (blocksC[i][j] == 3)
                {
                    Instantiate(checkPrefab, new Vector3(j + 1, 10, i), Quaternion.identity);
                }

            }

        }
    }

    // 左下
    void BlockGenerate2()
    {
        if (pos4 < blocks2.Length)
        {
            for (int i = pos4; i < pos4 + 1; i++)
            {
                for (int j = blocks2[i].Length - 1 ; j >= 0 ; j--)
                {
                    if (blocks2[i][j] == 1)
                    {
                        Instantiate(brockPrefab, new Vector3(-i - 1, 10,  j - 18), Quaternion.identity);
                    }
                    else if (blocks2[i][j] == 2)
                    {
                        Instantiate(goalPrefab, new Vector3(-i - 1, 10, j - 18), Quaternion.identity);
                    }
                    else if (blocks2[i][j] == 3)
                    {
                        Debug.Log("111");
                        Instantiate(checkPrefab, new Vector3(-i - 1, 10, j - 18), Quaternion.identity);
                    }

                }
            }
            pos4++;
        }
    }

    void BlockGenerate3()
    {
        if (pos3 < pos3 + 1 && pos3 < 8)
        {
            for (int i = 0; i < 1; i++)
            {
                for (int j = pos3 + 1; j < pos3 + 2; j++)
                {
                    if (blocks[i][j] == 1)
                    {
                        Instantiate(brockPrefab, new Vector3(j, 10, i), Quaternion.identity);
                    }
                }

            }
            pos3++;
        }

    }

    void BlockGenerate4()
    {
        if (pos4 < pos4 + 1 && pos4 < 1)
        {
            for (int i = 0; i < 1; i++)
            {
                for (int j = pos4 + 5; j < pos4 + 6; j++)
                {
                    if (blocks[i][j] == 1)
                    {
                        Instantiate(brockPrefab, new Vector3(j, 10, i), Quaternion.identity);
                    }
                }

            }
            pos4++;
        }

    }

    void BlockGenerate5()
    {
        int startPos = 1;
        int endPos = 2;

        Block1Tmp(0, startPos, endPos);

        //StartCoroutine(BlockCol1());

    }

    IEnumerator BlockCol1()
    {
        float waitTime = 0.2f;

        int startPos = 1;
        int endPos = 2;

        Block1Tmp(0, startPos, endPos);

        yield return new WaitForSeconds(waitTime);

        startPos++;
        endPos++;

        Block1Tmp(0, startPos, endPos);

        yield return new WaitForSeconds(waitTime);

        startPos++;
        endPos++;

        Block1Tmp(0, startPos, endPos);

        yield return new WaitForSeconds(waitTime);

        startPos++;
        endPos++;

        Block1Tmp(0, startPos, endPos);

        yield return new WaitForSeconds(waitTime);

        startPos++;
        endPos++;

        Block1Tmp(0, startPos, endPos);

        yield return new WaitForSeconds(waitTime);

        startPos++;
        endPos++;

        Block1Tmp(0, startPos, endPos);

        yield return new WaitForSeconds(waitTime);

        startPos++;
        endPos++;

        Block1Tmp(0, startPos, endPos);

        yield return new WaitForSeconds(waitTime);

        startPos++;
        endPos++;

        Block1Tmp(0, startPos, endPos);

        yield return new WaitForSeconds(waitTime);

        startPos++;
        endPos++;

        Block1Tmp(0, startPos, endPos);

        yield return new WaitForSeconds(waitTime);

        Block1Tmp(0, 7, 8);

        yield return new WaitForSeconds(waitTime);

        startPos++;
        endPos++;

        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(waitTime);
            Block1Tmp(0, startPos, endPos);
        }

        yield return new WaitForSeconds(1.5f);

        startPos++;
        endPos++;

        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(waitTime);
            Block1Tmp(0, startPos, endPos);
        }

        yield return new WaitForSeconds(1.5f);

        startPos++;
        endPos++;

        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(waitTime);
            Block1Tmp(0, startPos, endPos);
        }

        yield return new WaitForSeconds(1.5f);

        startPos++;
        endPos++;

        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(waitTime);
            Block1Tmp(0, startPos, endPos);
        }

        yield return new WaitForSeconds(1.5f);

        startPos++;
        endPos++;

        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(waitTime);
            Block1Tmp(0, startPos, endPos);
        }

        yield return new WaitForSeconds(1.5f);

        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(waitTime);
            Block1Tmp(1, startPos, endPos);
        }

        yield return new WaitForSeconds(1.5f);

        startPos--;
        endPos--;

        Block1Tmp(1, startPos, endPos);

        yield return new WaitForSeconds(waitTime);

        startPos--;
        endPos--;

        int golsStartPos = startPos;
        int goalEndPos = endPos;

        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(waitTime);
            Block1Tmp(1, startPos, endPos);
        }

        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(waitTime);
            Block1Tmp(2, startPos, endPos);
        }

        yield return new WaitForSeconds(waitTime);

        /*
        startPos--;
        endPos--;

        for (int i = 0; i < 2; i++)
        {
            Block1Tmp(1, startPos, endPos);
        }

        yield return new WaitForSeconds(2.0f);

        GoalTmp(2, golsStartPos, goalEndPos);
        */


    }


    void Block1Tmp(int lineNo, int startPos, int endPos)
    {
        int count = 0;

        if (count < count + 1 && count < 1)
        {
            for (int i = lineNo; i < lineNo + 1; i++)
            {
                for (int j = count + startPos; j < count + endPos; j++)
                {
                    if (blocks[i][j] == 1)
                    {
                        Instantiate(brockPrefab, new Vector3(-i, 10, -j), Quaternion.identity);
                    }
                }

            }
            count++;
        }
    }

    void GoalTmp(int lineNo, int startPos, int endPos)
    {
        int count = 0;

        if (count < count + 1 && count < 1)
        {
            for (int i = lineNo; i < lineNo + 1; i++)
            {
                for (int j = count + startPos; j < count + endPos; j++)
                {
                    if (blocks[i][j] == 1)
                    {
                        Instantiate(goalPrefab, new Vector3(j, 10, i), Quaternion.identity);
                    }
                }

            }
            count++;
        }
    }


}