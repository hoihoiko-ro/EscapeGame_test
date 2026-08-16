using UnityEngine;
using UnityEngine.UI;

public class SystemUI : MonoBehaviour
{
    public Button GetButton;
    public bool pb_Back { get; private set; } = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetButton.onClick.AddListener(() => pb_Back = true);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        pb_Back = false;
    }
}
