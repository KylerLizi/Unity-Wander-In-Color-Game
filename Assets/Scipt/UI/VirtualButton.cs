using UnityEngine;
using System.Collections;

public class VirtualButton : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameManager.getInstance().player;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(-player.GetComponent<PlayerControl>().crashSpeed, player.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    /*public void LeftButton()
    {
        if ((GameManager.getInstance().GAMESTATE == GameManager.getInstance().PLAYING) && (GameManager.getInstance().IfCanMove == true))
        {
            player.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(-player.GetComponent<PlayerControl>().crashSpeed, player.GetComponent<Rigidbody2D>().velocity.y);
        }
    }
    public void RightButton()
    {
        if ((GameManager.getInstance().GAMESTATE == GameManager.getInstance().PLAYING) && (GameManager.getInstance().IfCanMove == true))
        {
            player.transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<PlayerControl>().crashSpeed, player.GetComponent<Rigidbody2D>().velocity.y);
        }
    }
    public void JumpButton()
    {
        if ((GameManager.getInstance().GAMESTATE == GameManager.getInstance().PLAYING) && (GameManager.getInstance().IfCanMove == true))
        {
            if (GameManager.getInstance().jumpFlag && GameManager.getInstance().jumptime < 2)
                player.GetComponent<PlayerControl>().iJump();
        }
    }*/
}
