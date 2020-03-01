using UnityEngine;
using System.Collections;

public class VolcanoCameraFollow : MonoBehaviour {

    private Transform FollowTarget;
    private float FollowSpeed =1000;

	// Use this for initialization
	void Start () {
        FollowTarget = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 PositionBefore = this.transform.position;
        Vector3 NewPosition = Vector3.Lerp(this.transform.position, FollowTarget.position, FollowSpeed * Time.deltaTime);
        this.transform.position = new Vector3(NewPosition.x, 0, this.transform.position.z);
    }
}
