using UnityEngine;
using System.Collections;

public class BGVertical : MonoBehaviour {

    public float VertDis;

    // Use this for initialization
    void Start () {
        
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5f);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "VerticalTrigger")
        {
            this.transform.Translate(new Vector3(0, VertDis, 0));
        }
    }
}
