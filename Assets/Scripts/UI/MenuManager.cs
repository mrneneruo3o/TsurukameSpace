using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

/// <summary>
/// メニュー画面から各ボタン画面への遷移
/// </summary>
public class MenuManager : MonoBehaviour
{
    //メニュー画面
    public GameObject menuPanel;

    /// <summary>
    /// メニュー画面→ボタンの画面へ
    /// </summary>
    /// <param name="panel"></param>
    public void OpenPanel(GameObject panel)
    {
        menuPanel.SetActive(false);
        panel.SetActive(true);
    }

    /// <summary>
    /// ボタンの画面からメニュー画面へ
    /// </summary>
    /// <param name="panel"></param>
    public void ClosePanel(GameObject panel)
    {
        Debug.Log("閉じるが押された");
        panel.SetActive(false);
        menuPanel.SetActive(true);
    }
}
