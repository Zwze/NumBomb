using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour
{
    static public int GameStatus = 1;//游戏状态：0结束、1正常、2暂停
    public GameObject MessageBoxUI;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        Restart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume()
    {//恢复暂停的游戏
        if (GameStatus == 2)
        {
            //关闭消息窗口，恢复游戏时间
            MessageBoxUI.SetActive(false);
            Time.timeScale = 1.0f;
            GameStatus = 1;
        }
        else
        {
            return;
        }
    }

    public void Restart()
    {
        //关闭消息窗口，恢复游戏时间
        MessageBoxUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameStatus = 1;
        /*重新开始
         *重新生成keyword 
         *恢复范围
         *重新置换输入框
         */

    }

    public void Pause()
    {
        //弹出消息窗口，暂停游戏时间
        MessageBoxUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameStatus = 2;
        text = GameObject.Find("Canvas/MessageBox/Message").GetComponent<Text>();
        text.text = "游戏暂停";//设置提示消息为暂停
        
        
    }

    public void Over()
    {
        //弹出消息窗口，暂停游戏时间
        if (GameStatus == 2)
        {
            MessageBoxUI.SetActive(true);
            Time.timeScale = 0.0f;
            GameStatus = 0;
            text = GameObject.Find("Canvas/MessageBox/Message").GetComponent<Text>();
            text.text = "游戏结束";//设置提示消息为暂停
        }
        
    }
    public void MainMenu()
    {
        //返回至主菜单，恢复被暂停的游戏时间
        GameStatus = 1;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
}
