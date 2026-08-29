using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの入力からメニュー画面を表示非表示を制御する
/// </summary>
public class UIManager : MonoBehaviour
{
    //各UIPanelを格納
    [SerializeField] GameObject photoPanel;
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject zukanPanel;

    private bool isOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Tab押されたよ");
            ToggleMenu();
        }
    }

    void ToggleMenu()
    {
        Debug.Log("Tabの処理"+isOpen);
        isOpen = !isOpen;
        Debug.Log("isOpen:" + isOpen);
        Debug.Log(menuPanel);
        menuPanel.SetActive(isOpen);
    }

    public void OpenZukan()
    {
        isOpen = !isOpen;

        zukanPanel.SetActive(isOpen);

    }
}
