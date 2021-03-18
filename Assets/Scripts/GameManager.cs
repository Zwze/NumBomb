using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int GameStatus = 1;//游戏状态：0暂停、1正常、-1结束
    public bool FirstClick = true;
    public GameObject MessageBoxUI;
    public Transform btnParent;
    public GameObject bomb_pre;
    GameObject bomb;

    Animator anim;

    Text text,playerNum_t;
    public int keyNum=0;
    public int MinValue = 0;
    public int MaxValue = 100;
    public int playerNum_i = -1;

    void SetKeyNum()
    {
        keyNum = Random.Range(DataManager.Instance.MinValue+1, DataManager.Instance.MaxValue);
    }

    void SetBomb()
    {
        bomb = (GameObject)Instantiate(bomb_pre, new Vector3(0, 0, 110), Quaternion.identity); //实例化对象
        bomb.transform.SetParent(GameObject.Find("Canvas").transform);
        bomb.transform.localPosition = new Vector3(0,130,0);
        bomb.transform.localScale = new Vector3(200, 200, 0);
    }

    void DestroyBomb()
    {
        Destroy(bomb);//销毁已爆炸的bomb
    }
    void SetMinMaxNum(int min,int max)
    {
        MinValue = min;
        MaxValue = max;

        text = GameObject.Find("Canvas/Hud/MinBg/MinValue").GetComponent<Text>();
        text.text = MinValue.ToString();//显示读取设定后的范围
        text = GameObject.Find("Canvas/Hud/MaxBg/MaxValue").GetComponent<Text>();
        text.text = MaxValue.ToString();//显示读取设定后的范围
    }
    // Start is called before the first frame update
    void Start()
    {
        GameStatus = 1;
        FirstClick = true;
        SetKeyNum();
        
        SetBomb();
        anim = bomb.GetComponent<Animator>();

        SetMinMaxNum(DataManager.Instance.MinValue, DataManager.Instance.MaxValue);
        

        //清空玩家输入框
        playerNum_t = GameObject.Find("Canvas/Hud/InputNumBg/InputValue").GetComponent<Text>();
        playerNum_t.text = "";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Explode()
    {
        anim.SetTrigger("Explode");
    }

    public void OnClick()
    {
        string btnName;
        btnName = EventSystem.current.currentSelectedGameObject.GetComponent<Button>().name;
        playerNum_t = GameObject.Find("Canvas/Hud/InputNumBg/InputValue").GetComponent<Text>();
        if (FirstClick == true)
        {
            if (playerNum_t.text != "")
            {
                playerNum_t.text = "";
            }
            FirstClick = false;
        }
        if (btnName == "Btn_1")
        {
            playerNum_t.text += "1";
        }
        if (btnName == "Btn_2")
        {
            playerNum_t.text += "2";
        }
        if (btnName == "Btn_3") {
            playerNum_t.text += "3";
        }
        if (btnName == "Btn_4") {
            playerNum_t.text += "4";
        }
        if (btnName == "Btn_5") {
            playerNum_t.text += "5";
        }
        if (btnName == "Btn_6") {
            playerNum_t.text += "6";
        }
        if (btnName == "Btn_7") {
            playerNum_t.text += "7";
        }
        if (btnName == "Btn_8") {
            playerNum_t.text += "8";
        }
        if (btnName == "Btn_9") {
            playerNum_t.text += "9";
        }
        if (btnName == "Btn_0")
        {
            playerNum_t.text += "0";
        }
        if (btnName == "Btn_bckarr")
        {
            string str = playerNum_t.text.ToString();
            str = str.Substring(0, str.Length - 1);
            playerNum_t.text = str;
            Debug.Log(GameStatus.ToString() + "回退");
           
        }
        if (btnName == "Btn_etrarr") 
        {//当游戏状态为正常(1)时，推动游戏进程；当游戏状态为暂停(0)时，调用Resume()继续游戏
            if (GameStatus == 1)
            {
                /*获取当前输入框中数字playNum
                 * 对比keyNum
                 * 相等->调用Over
                 * 大于->maxValue设置为playNum，输入框清空
                 * 小于->minValue设置为playNum，输入框清空
                 */
                playerNum_i = int.Parse(playerNum_t.text);
                if (playerNum_i >= MaxValue || playerNum_i <= MinValue)
                {
                    playerNum_t.text = "请在游戏范围内输入数字";
                    FirstClick = true;
                    return;
                }
                if (playerNum_i == keyNum)
                {
                    Over();
                    FirstClick = true;
                    
                }
                else
                {
                    if (playerNum_i < keyNum)
                    {
                        MinValue = playerNum_i;
                        SetMinMaxNum(MinValue, MaxValue);
                        
                    }
                    else
                    {
                        MaxValue = playerNum_i;
                        SetMinMaxNum(MinValue, MaxValue);
                    }
                    FirstClick = true;
                    playerNum_t = GameObject.Find("Canvas/Hud/InputNumBg/InputValue").GetComponent<Text>();
                    playerNum_t.text = "";
                }
            }
            if (GameStatus == 0)
            {
                Debug.Log(GameStatus.ToString() + "继续");
                Resume();
            }
        }

    }

    public void Pop()
    {
        //弹出消息窗口，暂停游戏时间
        MessageBoxUI.SetActive(true);
        Time.timeScale = 0.0f;
        text = GameObject.Find("Canvas/MessageBox/Message").GetComponent<Text>();
        if (GameStatus == 0)
        {
            text.text = "游戏暂停";//设置提示消息为暂停

            Debug.Log(GameStatus.ToString() + "暂停");
        }
        else if (GameStatus == -1)
        {
            text.text = "游戏结束";//设置提示消息为结束

            Debug.Log(GameStatus.ToString() + "结束");
        }
    }

    public void Resume()
    {//恢复暂停的游戏
     //关闭消息窗口，恢复游戏时间
        if (GameStatus == 0)
        {
            MessageBoxUI.SetActive(false);
            SetBomb();
            Time.timeScale = 1.0f;
            GameStatus = 1;
        }
    }

    public void Restart()
    {
        //关闭消息窗口，恢复游戏时间
        MessageBoxUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameStatus = 1;

        SceneManager.LoadScene(1);
    }

    public void Pause()
    {
        //弹出消息窗口，暂停游戏时间
        GameStatus = 0;
        DestroyBomb();
        Pop();

        Debug.Log(GameStatus.ToString() + "暂停");

    }
    public void Over()
    {
        /*播放炸弹爆炸动画
         * 判断动画播放结束
         * 弹出消息窗口，暂停游戏时间    
         */
        Invoke(nameof(Explode), 0.0f);
        GameStatus = -1;
        Invoke(nameof(DestroyBomb), 1f); 
        Invoke(nameof(Pop), 2f);
             
    }
    public void ToMainMenu()
    {
        //返回至主菜单，恢复被暂停的游戏时间
        GameStatus = 1;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
}
