using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    Text text_p,text_t;

    void Start()
    {
        text_t = GameObject.Find("Canvas/MainMenu/Text_MinValue/Text").GetComponent<Text>();
        text_p = GameObject.Find("Canvas/MainMenu/Text_MinValue/Placeholder").GetComponent<Text>();
        text_t.text = DataManager.Instance.MinValue.ToString();
        text_p.text = DataManager.Instance.MinValue.ToString();
        text_t = GameObject.Find("Canvas/MainMenu/Text_MaxValue/Text").GetComponent<Text>();
        text_p = GameObject.Find("Canvas/MainMenu/Text_MaxValue/Placeholder").GetComponent<Text>();
        text_t.text = DataManager.Instance.MaxValue.ToString();
        text_p.text = DataManager.Instance.MaxValue.ToString();
    }
    public void PlayGame()
    {   //切换至开始游戏
        //判断输入数值是否合法合理
        text_t = GameObject.Find("Canvas/MainMenu/TipsMessage").GetComponent<Text>();
        if (DataManager.Instance.MaxValue-DataManager.Instance.MinValue<2)
        {
            text_t.text = "范围设置错误";
            return;
        }
        if(DataManager.Instance.MaxValue>2000|| DataManager.Instance.MinValue> 2000)
        {
            text_t.text = "输入数字过大";
            return;
        }
        if(DataManager.Instance.MinValue < 0 || DataManager.Instance.MaxValue < 0)
        {
            text_t.text = "输入了负数";
            return;
        }
        SceneManager.LoadScene(1);
               
    }

    public void QuitGame()
    {//退出游戏
        Application.Quit();
    }

   
}
