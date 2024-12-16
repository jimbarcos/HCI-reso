using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionButton : MonoBehaviour
{
   public void BackMainMenu()
   {
        SceneManager.LoadScene(0);
   }

   public void PlayGame()
   {
        SceneManager.LoadScene(1);
   }



}
