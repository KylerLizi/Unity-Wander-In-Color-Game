using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ChangeScene);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ChangeScene()
    {
        GameManager.getInstance().GAMESTATE = GameManager.getInstance().PREPARING;
        SceneManager.LoadScene("login");
    }
}
