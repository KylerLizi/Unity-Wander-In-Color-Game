using UnityEngine;
using System.Collections;

public class DropingStone : MonoBehaviour {

    
	void Start () {
        //GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
        Destroy(gameObject, 3);
    }
	
	void Update () {
       
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Dead")
        {
            Destroy(gameObject);
        }
    }
}
