using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : BasePanel {

	// Use this for initialization
	void Start () {
     
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SwitchToMainPanel()
    {
        DicTool.SwitchPanel(UIPanelType.MainScreenPanel);
    }
    public void SwitchToSettingPanel()
    {
        SettingPanel.id = 0;
        DicTool.SwitchPanel(UIPanelType.SettingPanel);
    }
    public void SwitchToTitlePanel()
    {
        UIManager.getInstance().PushPanel(UIPanelType.TitlePanel);
        DicTool.SwitchPanel(UIPanelType.TitlePanel);
    }
    public void SwitchToLevelPanel()
    {
        DicTool.SwitchPanel(UIPanelType.LevelPanel);
    }
}
