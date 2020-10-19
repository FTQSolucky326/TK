using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenPanel : BasePanel {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void SwitchToSetting()
    {
        SettingPanel.id = 1;
        DicTool.SwitchPanel(UIPanelType.SettingPanel);
    }
    public void SwitchToCharacter()
    {
        DicTool.SwitchPanel(UIPanelType.CharactePanel);
    }
}
