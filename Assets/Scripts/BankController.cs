using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankController : MonoBehaviour
{

    private List<Button> ButtonList = new List<Button>();
    Button Enter;
    Button Clear;
    private int Passindex = 0;
    private int[] enteredPassword;
    private int[] correctPassword = { 1,2,3 };

    public bool pb_Enter { get; private set; } = false;
    public bool pb_Clear { get; private set; } = false;

    private void Start()
    {
        enteredPassword = new int[correctPassword.Length ];
        // 親オブジェクトのTransformコンポーネントを取得
        Transform parentTransform = this.transform;
        for(int i = 0; i < 10; i++)
        {
            int index = i;
            // 子オブジェクトのボタンコンポ―ネントを取得
            ButtonList.Add(parentTransform.GetChild(i).GetComponent<Button>());

            ButtonList[i].onClick.AddListener(() =>
            {
                if (Passindex >= enteredPassword.Length)
                {

                    ClearPassWord();
                }
                enteredPassword[Passindex] = index;
            } );
            
            ButtonList[i].onClick.AddListener(() => Passindex++);
        }
        Enter = parentTransform.GetChild(10).GetComponent<Button>();
        Enter.onClick.AddListener(() => pb_Enter = true);
        Clear = parentTransform.GetChild(11).GetComponent<Button>();
        Clear.onClick.AddListener(() => pb_Clear = true);

    }

    private void Update()
    {
        if(pb_Enter)
        {
            //パスワードと打ち込んだ数値の比較
            pb_Enter = false;
            // 入力されたパスワードの長さが正しいか確認
            if (Passindex == correctPassword.Length)
            {
                bool isCorrect = true;
                // 入力されたパスワードと正しいパスワードを比較
                for (int i = 0; i < correctPassword.Length; i++)
                {
                    if (enteredPassword[i] != correctPassword[i])
                    {
                        isCorrect = false;
                        break; // 一つでも異なればループを抜ける
                    }
                }

                if (isCorrect)
                {
                    Debug.Log("パスワードが一致しました！");
                    // パスワード一致時の処理
                    this.gameObject.SetActive(false);
                }
                else
                {
                    Debug.Log("パスワードが違います。");
                    // パスワード不一致時の処理
                }
            }
        }
        if (pb_Clear) 
        {
            //打ち込んだ数値の削除
            pb_Clear = false;
            ClearPassWord();
        }
    }
    void ClearPassWord()
    {
        Passindex = 0;
        for (int j = 0; j < enteredPassword.Length; j++)
        {
            enteredPassword[j] = 0;
        }
    }
}
