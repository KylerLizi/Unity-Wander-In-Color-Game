using UnityEngine;
using System.Collections;

public class CaveCameraFollow : MonoBehaviour {

    private Transform FollowTarget;
    private float FollowSpeed = 8f;

    void Start()
    {
        FollowTarget = GameObject.FindWithTag("Player").transform;//通过标签找到主角
    }


    void FixedUpdate()
    {
        Vector3 PositionBefore = this.transform.position;
        Vector3 NewPosition = Vector3.Lerp(this.transform.position, FollowTarget.position, FollowSpeed * Time.deltaTime);//Lerp是一个物体平滑跟随另一个物体的写法
        if (FollowTarget.position.x<87)
            this.transform.position = new Vector3(NewPosition.x, 0, this.transform.position.z);
        else if(FollowTarget.position.x<140)
        {
            if(FollowTarget.position.y > 0)
                this.transform.position = new Vector3(NewPosition.x, 0, this.transform.position.z);
            else if(FollowTarget.position.y <-7)
                this.transform.position = new Vector3(NewPosition.x, -6, this.transform.position.z);
            else
                this.transform.position = new Vector3(NewPosition.x, NewPosition.y, this.transform.position.z);
        }
        else
            this.transform.position = new Vector3(140, -6, this.transform.position.z);
    }
}
