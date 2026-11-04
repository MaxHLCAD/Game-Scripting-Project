using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour

{
    public InputActionAsset actions;
    public float playerSpeed = 5f;
    InputAction move;
    Rigidbody2D rb;
    Vector2 movement;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        move = actions.FindAction("player/move");
    }
    void FixedUpdate()
    {
        Vector2 input = move.ReadValue<Vector2>();
        transform.Translate(new Vector2(input.x, input.y) * playerSpeed * Time.deltaTime);
    }

}

