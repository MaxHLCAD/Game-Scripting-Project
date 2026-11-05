using UnityEngine;
using UnityEngine.SceneManagement;

public class BarScript : MonoBehaviour
{
    private bool isOverlapping = false;
    private SpriteRenderer spriteRenderer; // for changing sprite colors

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player") && isOverlapping == false) // without the && it will repeatedly call this
        {
            isOverlapping = true;
            Debug.Log("overlapping is set to " + isOverlapping);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOverlapping = false;
            Debug.Log("overlapping is set to " + isOverlapping);
        }
    }
    void Update()
    {
        if (isOverlapping == true)
        {
            spriteRenderer.color = Color.white;
        }
        else
        {
            spriteRenderer.color = Color.saddleBrown; // feel free to change this i just picked a random color
        }

        if (Input.GetKeyDown(KeyCode.Return) && isOverlapping == true) // return is the enter key
        {
            SceneManager.LoadScene("BarScene");
        }

    }
}
