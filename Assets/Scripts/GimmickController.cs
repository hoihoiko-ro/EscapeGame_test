using UnityEngine;
using UnityEngine.UI;

public class GimmickController : MonoBehaviour
{
    public GimmickData gimmickData;

    public bool pb_ChnageScene { get; private set; } = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button InstallationButton = GetComponent<Button>();
        if (InstallationButton == null)
        {
            //Debug.LogError("このゲームオブジェクトにはButtonコンポーネントがありません！");
            return; // Imageコンポーネントがなければこれ以上処理しない
        }
        InstallationButton.onClick.AddListener(() => pb_ChnageScene = true);
        ChangeSprite();
    }

    // Update is called once per frame
    void Update()
    {
        if (pb_ChnageScene)
        {
            PanelController.panel.ChnageScene(gimmickData.CameraPosition);
        }
    }

    void ChangeSprite()
    {
        //スプライトにイメージを貼り付け
        Image InstallationImage = GetComponent<Image>();
        if (InstallationImage == null)
        {
            //Debug.LogError("このゲームオブジェクトにはImageコンポーネントがありません！");
            return; // Imageコンポーネントがなければこれ以上処理しない
        }

        if (gimmickData.sprite != null)
        {
            InstallationImage.sprite = gimmickData.sprite;
        }
        else
        {
            Debug.LogWarning("InstallationData.spriteがnullです。画像は設定されません。");
        }
    }

    private void LateUpdate()
    {
        pb_ChnageScene = false;
    }
}