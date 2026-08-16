using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public ItemData ItemData; // Unityエディターで割り当てるか、ここで初期化
    
    public bool pb_Get { get; private set; } = false;
    public void Start()
    {
        Button itemButton = GetComponent<Button>();
        if (itemButton == null)
        {
            //Debug.LogError("このゲームオブジェクトにはButtonコンポーネントがありません！");
            return; // Imageコンポーネントがなければこれ以上処理しない
        }
        itemButton.onClick.AddListener(() => pb_Get = true);
        //スプライトにイメージを貼り付け
        Image itemImage = GetComponent<Image>();
        if (itemImage == null)
        {
            //Debug.LogError("このゲームオブジェクトにはImageコンポーネントがありません！");
            return; // Imageコンポーネントがなければこれ以上処理しない
        }

        if (ItemData.sprite != null)
        {
            itemImage.sprite = ItemData.sprite;
        }
        else
        {
            Debug.LogWarning("ItemData.spriteがnullです。画像は設定されません。");
        }
    }

    private void Update()
    {
        if (pb_Get)
        {
            this.gameObject.SetActive(false);
            Main.main.GetItem(ItemData);
        }
    }

    void LateUpdate()
    {
        pb_Get = false;
    }
}