using UnityEngine;
using System.Collections;

public class PlayerFollowMoveBlock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.transform.parent = transform;//小人成为平台的子物体
    }
    void OnCollisionExit2D(Collision2D other)
    {
        other.gameObject.transform.parent = null;
    }
}
