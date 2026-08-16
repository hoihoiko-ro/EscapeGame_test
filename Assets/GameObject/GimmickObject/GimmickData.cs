using UnityEngine;

[CreateAssetMenu(fileName = "GimmickData", menuName = "ObjectData / GimmickData")]
public class GimmickData : ObjectData
{
    public Vector2 CameraPosition;
    public override void Use(ObjectController controller)
    {
        PanelController.panel.ChnageScene(CameraPosition);
    }
}
