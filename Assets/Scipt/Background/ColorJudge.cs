using UnityEngine;
using System.Collections;

public class ColorJudge : MonoBehaviour
{
	public GameObject Block;
	public GameObject BG;
	public Color Xcolor;
	// Use this for initialization
	void Start()
	{

	}
	void Awake()
	{
		Block.GetComponent<Renderer>().material.color=Xcolor;
		BG.GetComponent<Renderer> ().material.color = Xcolor;
	}
	// Update is called once per frame
	void Update()
	{
		
	}
    //颜色相同时一旦触碰，使平台消失
	void OnTriggerEnter2D(Collider2D collider)
	{
		
		if (collider.tag == "BackColor")
		{
            if (collider.GetComponent<Renderer>().material.color == Block.GetComponent<Renderer>().material.color)
            {
                if (this.transform.Find("colorful_plantform"))//如果该空物体下是平台不是刺
                {
                    if (this.transform.Find("colorful_plantform").transform.Find("BlackPeople"))//并且该空物体下的平台上有小人
                    {
                        GameManager.getInstance().player.transform.parent = null;//小人的父物体置空，否则会跟平台一起消失
                        StartCoroutine(wait());//延时保证让小人先出去再让平台消失
                        Block.SetActive(false);
                        StartCoroutine(wait());//延时保证小人的状态改变
                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().IsGrounded = false;

                    }
                    else
                    {
                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().IsGrounded = false;
                        Block.SetActive(false);
                    }

                }
                else
                { 
                    Block.SetActive(false);//平台消失
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().IsGrounded = false;
                }

            }
		}
	}
    //颜色不同时，平台出现
	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.tag == "BackColor") {
			if (collider.GetComponent<Renderer> ().material.color == Block.GetComponent<Renderer> ().material.color) {
				Block.SetActive (true);
			}
		}
	}

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.01f);
    }
}
