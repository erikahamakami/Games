using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptCamera : MonoBehaviour
{
  public GameObject pc;
  public float offset_y = 2;
  public float offset_x = 0;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    Vector3 posicao = new Vector3(pc.transform.position.x + offset_x, pc.transform.position.y + offset_y, -10);
    this.transform.position = posicao;

  }
}
