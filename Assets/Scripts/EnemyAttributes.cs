using UnityEngine;
using System.Collections;

public class EnemyAttributes : MonoBehaviour {
    public float HitPoints;
    public float Speed;
    public float CollisionDamage;
    public float BulletDamage;
    public bool isRanged;

    void Start()
    {
        GetComponent<CollisionWithPlayer>().SetDamage(CollisionDamage);
    }

    public float GetSpeed()
    {
        return Speed;
    }

    public void AddLife(float AddHitPoints)
    {
        HitPoints += AddHitPoints;
        if (HitPoints <= 0)
            Dead();
    }

    void Dead()
    {
        Destroy(gameObject);
    }
}
