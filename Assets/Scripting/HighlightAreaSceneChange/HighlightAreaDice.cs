using UnityEngine;
using UnityEngine.SceneManagement;

public class HighlightAreaDice : MonoBehaviour
{
    public Transform player; //add player in inspector
    public float interactionDistance = 3f; //distance to interact with
    private bool isPlayerInRange = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (player == null) return;
        float distance = Vector2.Distance(transform.position, player.position);
        //distance of player to highlight area

        if (distance <= interactionDistance)
        {
            if (!isPlayerInRange)
            {
                isPlayerInRange = true;
                Debug.Log("Player in highlight zone");
            }
            spriteRenderer.color = Color.yellow; //change to whatever color we want later on

            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("DiceScene");
            }
        }
        else
        {
            if (isPlayerInRange)
            {
                isPlayerInRange = false;
                Debug.Log("Player left highlight zone");
            }
            spriteRenderer.color = Color.orange; //change back to whatever original color is

        }
    }
}