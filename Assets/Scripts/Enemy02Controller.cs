using UnityEngine;
using System.Collections;

public class Enemy02Controller : MonoBehaviour {

    Rigidbody2D Rb2d;
    Vector2 PlayerPosition;
    EnemyAttributes EnemyAttr;
    float Speed;
    float DistanceToTravel;
    public float PatrolRadius;
    bool inPatrolDistance;
    Vector2 MoveDirection;

	// Use this for initialization
	void Start () {

        Rb2d = GetComponent<Rigidbody2D>();
        EnemyAttr = GetComponent<EnemyAttributes>();
	}
	
	// Update is called once per frame
	void Update () {
        MoveDirection = Vector2.zero;
        PlayerPosition = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y);
        Speed = EnemyAttr.GetSpeed();

        Vector2 DistanceVector = new Vector2(PlayerPosition.x - transform.position.x, PlayerPosition.y - transform.position.y);
        float DistanceToPlayer = DistanceVector.magnitude;
        DistanceToTravel = Speed;

        Debug.Log(DistanceToPlayer);

        
        if(DistanceToPlayer + 0.001 > PatrolRadius)
        {
            if(DistanceToPlayer - PatrolRadius > DistanceToTravel)
            {
                MoveDirection = (PlayerPosition - new Vector2(transform.position.x, transform.position.y)).normalized * DistanceToTravel;
                DistanceToTravel = 0;
            }
            else
            {
                float DistanceToPatrolRadius = DistanceToPlayer - PatrolRadius;
                MoveDirection = (PlayerPosition - new Vector2(transform.position.x, transform.position.y)).normalized * DistanceToPatrolRadius;
                DistanceToTravel = DistanceToTravel - DistanceToPatrolRadius;
            }
        }
        else if(DistanceToPlayer < PatrolRadius)
        {
            if (PatrolRadius - DistanceToTravel > DistanceToTravel)
            {
                MoveDirection = (new Vector2(transform.position.x, transform.position.y) - PlayerPosition).normalized * DistanceToTravel;
                DistanceToTravel = 0;
            }
            else
            {
                float DistanceToPatrolRadius = PatrolRadius - DistanceToPlayer;
                MoveDirection = (new Vector2(transform.position.x, transform.position.y) - PlayerPosition).normalized * DistanceToPatrolRadius;
                DistanceToTravel = DistanceToTravel - DistanceToPatrolRadius;
            }
        }

        float NewX = MoveDirection.x * Mathf.Cos(90) - MoveDirection.y * Mathf.Sin(90);
        float NewY = MoveDirection.x * Mathf.Sin(90) - MoveDirection.y * Mathf.Cos(90);
        Vector2 PatrolDirection = new Vector2(NewX, NewY).normalized * DistanceToTravel;

        MoveDirection += PatrolDirection;
    }

    void FixedUpdate()
    {
        Rb2d.velocity = MoveDirection; 
    }
}
