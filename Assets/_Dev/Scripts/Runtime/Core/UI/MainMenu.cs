using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    
    public void Play()
    {
        // SceneManager.LoadScene("");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ShowOptions()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void ShowMainMenu()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
   
}
