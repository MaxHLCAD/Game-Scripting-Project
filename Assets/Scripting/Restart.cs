using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void ResetEverything()
    {
        if (LoseCondition.Instance != null)
        {
            LoseCondition.Instance.ResetScore();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}