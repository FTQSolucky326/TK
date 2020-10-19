using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelScroll : MonoBehaviour,IBeginDragHandler,IEndDragHandler{
    //代码的思想就是当靠近那一页的时候就让他留在那一页，例如滑到了0.39靠近0.33，就留在了0.33这一页
    private ScrollRect scrollRect;
    private float[] pageArray = new float[] { 0,0.33f,0.67f,1.0f};
    private float targethorizontalPosition=0;
    public Toggle[] toggleArray;
    private bool isDraging = false;
    // Use this for initialization
    void Start () {
        scrollRect = GetComponent<ScrollRect>();

    }
	
	// Update is called once per frame
	void Update () {
        if (isDraging==false)
        {
            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(scrollRect.horizontalNormalizedPosition, targethorizontalPosition, Time.deltaTime * 5);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        isDraging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDraging = false;
        float posx= scrollRect.horizontalNormalizedPosition;//取得拖拽结果的横坐标
        int index = 0;//预设的页码
        float offset = Math.Abs(pageArray[index] - posx);//差值的运算
        for (int i = 1; i < pageArray.Length; i++)
        {
            float offsetTemp = Math.Abs(pageArray[i] - posx);
            if (offsetTemp < offset)
            {
                index = i;
                offset = offsetTemp;//实现跳页离array最近的位置
            }
        }
        targethorizontalPosition = pageArray[index];
        toggleArray[index].isOn = true;
        //scrollRect.horizontalNormalizedPosition = pageArray[index];
    }
    public void TurnToPanel1(bool isOn)
    {
        if (isOn)
        {
            targethorizontalPosition = pageArray[0];//跳转到第1页
        }
    }
    public void TurnToPanel2(bool isOn)
    {
        if (isOn)
        {
            targethorizontalPosition = pageArray[1];//跳转到第2页
        }
    }
    public void TurnToPanel3(bool isOn)
    {
        if (isOn)
        {
            targethorizontalPosition = pageArray[2];//跳转到第3页
        }
    }
    public void TurnToPanel4(bool isOn)
    {
        if (isOn)
        {
            targethorizontalPosition = pageArray[3];//跳转到第4页
        }
    }
}
