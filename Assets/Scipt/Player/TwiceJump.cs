using UnityEngine;
using System.Collections;

public class TwiceJump : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        //触碰到地面，跳跃次数重置为0
        if (collider.tag == "Ground")
        {

            GameManager.getInstance().jumpFlag = true;
            GameManager.getInstance().jumptime = 0;
        }
    }
}