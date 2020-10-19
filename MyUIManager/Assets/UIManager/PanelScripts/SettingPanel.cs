using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : BasePanel {
    public static int id;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SwitchToStartPanel()
    {
        if (id == 0)
        {
            DicTool.SwitchPanel(UIPanelType.StartPanel);
        }
        else
        {
            DicTool.SwitchPanel(UIPanelType.MainScreenPanel);
        }
    }
}
