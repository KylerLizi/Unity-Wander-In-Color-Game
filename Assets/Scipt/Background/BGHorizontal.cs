using UnityEngine;
using System.Collections;

public class BGHorizontal : MonoBehaviour {

    //public Color xcolor;//自定义一个颜色
    private float wait=0.5f;
    private float rush = 0.5f;
    public float HorzDis;
    void Start () {

        StartCoroutine(move());//启动辅助函数
    }

    IEnumerator move()//协助函数
    {
        while (true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(7, 0);
            yield return new WaitForSeconds(wait);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-4, 0);
            yield return new WaitForSeconds(wait);
            GetComponent<Rigidbody2D>().velocity = new Vector2(40, 0);
            yield return new WaitForSeconds(rush);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    void Update()
    {
   
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "HorizontalTrigger")
        {
            this.transform.Translate(new Vector3(HorzDis, 0, 0));
        }
    }
}
