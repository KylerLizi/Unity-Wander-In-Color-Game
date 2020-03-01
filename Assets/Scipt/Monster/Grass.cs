using UnityEngine;
using System.Collections;

public class Grass : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")//判断小人碰到的是否为小草顶部
        {
            if (coll.contacts[0].normal.x > -1f && coll.contacts[0].normal.x < 1f && coll.contacts[0].normal.y < -0.8f && coll.contacts[0].normal.y > -1.8f)
            {
                //coll.rigidbody.AddForce(new Vector2(0f, 1500f));
                coll.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(coll.gameObject.GetComponent<Rigidbody2D>().velocity.x, 25);
                GameManager.getInstance().jumptime = 0;
                GameManager.getInstance().jumpFlag = true;
            }
        }
    }
}
