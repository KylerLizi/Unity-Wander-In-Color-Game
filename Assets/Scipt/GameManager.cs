using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public GameObject player;
    public bool IsFirst = true;//教程是否第一次打开
	public bool IfCanMove=false;
    //不同关卡重新开始
    public string level;
    public string id_Login;
    public int time_control = 0;

    //检测游戏状态
    public int GAMESTATE;
    public int MENU = 0;
    public int PAUSE = 1;
    public int PLAYING = 2;
    public int PREPARING = 3;
    public int GAMEOVER = 4;
    float waitTime = 0f;//游戏第一次开始的等待时间

    //跳跃次数判断
    public bool jumpFlag;
    public int jumptime;
    
    //Singleton 单例
    private static GameManager instance;
    private static GameObject container;

    public static GameManager getInstance()
    {
        if (!instance)
        {
            container = new GameObject();
            container.name = "Logger";
            instance = container.AddComponent(typeof(GameManager)) as GameManager;
        }
        return instance;
    }

    void Awake()
    {
        GAMESTATE = PREPARING;
        jumpFlag = true;
        jumptime = 0;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start () {
        DontDestroyOnLoad(gameObject);//每次加载场景时，不破坏GameManager
        StartCoroutine(wait());
    }

    IEnumerator wait()//协助函数
    {
        yield return new WaitForSeconds(waitTime);
        IsFirst = false;
        GAMESTATE = PLAYING;
    }

    void Update () {

    }
}
