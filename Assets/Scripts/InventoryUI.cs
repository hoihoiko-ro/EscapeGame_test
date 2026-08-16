using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    //生成するボタン
    public GameObject buttonPrefab;
    
    public GameObject InventoryPanel;

    public List<ItemData> itemList = new List<ItemData>();
    public int ButtonIndex { get; private set; } = -1;
    public static InventoryUI inventoryUI;
    private void Awake()
    {
        if (inventoryUI == null)
        {
            inventoryUI = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void UpdateUI()
    {

        //ボタン化したアイテム数
        int currentButtonCount = InventoryPanel.transform.childCount;
        int currentItemCount = itemList.Count;
        //取得したアイテム数 > ボタン化したアイテム数
        if (currentItemCount > currentButtonCount)
        {
            int num = currentItemCount - currentButtonCount;

            for (int i = 0; i < num; i++)
            {
                GameObject newButtonObject = Instantiate(buttonPrefab);
                newButtonObject.transform.SetParent(InventoryPanel.transform, false);
            }
        }
        //取得したアイテム数　< ボタン化したアイテム数
        else if (currentItemCount < currentButtonCount)
        {
            int num = currentButtonCount - currentItemCount;
            for(int i = 0; i < num; i++)
            {
                Destroy(InventoryPanel.transform.GetChild(i).gameObject);
            }
        }

        //ボタンパネルにアイテムのスプライトを表示

        for (int i = 0; i < currentItemCount; i++)
        {
            //ボタンにアイテム名を表示する。
            ItemData itemData = itemList[i];
            // パネルの子のボタン取得
            GameObject buttonObject = InventoryPanel.transform.GetChild(i).gameObject;
            GameObject UseImage = buttonObject.transform.Find("UseImage").gameObject;
            Image image = UseImage.GetComponent<Image>();
            image.sprite = itemData.sprite;
  
            //作成したボタンに関数紐づけ
            Button button = buttonObject.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            int index = i;
            button.onClick.AddListener(() => ButtonIndex = index);
            button.onClick.AddListener(() => UpdateUI());

            GameObject frame = buttonObject.transform.Find("frame").gameObject;
            //装備中のアイテムなら枠を表示させる
            if (i == ButtonIndex)
            {
                frame.SetActive(true);
            }
            else
            {
                frame.SetActive(false);
            }

        }
    }
}
