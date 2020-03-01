using UnityEngine;
using System.Collections;

public class CameraPubuFollow : MonoBehaviour
{
    private GameObject FollowTarget;
    public GameObject[] Background;
    private float FollowSpeed=3f;
    // Use this for initialization
    void Start()
    {
        FollowTarget = GameObject.FindWithTag("Player");//通过标签找到主角
    }

    // Update is called once per frame
    void Update()
    {
    }
    void FixedUpdate()
    {
        //镜头跟随小人
        Vector3 PositionBefore = this.transform.position;
        Vector3 NewPosition = Vector3.Lerp(this.transform.position, FollowTarget.transform.position, FollowSpeed * Time.deltaTime);//Lerp是一个物体平滑跟随另一个物体的写法
        //通过相机的位置判断是否到达瀑布
        if (this.transform.position.x <= 98)
        {
            if (this.transform.position.y < 30)
            {
                //在水平地面上移动时，镜头水平移动
                this.transform.position = new Vector3(NewPosition.x, 1.5f, this.transform.position.z);
            }
            //到达通关地面
            else
            {
                this.transform.position = new Vector3(98, NewPosition.y, this.transform.position.z);
            }

            //背景视差效果
            Vector3 CameraMovementAmount = PositionBefore - this.transform.position;

            Background[0].transform.Translate(-CameraMovementAmount * 0.8f);
            Background[1].transform.Translate(-CameraMovementAmount * 0.7f);
            Background[2].transform.Translate(-CameraMovementAmount * 0.6f);
            Background[3].transform.Translate(-CameraMovementAmount * 0.5f);
            Background[4].transform.Translate(-CameraMovementAmount * 0.4f);
            Background[5].transform.Translate(-CameraMovementAmount * 0.3f);
            Background[6].transform.Translate(-CameraMovementAmount * 0.2f);
        }
        else
        {
            if (NewPosition.y >= 1.6f)
            {
                //当到达瀑布跳跃时镜头可以上下左右移动
                this.transform.position = new Vector3(NewPosition.x, NewPosition.y, this.transform.position.z);
            }
            else
                this.transform.position = new Vector3(NewPosition.x, 1.5f, this.transform.position.z);
        }
    }

}