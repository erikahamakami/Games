using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptCamera : MonoBehaviour
{
    private float rotY = 0;
    private Quaternion rotOriginal;

    // Start is called before the first frame update
    void Start()
    {
        rotOriginal = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        rotY += Input.GetAxis("Mouse Y");
        rotY = Mathf.Clamp(rotY, -50, 50);

        Quaternion cimabaixo = Quaternion.AngleAxis(rotY, Vector3.left);

        transform.localRotation = rotOriginal * cimabaixo;
        
    }
}
