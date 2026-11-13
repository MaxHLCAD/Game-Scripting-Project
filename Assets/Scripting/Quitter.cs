using UnityEngine;

public class Quitter : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Leaving game");
        Application.Quit();
    }
}
