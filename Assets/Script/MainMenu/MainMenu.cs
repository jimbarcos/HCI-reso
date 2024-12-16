using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text LevelText1;
    [SerializeField] private TMP_Text LevelText2;
    [SerializeField] private TMP_Text LevelText3;
    [SerializeField] private TMP_Text Title;
    [SerializeField] private GameObject MainMenuCanvas;
    [SerializeField] private GameObject PlayQuit;
    [SerializeField] Animator TransitionAnim;
    [SerializeField] private GameObject SettingsCanvas;
    [SerializeField] private GameObject ResetCanvas;
    [SerializeField] private GameObject SettingsButton;

    public void PlayApp()
    {
        SceneManager.LoadScene(1);
    }

    public void CloseApp()
    {
        Application.Quit();
    }

    public void OnHoverEnterLevel1()
    {
        LevelText1.color = Color.cyan;
    }

    public void OnHoverExitLevel1()
    {
        LevelText1.color = Color.white; // Or the default color you prefer
    }

    public void OnHoverEnterLevel2()
    {
        LevelText2.color = Color.cyan;
    }

    public void OnHoverExitLevel2()
    {
        LevelText2.color = Color.white; // Or the default color you prefer
    }

    public void OnHoverEnterLevel3()
    {
        LevelText3.color = Color.cyan;
    }

    public void OnHoverExitLevel3()
    {
        LevelText3.color = Color.white; // Or the default color you prefer
    }


    public void InactivateMenu()
    {
        MainMenuCanvas.gameObject.SetActive(false);
        PlayQuit.gameObject.SetActive(true);
        SettingsButton.gameObject.SetActive(true);
    }

    public void ActivateMenu()
    {
        MainMenuCanvas.gameObject.SetActive(true);
        PlayQuit.gameObject.SetActive(false);
        SettingsButton.gameObject.SetActive(false);
    }



    public void OpenSettings()
    {
        SettingsCanvas.gameObject.SetActive(true);
        MainMenuCanvas.gameObject.SetActive(false);
        Title.gameObject.SetActive(false);
        SettingsButton.gameObject.SetActive(false);
    }

    public void CloseSettings()
    {
        SettingsCanvas.gameObject.SetActive(false);
        Title.gameObject.SetActive(true);
        SettingsButton.gameObject.SetActive(true);
        MainMenuCanvas.gameObject.SetActive(true);
    }


    public void CloseSettings1()
    {
        SettingsCanvas.gameObject.SetActive(false);
        Title.gameObject.SetActive(true);
        SettingsButton.gameObject.SetActive(true);
        MainMenuCanvas.gameObject.SetActive(true);
    }

    public void OpenReset()
    {
        ResetCanvas.gameObject.SetActive(true);
        SettingsCanvas.gameObject.SetActive(false);
    }

    public void CloseReset()
    {
        ResetCanvas.gameObject.SetActive(false);
        SettingsCanvas.gameObject.SetActive(true);
    }
    
    public void ResetProgress() {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    //IEnumerator LoadLevel()
    //{
    //    TransitionAnim.SetTrigger("End");
    //    yield return new WaitForSeconds(1);
    //    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

    //    TransitionAnim.SetTrigger("Start");
    //}
}
