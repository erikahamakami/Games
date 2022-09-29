using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPortal : MonoBehaviour
{
    public float xPos;
    public float yPos;
    public float zPos;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.position = new Vector3(xPos, yPos, zPos);
    }
}