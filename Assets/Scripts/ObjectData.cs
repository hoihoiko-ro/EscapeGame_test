using UnityEngine;

[CreateAssetMenu(fileName = "ObjectData", menuName = "©ìƒf[ƒ^ / ObjectData")]

public abstract class ObjectData : ScriptableObject
{
    public ItemData NeedItem;
    public ObjectData NextData;
    public Sprite sprite;

    public abstract void Use(ObjectController controller);
}
