using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GenerateManager : MonoBehaviour
{
    // ブロックのプレハブ
    public GameObject brockPrefab, goalPrefab;

    byte[][] blocks =
        {
            new byte [] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            new byte [] { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            new byte [] { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            new byte [] { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            new byte [] { 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            new byte [] { 0, 0, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            new byte [] { 0, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            new byte [] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            new byte [] { 0, 0, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            new byte [] { 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            new byte [] { 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            new byte [] { 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            new byte [] { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            new byte [] { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            new byte [] { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            new byte [] { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },

        };

    byte[][] blocks2 =
        {
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new byte [] { 0, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new byte [] { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new byte [] { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
            new byte [] { 0, 0, 0, 0, 1, 0, 0, 1, 0, 0 },
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new byte [] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new byte [] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },

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
        //InvokeRepeating("BlockGenerate",0,1.0f);
        //InvokeRepeating("BlockGenerate2", 0.5f, 1.0f);
        //InvokeRepeating("BlockGenerate5",0,0.5f);
        //InvokeRepeating("BlockGenerate4", 3, 0.5f);
        Invoke("BlockGenerate5", 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
            for (int i = pos2; i < pos2 + 1; i++)
            {
                for (int j = 0; j < blocks2[i].Length; j++)
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
        StartCoroutine(BlockCol1());

    }

    IEnumerator BlockCol1()
    {
        float waitTime = 0.2f;

        int startPos = 1;
        int endPos = 2;

        Block1Tmp(0,startPos, endPos);

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
            Block1Tmp(0, startPos, endPos);
        }

        yield return new WaitForSeconds(1.5f);

        startPos++;
        endPos++;

        for (int i = 0; i < 3; i++)
        {
            Block1Tmp(0, startPos, endPos);
        }

        yield return new WaitForSeconds(1.5f);

        startPos++;
        endPos++;

        for (int i = 0; i < 4; i++)
        {
            Block1Tmp(0, startPos, endPos);
        }

        yield return new WaitForSeconds(1.5f);

        startPos++;
        endPos++;

        for (int i = 0; i < 3; i++)
        {
            Block1Tmp(0, startPos, endPos);
        }

        yield return new WaitForSeconds(1.5f);

        startPos++;
        endPos++;

        for (int i = 0; i < 2; i++)
        {
            Block1Tmp(0, startPos, endPos);
        }

        yield return new WaitForSeconds(1.5f);
                
        for (int i = 0; i < 2; i++)
        {
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
            Block1Tmp(1, startPos, endPos);
        }

        for (int i = 0; i < 4; i++)
        {
            Block1Tmp(2, startPos, endPos);
        }

        yield return new WaitForSeconds(waitTime);

        startPos--;
        endPos--;

        for (int i = 0; i < 2; i++)
        {
            Block1Tmp(1, startPos, endPos);
        }

        yield return new WaitForSeconds(2.0f);

        GoalTmp(2, golsStartPos, goalEndPos);



    }


    void Block1Tmp(int lineNo, int startPos, int endPos)
    {
        int count = 0;

        if (count < count + 1 && count < 1)
        {
            for (int i = lineNo; i < lineNo + 1; i++)
            {
                for (int j = count + startPos; j < count+ endPos; j++)
                {
                    if (blocks[i][j] == 1)
                    {
                        Instantiate(brockPrefab, new Vector3(j, 10, i), Quaternion.identity);
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
