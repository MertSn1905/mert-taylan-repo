using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int playerId; // 1 veya 2
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement = Vector2.zero;

        if (playerId == 1)
        {
            // PLAYER 1 ? WASD
            if (Input.GetKey(KeyCode.A)) movement.x = -1;
            if (Input.GetKey(KeyCode.D)) movement.x = 1;
            if (Input.GetKey(KeyCode.W)) movement.y = 1;
            if (Input.GetKey(KeyCode.S)) movement.y = -1;
        }
        else if (playerId == 2)
        {
            // PLAYER 2 ? OK TU�LARI
            if (Input.GetKey(KeyCode.LeftArrow)) movement.x = -1;
            if (Input.GetKey(KeyCode.RightArrow)) movement.x = 1;
            if (Input.GetKey(KeyCode.UpArrow)) movement.y = 1;
            if (Input.GetKey(KeyCode.DownArrow)) movement.y = -1;
        }

        movement = movement.normalized;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }
}
