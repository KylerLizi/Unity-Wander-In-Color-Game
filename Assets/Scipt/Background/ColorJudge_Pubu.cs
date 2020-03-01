using UnityEngine;
using System.Collections;

public class ColorJudge_Pubu : MonoBehaviour
{
    public GameObject Block;
    public GameObject BG1;
    public GameObject BG2;
    public GameObject BG3;
    public Color Xcolor;
    // Use this for initialization
    void Start()
    {
    }
    void Awake()
    {
        Block.GetComponent<Renderer>().material.color = Xcolor;
        BG1.GetComponent<Renderer>().material.color = Xcolor;
        BG2.GetComponent<Renderer>().material.color = Xcolor;
        BG3.GetComponent<Renderer>().material.color = Xcolor;
    }
    // Update is called once per frame
    void Update()
    {

    }
    //颜色相同时一旦触碰，使平台消失
    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "BackColor2")
        {
            if (collider.GetComponent<Renderer>().material.color == Block.GetComponent<Renderer>().material.color)
            {
                Block.SetActive(false);
                //Block.GetComponent<Collider2D> ().enabled = false;
            }
        }
    }
    //颜色不同时，平台出现
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "BackColor2")
        {
            if (collider.GetComponent<Renderer>().material.color == Block.GetComponent<Renderer>().material.color)
            {
                Block.SetActive(true);
            }
        }
    }
}
