using UnityEngine;
using System.Collections;

public class DropBlock : MonoBehaviour {
    public GameObject block;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if(this.transform.Find("BlackPeople"))//当平台下有子物体小人时，向下落
        {
            block.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.01f, this.transform.position.z);
        }
	}
    
}
