using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textshow : MonoBehaviour
{
    Text textTshow;
    // Use this for initialization
    void Start()
    {
        textTshow = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textTshow.text = time.textTime.text ;
    }
}
