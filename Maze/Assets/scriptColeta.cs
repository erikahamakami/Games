using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptColeta : MonoBehaviour
{
    public Text scoreTxt;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = "Score: " + score;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("pilula") == true)
        {
            score = score + 1;
            Destroy(col.gameObject);
        }
    }
}
