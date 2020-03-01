using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuUI : MonoBehaviour {

	void Start () {
        
	}
	
	void Update () {
      
	}
    public void ChangeScene()
    {
        GameManager.getInstance().GAMESTATE = GameManager.getInstance().PREPARING;
        SceneManager.LoadScene("LevelSelect");
    }
    public void Exit()
    {
        Application.Quit();//结束游戏
    }
}
