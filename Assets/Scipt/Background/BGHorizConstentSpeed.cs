using UnityEngine;
using System.Collections;

public class BGHorizConstentSpeed : MonoBehaviour {

    private float wait = 0.5f;
    private float rush = 0.5f;
    public float HorzDis;
    public float HorzSpeed;
    void Start()
    {

    }
    void Update()
    {

    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(HorzSpeed, 0); 
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "HorizontalTrigger")
        {
            this.transform.Translate(new Vector3(HorzDis, 0, 0));
        }
    }
}
