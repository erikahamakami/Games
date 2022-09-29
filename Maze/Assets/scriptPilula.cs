using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPilula : MonoBehaviour
{
    private float rot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rot += Time.deltaTime;
        transform.eulerAngles = new Vector3(rot * 90, rot * 360, 0);
    }
}
