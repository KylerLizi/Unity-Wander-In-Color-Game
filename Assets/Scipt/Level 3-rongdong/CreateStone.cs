using UnityEngine;
using System.Collections;

public class CreateStone : MonoBehaviour {

    public GameObject stone;

    void Start () {
        StartCoroutine(create());
    }
	
    IEnumerator create()
    {
        while(true)
        {
            Instantiate(stone, this.transform.position, this.transform.rotation);
            yield return new WaitForSeconds(2);
        }
    }

	void Update () {
       
    }
}
