using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public GameObject panel;//结束界面
	public GameObject pause;
    public GameObject victory;
    public Text ready;
    time timecs;
    float waitTime=2f;
    float goTime=2.3f;
    float time;

    void Awake()
    {
        timecs = GameObject.Find("time").GetComponent<time>();
        GameManager.getInstance().GAMESTATE = GameManager.getInstance().PREPARING;
    }

	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.getInstance().GAMESTATE == GameManager.getInstance().PREPARING)
        {
            time += Time.deltaTime;
            if (time > waitTime)
            {
                ready.text = "GO!";
                if (time > goTime)
                {
                    ready.text = "";
                    GameManager.getInstance().GAMESTATE = GameManager.getInstance().PLAYING;
                }
            }
        }
        if (GameManager.getInstance().GAMESTATE == GameManager.getInstance().GAMEOVER)
        {
            panel.SetActive(true);
        }
    }

    public void Restart()//重新开始
    {
        panel.SetActive(false);
		Time.timeScale = 1;
        GameManager.getInstance().GAMESTATE = GameManager.getInstance().PREPARING;
        timecs.reTimer();
        SceneManager.LoadScene(GameManager.getInstance().level);
    }
    public void Return()
    {
        SceneManager.LoadScene("start");
        Time.timeScale = 1;
    }
	public void Pause()
	{
		panel.SetActive (true);
		GameManager.getInstance ().GAMESTATE = GameManager.getInstance().PAUSE;
		Time.timeScale = 0;
	}
	public void Continue()
	{
		panel.SetActive (false);
        GameManager.getInstance ().GAMESTATE = GameManager.getInstance().PLAYING;
		Time.timeScale = 1;
	}

}
