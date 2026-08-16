using System.Collections; 
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {
    public Text GetText;
    public GameObject GetPanel;
    public Image GetImage;
    SystemUI systemUI;
    InventoryUI inventoryUI;

    // ゲームクリア時表示パネル
    public GameObject ClearPanel;

    // フェードインにかける時間（秒）
    [SerializeField] private float fadeDuration = 1.0f;

    public static Main main;

    private void Awake() {
        if (main == null) {
            main = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    void Start() {
        // コンポーネント取得
        systemUI = GetComponent<SystemUI>();
        inventoryUI = GetComponent<InventoryUI>();

        // 各パネル非表示
        if (ClearPanel != null) {
            ClearPanel.SetActive(false);
        }
    }

    void Update() {
        if (systemUI.pb_Back) {
            GetPanel.SetActive(false);
            return;
        }
    }

    public void GetItem(ItemData ItemData) {
        GetPanel.SetActive(true);
        GetText.text = $"{ItemData.name}: {ItemData.description}";

        GetImage.sprite = ItemData.sprite;
        inventoryUI.itemList.Add(ItemData);

        inventoryUI.UpdateUI();
    }

    // ゲームクリア処理
    public void GameClear() {
        // クリアパネルを表示してフェードインを開始
        ClearPanel.SetActive(true);
        StartCoroutine(FadeInClearPanel());
    }

    // Canvas Groupのalphaを少しずつ上げるコルーチン
    private IEnumerator FadeInClearPanel() {
        // ClearPanelからCanvasGroupを取得（無ければ自動追加）
        CanvasGroup canvasGroup = ClearPanel.GetComponent<CanvasGroup>();
        if (canvasGroup == null) {
            canvasGroup = ClearPanel.AddComponent<CanvasGroup>();
        }

        // 初期状態は完全透明
        canvasGroup.alpha = 0f;

        float elapsedTime = 0f;

        // 設定した時間（fadeDuration）をかけて α値を 0 から 1 に増加させる
        while (elapsedTime < fadeDuration) {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null; // 1フレーム待機
        }

        // 最後に確実に1.0（完全不透明）にする
        canvasGroup.alpha = 1f;
    }
}