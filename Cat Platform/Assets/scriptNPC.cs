using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class scriptNPC : MonoBehaviour
{
  private Rigidbody2D rbd;
  public float velocidade = 5;
  public float distancia = 1;
  public LayerMask mascara;
  public LayerMask mascara2;
  // Start is called before the first frame update
  void Start()
  {
    rbd = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    rbd.velocity = new Vector2(velocidade, 0);

    RaycastHit2D hit2D;
    hit2D = Physics2D.Raycast(transform.position, transform.right, distancia, mascara);
    if (hit2D.collider != null)
    {
      velocidade = velocidade * -1;
      rbd.velocity = new Vector2(velocidade, 0);
      transform.Rotate(new Vector2(0, 180));
    }
    RaycastHit2D hit2;
    hit2 = Physics2D.Raycast(transform.position, transform.right, distancia, mascara2);
    if (hit2.collider != null)
    {
      Destroy(hit2.collider.gameObject);

      SceneManager.LoadScene(2);
    }
  }
}