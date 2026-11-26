using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene(1); // Load constantscene
    }

    public void QuitButton()
    {
        Application.Quit(); // Quit application 
    }
}