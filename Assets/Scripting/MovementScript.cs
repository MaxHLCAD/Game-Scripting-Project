using UnityEngine;

public class MovementScript : MonoBehaviour

{
    public float playerSpeed = 5f;
    Vector2 movement;

    void Start()
    {

    }
    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(movement * playerSpeed * Time.deltatime);
    }
 }

