using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptGameOver : MonoBehaviour
{
  public void tentarNovamente()
  {
    SceneManager.LoadScene(1);
  }

  public void sair()
  {
    Application.Quit();
  }
}