using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel {
    public InputField InputUsername;
    public InputField InputPassword;
    private string Username;
    private string Password;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Username = InputUsername.GetComponent<InputField>().text;
        Password = InputPassword.GetComponent<InputField>().text;
    }

    public void OnButtonAtn()
    {
        VerityUser(Username, Password);
    }

    public void VerityUser(string username,string userpassword)
    {
        if (Username.Equals("111") && Password.Equals("222"))
        {
            DicTool.SwitchPanel(UIPanelType.StartPanel);
        }
    }
}
