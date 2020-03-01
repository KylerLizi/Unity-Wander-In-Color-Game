using UnityEngine;
using System.Collections;

public class AutoPlatformMove : MonoBehaviour {

    public float speed;

    //记录平台的位置
    public Transform End;

    //记录关键位置
    private Vector3 StartPosition;
    private Vector3 EndPosition;
    private bool OnTheMove;

    void Start()
    {
        //存储起点和终点的位置
        StartPosition = this.transform.position;
        EndPosition = End.position;
    }

    void FixedUpdate()
    {

        float step = speed * Time.deltaTime;

        if (OnTheMove == false)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, EndPosition, step);
        }
        else
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, StartPosition, step);
        }

        //当到达终点时转向
        if (this.transform.position.x == EndPosition.x && this.transform.position.y == EndPosition.y && OnTheMove == false)
        {
            OnTheMove = true;
        }
        else if (this.transform.position.x == StartPosition.x && this.transform.position.y == StartPosition.y && OnTheMove == true)
        {
            OnTheMove = false;
        }
    }
}
