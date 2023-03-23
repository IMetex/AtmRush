using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject settingPanel;

    public void SettingPanelOpen()
    {
        settingPanel.SetActive(true);
    }
    public void SettingExit()
    {
        settingPanel.SetActive(false);
    }

}
