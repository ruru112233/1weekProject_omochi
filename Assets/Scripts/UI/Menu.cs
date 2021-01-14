using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    RectTransform rct;

    float sizeY = 100;

    public GameObject titleText, commentText;

    bool commentEnd = false;

    Text tt; // メニュータイトルのテキスト
    Text ct; // メニューコメントのテキスト

    int commentCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rct = GetComponent<RectTransform>();
        titleText.SetActive(false);
        commentText.SetActive(false);

        StartCoroutine(ViewText());
    }

    // Update is called once per frame
    void Update()
    {
        sizeY += Time.deltaTime * 350 + 2.5f;
        if (sizeY <= 470)
        {
            rct.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 780);
            rct.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, sizeY);
        }
        else
        {
            sizeY = 470;
        }

        string kaigyouWin = "\r\n";
        string kaigyouMac = "\n";

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            commentCount++;
        }

        if (tt != null && ct != null)
        {
            if (commentCount == 0)
            {
                if (SystemInfo.operatingSystem.Contains("Windows"))
                {
                    tt.text = "移動";
                    ct.text = "移動方法の説明です。" + kaigyouWin +
                              "↑ 前進" + kaigyouWin +
                              "↓ 後退" + kaigyouWin +
                              "→ 右側へ向く" + kaigyouWin +
                              "← 左側へ向く" + kaigyouWin;

                }

                if (SystemInfo.operatingSystem.Contains("Mac"))
                {
                    tt.text = "移動";
                    ct.text = "移動方法の説明です。" + kaigyouMac +
                              "↑ 前進" + kaigyouMac +
                              "↓ 後退" + kaigyouMac +
                              "→ 右側へ向く" + kaigyouMac +
                              "← 左側へ向く" + kaigyouMac;
                    ;
                }
            }

            if (commentCount == 1)
            {
                if (SystemInfo.operatingSystem.Contains("Windows"))
                {
                    tt.text = "視点切り替え";
                    ct.text = "視点の切り替えについて説明します。" + kaigyouWin +
                        "Qキー 右回転" + kaigyouWin +
                              "Eキー 左回転" + kaigyouWin +
                              "Rキー 元に戻す" + kaigyouWin;
                }

                if (SystemInfo.operatingSystem.Contains("Mac"))
                {
                    tt.text = "視点切り替え";
                    ct.text = "視点の切り替えについて説明します。" + kaigyouMac +
                              "Qキー 右回転" + kaigyouMac +
                              "Eキー 左回転" + kaigyouMac +
                              "Rキー 元に戻す" + kaigyouMac;
                }
            }

            if (commentCount == 2)
            {
                commentEnd = true;
            }
        }

    }

    IEnumerator ViewText()
    {
        yield return new WaitForSeconds(0.8f);

        titleText.SetActive(true);
        commentText.SetActive(true);

　　　　tt = titleText.GetComponent<Text>();
        ct = commentText.GetComponent<Text>();

        yield return new WaitUntil(() => commentEnd);

        sizeY = 100;

        titleText.SetActive(false);
        commentText.SetActive(false);
        gameObject.SetActive(false);

    }
}
