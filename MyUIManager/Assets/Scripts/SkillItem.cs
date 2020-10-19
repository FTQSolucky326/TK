using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillItem : MonoBehaviour {

    public float coldTime = 2.0f;//技能冷却时间
    private float timer = 0;//计时器的初始值
    private Image filledImage;
    private bool isStartTime;//是否开始计算时间
    public KeyCode keycode;

	// Use this for initialization
	void Start () {
        filledImage = transform.Find("FilledSkill").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(keycode))
        {
            isStartTime = true;
        }
        if (isStartTime)
        {
            timer += Time.deltaTime;
            filledImage.fillAmount = (coldTime - timer) / coldTime;
        }
        if (timer >= coldTime)
        {
            filledImage.fillAmount = 0;
            timer = 0;
            isStartTime = false;
        }
	}
    public void OnClick()
    {
        isStartTime = true;
    }
}
