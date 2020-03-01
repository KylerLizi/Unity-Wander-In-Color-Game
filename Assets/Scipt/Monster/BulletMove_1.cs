using UnityEngine;
using System.Collections;

public class BulletMove_1 : MonoBehaviour {

    public Color Xcolor;
    private PlayerControl playScript;
    private GameObject BG;

    void Start () {
        BG = GameObject.Find("Bgcolor_1");
        playScript = GameManager.getInstance().player.GetComponent<PlayerControl>();
        GetComponent<Renderer>().material.color = Xcolor;
        BG.GetComponent<Renderer>().material.color = Xcolor;
        GetComponent<Rigidbody2D>().velocity = new Vector2(-15, 0);
        Destroy(gameObject, 4.5f);
	}

	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "BackColor")
        {
            if (collider.GetComponent<Renderer>().material.color == gameObject.GetComponent<Renderer>().material.color)
            {
                Destroy(gameObject);
            }
        }
        if (collider.tag == "Player")
        {
            Destroy(gameObject);
            playScript.iDead();
        }
    }
}
