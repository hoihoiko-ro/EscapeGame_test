using UnityEngine;
using UnityEngine.UI;

public class InstallationController : MonoBehaviour
{
    public ObjectData objectData;

    public bool pb_Use { get; private set; } = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button InstallationButton = GetComponent<Button>();
        if (InstallationButton == null)
        {
            //Debug.LogError("このゲームオブジェクトにはButtonコンポーネントがありません！");
            return; // Imageコンポーネントがなければこれ以上処理しない
        }
        InstallationButton.onClick.AddListener(() => pb_Use = true);
        ChangeSprite();
    }

    void Update()
    {
        if (pb_Use)
        {
            //設置物にアイテムが設定されていれば
            if (objectData.NeedItem != null)
            {
                //アイテムが選択されていれば
                if (InventoryUI.inventoryUI.ButtonIndex >= 0 && InventoryUI.inventoryUI.ButtonIndex < InventoryUI.inventoryUI.itemList.Count)
                {
                    //アイテムが対応するものなら
                    if (objectData.NeedItem == InventoryUI.inventoryUI.itemList[InventoryUI.inventoryUI.ButtonIndex])
                    {
                        //次の設置物が設定されていれば
                        if (objectData.NextData != null)
                        {
                            //設置物を変更
                            objectData = (GimmickData)objectData.NextData;
                            ChangeSprite();
                        }
                        else
                        {
                            this.gameObject.SetActive(false);
                        }
                    }

                }
                
            }
            //設置物にアイテムが設定されていなければ
            else
            {
                //設置物を変更
                objectData = objectData.NextData;
                ChangeSprite();
            }
        }
    }

    public void ChangeSprite()
    {
        //スプライトにイメージを貼り付け
        Image InstallationImage = GetComponent<Image>();
        if (InstallationImage == null)
        {
            //Debug.LogError("このゲームオブジェクトにはImageコンポーネントがありません！");
            return; // Imageコンポーネントがなければこれ以上処理しない
        }

        if (objectData.sprite != null)
        {
            InstallationImage.sprite = objectData.sprite;
        }
        else
        {
            Debug.LogWarning("InstallationData.spriteがnullです。画像は設定されません。");
        }
    }

    private void LateUpdate()
    {
        pb_Use = false;
    }
}