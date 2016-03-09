using UnityEngine;
using System.Collections;

public class PlayerAttributes : MonoBehaviour {

    public float Speed;
    public float HitPoints;

    public float GetSpeed()
    {
        return Speed;
    }

    public void AddLife(float AddHitPoints)
    {
        HitPoints += AddHitPoints;

        if (HitPoints <= 0)
        {
            Dead();
        }

    }

    void Dead()
    {
        Destroy(gameObject);
    }


}
