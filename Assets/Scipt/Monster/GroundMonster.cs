using UnityEngine;
using System.Collections;

public class GroundMonster : MonoBehaviour {
    public int speed = -3;
    private PlayerControl PlayerScript;

    void Start () {
        PlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }

	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "MonsterMoveTrigger")//遇到怪物自动移动边界时
        {
            speed = -speed;//反向速度
            if(speed>0)
                this.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);//转身
            else
                this.transform.rotation = Quaternion.AngleAxis(0, Vector3.up);//转身
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")//判断小人碰到的是怪物头部还是身体部位
        {
            if (coll.contacts[0].normal.x > -1f && coll.contacts[0].normal.x < 1f && coll.contacts[0].normal.y < -0.8f && coll.contacts[0].normal.y > -1.8f)
            {
                //coll.rigidbody.AddForce(new Vector2(0f, 1500f));
                coll.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(coll.gameObject.GetComponent<Rigidbody2D>().velocity.x, 25);
                GameManager.getInstance().jumptime = 0;
                GameManager.getInstance().jumpFlag = true;
                Destroy(this.gameObject);//怪物死亡
            }
            else
            {
                PlayerScript.iDead();//角色死亡
            }
        }
    }
}
