using UnityEngine;
using UnityEngine.SceneManagement;

public class MoneyandWinLoseConditions : MonoBehaviour
{
    public int money = 500;
    public bool hasWon = false;
    public bool hasLost = false;
    public GameObject player; // refers to player in inspector
    public float playerDeathTimer = 0f; // see void FixedUpdate() below  for context
    public bool startDeathTimer = false; // ^

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Equals)) // debug code; DELETE LATER!!
        {
            money += 100;
        }
        if (Input.GetKeyDown(KeyCode.Minus)) // debug code; DELETE LATER!!
        {
            money -= 100;
        }


        if (money <= 0 && hasLost == false) // lose condition
        {
            YouLose(); // seperate function in case we want other ways to lose
        }

        if (money >= 1000 && hasWon == false) // win condition
        {
            YouWin(); // seperate function in case we want more ways to win
        }
    }


    void YouLose()
    {
        hasLost = true;
        startDeathTimer = true;
        Destroy(player);
    }

    void YouWin()
    {
        hasWon = true; 
        Debug.Log("ya did it bud");
        SceneManager.LoadScene("WinScreen");
    }

    // i thought itd be funny if the player just dies before it takes you to the loss screen; remove if yall want
    void FixedUpdate()
    {
        if (startDeathTimer == true && hasLost == true) 
        {
            playerDeathTimer += Time.fixedDeltaTime;
            Debug.Log(playerDeathTimer);

            if (playerDeathTimer >= 5f)
            {
                playerDeathTimer = 0f;
                startDeathTimer = false;
                Debug.Log("you tapped out...");
                SceneManager.LoadScene("LoseScreen");
            }
        }
    }
}
