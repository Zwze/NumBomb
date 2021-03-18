using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinMaxValueSave : MonoBehaviour
{
    Text text;

    public void SaveMinValue()
    {//寻找输入框的文本值，转换为整型并赋予DataManager的MinValue
        text = GameObject.Find("Canvas/MainMenu/Text_MinValue/Text").GetComponent<Text>();
        DataManager.Instance.MinValue = int.Parse(text.text);

    }
    public void SaveMaxValue()
    {//寻找输入框的文本值，转换为整型并赋予DataManager的MaxValue
        text = GameObject.Find("Canvas/MainMenu/Text_MaxValue/Text").GetComponent<Text>();
        DataManager.Instance.MaxValue = int.Parse(text.text);
    }

    
}
