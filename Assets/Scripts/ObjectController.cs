using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour
{
    public ObjectData objectData;

    public bool pb_Use { get; private set; } = false;

    void Start()
    {
        Button ObjectButton = GetComponent<Button>();
        if (ObjectButton == null)
        {
            //Debug.LogError("このゲームオブジェクトにはButtonコンポーネントがありません！");
            return; // Imageコンポーネントがなければこれ以上処理しない
        }
        ObjectButton.onClick.AddListener(() => pb_Use = true);
        ChangeSprite();
    }

    void Update()
    {
        if (pb_Use)
        {
            pb_Use = false;
            objectData.Use(this);
        }
    }

    public void ChangeSprite()
    {
        //スプライトにイメージを貼り付け
        Image ObjectImage = GetComponent<Image>();
        if (ObjectImage == null)
        {
            //Debug.LogError("このゲームオブジェクトにはImageコンポーネントがありません！");
            return; // Imageコンポーネントがなければこれ以上処理しない
        }

        if (objectData.sprite != null)
        {
            ObjectImage.sprite = objectData.sprite;
        }
        else
        {
            Debug.LogWarning("ObjectData.spriteがnullです。画像は設定されません。");
        }
    }
}