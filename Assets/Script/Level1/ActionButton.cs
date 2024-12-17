using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionButton : MonoBehaviour
{

    [SerializeField] private GameObject MenuPanel;

   public void BackMainMenu()
   {
        SceneManager.LoadScene(0);
   }

   public void PlayGameLvl1()
   {
        SceneManager.LoadScene(1);
   }


    public void OpenMenuPanel()
    {
        MenuPanel.SetActive(true);
    }


    public void ExitMenuPanel()
    {
        MenuPanel.SetActive(false);
    }


}
