using UnityEngine;

public class BarScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("u diggin in me son");
        }
    }
}
