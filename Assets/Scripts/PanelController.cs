//プレイヤーオブジェクトに合わせてカメラのx軸が動く
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public static PanelController panel;
    private Vector2 previous_position;
    private bool ChnageSceneFlag;

    private void Awake()
    {
        if (panel == null)
        {
            panel = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (!ChnageSceneFlag)
            {
                // パネルがワープ
                transform.localPosition = new Vector2(900, 0);
            }
            else
            {
                transform.localPosition = previous_position;
                ChnageSceneFlag = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!ChnageSceneFlag)
            {
                // パネルがワープ
                transform.localPosition = new Vector2(-900, 0);
            }
            else
            {
                transform.localPosition = previous_position;
                ChnageSceneFlag = false;
            }

        }

    }

    public void ChnageScene(Vector2 CameraPosition)
    {
        previous_position = this.transform.localPosition;
        ChnageSceneFlag = true;
        CameraPosition = new Vector2 (CameraPosition.x * -1, 0);
        transform.localPosition = CameraPosition;
    }

}