using UnityEngine;
using System.Collections;

public class Camera_2Follow : MonoBehaviour {
    private Transform FollowTarget;
    private float FollowSpeed=3f;
    // Use this for initialization
    void Start () {
        FollowTarget = GameObject.FindWithTag("Player").transform;//通过标签找到主角
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        this.transform.position = new Vector3(FollowTarget.position.x, FollowTarget.position.y, this.transform.position.z);
    }
}
