using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public MoneyandWinLoseConditions moneyScript;

    public void ResetEverything()
    {
        if (LoseCondition.Instance != null)
        {
            LoseCondition.Instance.ResetScore();
        }
        SceneManager.LoadScene("CasinoScene");

        moneyScript.Reset();
    }
}