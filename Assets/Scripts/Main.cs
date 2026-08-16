using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Text GetText;
    public GameObject GetPanel;
    public Image GetImage;
    SystemUI systemUI;
    InventoryUI inventoryUI;

    public static Main main;

    private void Awake()
    {
        if (main == null)
        {
            main = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //コンポーネント取得
        systemUI = GetComponent<SystemUI>();
        inventoryUI = GetComponent<InventoryUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (systemUI.pb_Back)
        {
            GetPanel.SetActive(false);
            return;
        }
    }

    public void GetItem(ItemData ItemData)
    {
        GetPanel.SetActive(true);
        GetText.text = $"{ItemData.name}: {ItemData.description}";

        GetImage.sprite = ItemData.sprite;
        inventoryUI.itemList.Add(ItemData);

        inventoryUI.UpdateUI();
    }
}
