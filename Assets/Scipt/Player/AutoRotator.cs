using UnityEngine;
using System.Collections;

public class AutoRotator : MonoBehaviour {

    public float RotationSpeed;

    void Update()
    {
        this.transform.Rotate(new Vector3(0f, 0f, RotationSpeed * Time.deltaTime));
    }
}
