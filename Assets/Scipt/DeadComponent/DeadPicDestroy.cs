using UnityEngine;
using System.Collections;

public class DeadPicDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3);
        Destroy(gameObject, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
