using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager{
    private static UIManager Instance;
    UIPanelTypeJson json;
    private Dictionary<UIPanelType, GameObject> panelCache = new Dictionary<UIPanelType, GameObject>();
    private Transform CanvasTransform;
    Stack<BasePanel> PanelStack = new Stack<BasePanel>();

    public static UIManager getInstance()
    {
        if (Instance == null)
        {
            Instance = new UIManager();
        }
        return Instance;
    }
    public UIManager()
    {
        LoadUIPanelTypeJson();
        CanvasTransform = GameObject.Find("Canvas").transform;
    }
    private void LoadUIPanelTypeJson()
    {
        //加载json文件
         TextAsset t=Resources.Load<TextAsset>("UIPanelType");
        json=JsonUtility.FromJson<UIPanelTypeJson>(t.text);
        Debug.LogError(json.PanelList.Length);
        Debug.LogError(json.PanelList[5].PanelPath);
    }

    //用栈来决定我们面板显示的顺序
    public void PushPanel(UIPanelType panelType)
    {
        //调用被挡住的OnPause
        if (PanelStack.Count != 0)
        {
            PanelStack.Peek().OnPause();

        }

        BasePanel panel = GetPanel(panelType);
        
        PanelStack.Push(panel);
        if (panel == null)
        {
            Debug.LogError("Panel为空");
        }
        panel.OnEnter();




    }

    public void PopPanel()
    {
        if (PanelStack.Count == 0)
            return;
        BasePanel panel = PanelStack.Pop();
        panel.OnExit();

        if (PanelStack.Count != 0)
            PanelStack.Peek().OnResume();
    }

    /// <summary>
    /// 创建一个面板并且显示
    /// </summary>
    /// <param name="panelType"></param>
    /// <returns></returns>
    private BasePanel GetPanel(UIPanelType panelType)
    {
        //写字典缓存，类似于对象池
        GameObject instPanel = panelCache.TryGetValueByNN(panelType);
        //判断缓存里面有没有，如果没有，创建新的，如果有拿缓存里的
        if (instPanel == null)
        {

            //通过名字找路径
            string path = "";
            foreach (var item in json.PanelList)
            {
                Debug.Log("开始查找" + item.PanelName + ":" + item.PanelPath);
                if (item.PanelName == panelType.ToString())
                {
                    path = item.PanelPath;
                    Debug.Log("找到啦" + item.PanelName);
                }
            }
            Debug.Log("新创建创建啦:" + path);
            instPanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
            instPanel.transform.SetParent(CanvasTransform, false);
            panelCache.Add(panelType, instPanel);
        }
        else
        {
            Debug.Log("用的缓存");
        }

        return instPanel.GetComponent<BasePanel>();
    }

}
//序列化
[Serializable]
public class UIPanelTypeJson
{
    public UIPanelInfo[] PanelList;
}
//序列化
[Serializable]
public class UIPanelInfo
{
    public string PanelName;
    public string PanelPath;

}
