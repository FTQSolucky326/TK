using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DicTool{
    public static TValue TryGetValueByNN<TKey, TValue>(this Dictionary<TKey, TValue> dic, TKey type)
    {
        TValue v;

        dic.TryGetValue(type, out v);

        return v;
    }
    public static void SwitchPanel(UIPanelType type)
    {
        UIManager.getInstance().PopPanel();
        UIManager.getInstance().PushPanel(type);
    }
}
