using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        UIManager.getInstance().PushPanel(UIPanelType.LoginPanel);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
