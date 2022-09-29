using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptGanhou : MonoBehaviour
{
  public void jogarNovamente()
  {
    SceneManager.LoadScene(1);
  }

  public void sair()
  {
    Application.Quit();
  }
}
