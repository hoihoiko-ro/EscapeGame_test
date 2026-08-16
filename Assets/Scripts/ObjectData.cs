using UnityEngine;

[CreateAssetMenu(fileName = "ObjectData", menuName = "é©çÏÉfÅ[É^ / ObjectData")]

public abstract class ObjectData : ScriptableObject
{
    public ItemData NeedItem;
    public ObjectData NextData;
    public Sprite sprite;
    public bool ClearFlag = false;

    public abstract void Use(ObjectController controller);
}
