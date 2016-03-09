using UnityEngine;
using System.Collections;

public class Enemy01Controller : MonoBehaviour
{

    Rigidbody2D Rb2d;
    public float Speed;
    Vector2 PlayerPosition;

    // Use this for initialization
    void Start()
    {

        Rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        PlayerPosition = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y);
        
    }

    void FixedUpdate()
    {
        Rb2d.velocity = (PlayerPosition - new Vector2(transform.position.x, transform.position.y)).normalized * Speed;
    }
}
