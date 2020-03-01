using UnityEngine;
using System.Collections;

public class FireMonster : MonoBehaviour {

    public GameObject bullet;
	void Start () {
        StartCoroutine(create());
    }

    IEnumerator create()
    {
        while (true)
        {
            Instantiate(bullet, this.transform.position, this.transform.rotation);
            yield return new WaitForSeconds(1.5f);
        }
    }

    void Update () {
	    
	}
}
