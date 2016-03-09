using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    Rigidbody2D Rb2d;
    Vector2 MoveDirection;
    PlayerAttributes PlayerAtt;
    float Speed;

	// Use this for initialization
	void Start () {

        Rb2d = GetComponent<Rigidbody2D>();
        PlayerAtt = GetComponent<PlayerAttributes>();
	}
	
	// Update is called once per frame
	void Update () {

        Speed = PlayerAtt.GetSpeed();

        MoveDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            MoveDirection += Vector2.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            MoveDirection += Vector2.down;
        }

        if (Input.GetKey(KeyCode.A))
        {
            MoveDirection += Vector2.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveDirection += Vector2.right;
        }
    }

    void FixedUpdate()
    {
        Rb2d.velocity = MoveDirection.normalized * Speed; 

    }
}
