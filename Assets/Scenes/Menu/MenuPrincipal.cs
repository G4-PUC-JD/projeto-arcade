using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPrincipal : MonoBehaviour
{
   public void Jogar ()
   {
    SceneManager.LoadScene("PrimeiraFase");
   }
   public void VoltarMenu ()
   {
    SceneManager.LoadScene("Menu");
   }
   public void Sair ()
   {
    Application.Quit();
   }
}
