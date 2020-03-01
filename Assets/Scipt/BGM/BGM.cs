using UnityEngine;
using System.Collections;

public class BGM : MonoBehaviour {
    public GameObject obje;
    GameObject obj = null;
	// Use this for initialization
	void Start () {
        obj = GameObject.FindGameObjectWithTag("BGM");
        if (obj == null)
            obj = (GameObject)Instantiate(obje);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
