using UnityEngine;
using System.Collections;

public class WaterControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -7f);//水层下落
	}
    //水层循环
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "VerticalTrigger")
        {
            this.transform.Translate(new Vector3(0, 60, 0));
        }
    }
}
