using UnityEngine;

[CreateAssetMenu(fileName = "InstallationData", menuName = "ObjectData / InstallationData")]
public class InstallationData : ObjectData
{
    public override void Use(ObjectController controller)
    {
        //設置物にアイテムが設定されていれば 
        if (NeedItem != null)
        {
            //アイテムが選択されていれば
            if (InventoryUI.inventoryUI.ButtonIndex >= 0 && InventoryUI.inventoryUI.ButtonIndex < InventoryUI.inventoryUI.itemList.Count)
            {
                //アイテムが対応するものなら
                if (NeedItem == InventoryUI.inventoryUI.itemList[InventoryUI.inventoryUI.ButtonIndex])
                {
                    //次の設置物が設定されていれば
                    if (NextData != null)
                    {
                        //設置物を変更
                        controller.objectData = NextData;
                        controller.ChangeSprite();
                        if(ClearFlag)
                        Main.main.GameClear();
                    }
                    else
                    {
                        controller.gameObject.SetActive(false);
                    }
                }
            }
        }
        //設置物にアイテムが設定されていなければ
        else
        {
            //次の設置物が設定されていれば
            if (NextData != null)
            {
                //設置物を変更
                controller.objectData = NextData;
                controller.ChangeSprite();
            }
            else
            {
                controller.gameObject.SetActive(false);
            }
        }
    }
}
