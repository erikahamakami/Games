using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptPC : MonoBehaviour
{
  private Rigidbody2D rbd;
  private Animator anim;
  public float velocidade = 5;
  public float pulo = 250;
  public float queda = -0.2f;
  private bool chao = true;
  private bool direita = true;
  private bool pausado = false;
  public LayerMask mascara;
  public LayerMask mascara2;
  public LayerMask mascara3;
  public LayerMask mascara4;


  // Start is called before the first frame update
  void Start()
  {
    rbd = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    chao = true;
    transform.parent = collision.transform;
  }
  private void OnCollisionExit2D(Collision2D collision)
  {
    chao = false;
    transform.parent = null;
  }

  // Update is called once per frame
  void Update()
  {
    float x = Input.GetAxis("Horizontal");

    // Debug.Log(chao);

    if (x == 0)
      anim.SetBool("parado", true);
    else
      anim.SetBool("parado", false);

    if (direita && x < 0 || !direita && x > 0)
    {
      direita = !direita;
      transform.Rotate(new Vector2(0, 180));
    }

    if (rbd.velocity.y < 0)
      rbd.velocity = new Vector2(x * velocidade, rbd.velocity.y + queda);
    else
      rbd.velocity = new Vector2(x * velocidade, rbd.velocity.y);

    if (Input.GetKeyDown(KeyCode.Space) && chao)
    {
      chao = false;
      rbd.AddForce(new Vector2(0, pulo));
    }

    //Matar inimigo pulando em cima dele
    RaycastHit2D hit;
    hit = Physics2D.Raycast(transform.position, -transform.up, 0.5f, mascara);
    if (hit.collider != null)
      Destroy(hit.collider.gameObject);

    //Gato morre quando encostar no inimigo
    RaycastHit2D hit2;
    hit2 = Physics2D.Raycast(transform.position, transform.right, 0.5f, mascara2);
    if (hit2.collider != null)
      SceneManager.LoadScene(3);

    //Queda
    RaycastHit2D hit3;
    hit3 = Physics2D.Raycast(transform.position, -transform.up, 0.5f, mascara3);
    if (hit3.collider != null)
      SceneManager.LoadScene(2);

    //Destroi plataforma de madeira
    RaycastHit2D hit4;
    hit4 = Physics2D.Raycast(transform.position, -transform.up, 0.5f, mascara4);
    if (hit4.collider != null)
      Destroy(hit4.collider.gameObject);



    //Pausa e despausa jogo
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      if (pausado == true)
      {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync(4);
      }
      else
      {
        Time.timeScale = 0;
        SceneManager.LoadSceneAsync(4, LoadSceneMode.Additive);
      }
      pausado = !pausado;
    }
  }
}