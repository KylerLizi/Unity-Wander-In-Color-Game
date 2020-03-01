using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class idGet : MonoBehaviour {

    Text idText;
	// Use this for initialization
	void Start () {
        
        idText=  GetComponent<Text>();
        
    }
	
	// Update is called once per frame
	void Update () {
        idText.text= GameManager.getInstance().id_Login;

    }
}
