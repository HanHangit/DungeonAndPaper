using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D Rb2d;
    Vector2 MoveDirection;
    PlayerAttributes PlayerAtt;
    PlayerInventory Inventory;
    float Speed;

    // Use this for initialization
    void Start()
    {
        Inventory = GetComponent<PlayerInventory>();
        Rb2d = GetComponent<Rigidbody2D>();
        PlayerAtt = GetComponent<PlayerAttributes>();
    }

    void KeyboardInput()
    {

        if (Input.GetKey(KeyCode.W))
            MoveDirection += Vector2.up;

        if (Input.GetKey(KeyCode.S))
            MoveDirection += Vector2.down;

        if (Input.GetKey(KeyCode.A))
            MoveDirection += Vector2.left;

        if (Input.GetKey(KeyCode.D))
            MoveDirection += Vector2.right;

        if (Input.GetKey(KeyCode.Keypad1))
            Inventory.UseItem(0);
        if (Input.GetKey(KeyCode.Keypad2))
            Inventory.UseItem(1);
        if (Input.GetKey(KeyCode.Keypad3))
            Inventory.UseItem(2);
    }

    // Update is called once per frame
    void Update()
    {

        Speed = PlayerAtt.GetSpeed();
        MoveDirection = Vector2.zero;
        KeyboardInput();

    }

    void FixedUpdate()
    {
        Rb2d.velocity = MoveDirection.normalized * Speed;

    }
}
