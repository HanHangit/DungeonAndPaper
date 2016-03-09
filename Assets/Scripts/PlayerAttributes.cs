using UnityEngine;
using System.Collections;

public class PlayerAttributes : MonoBehaviour
{

    public float Speed;
    public float HitPoints;
    float AttackSpeed;
    float Timer;
    public float GetSpeed()
    {
        return Speed;
    }

    public void SetAttackSpeed(float atkspeed)
    {
        AttackSpeed = atkspeed;
    }

    public void ResetAttackTimer()
    {
        Timer = AttackSpeed;
    }

    public float GetTimer()
    {
        return Timer;
    }

    public void AddLife(float AddHitPoints)
    {
        HitPoints += AddHitPoints;

        if (HitPoints <= 0)
        {
            Dead();
        }

    }

    void Update()
    {
        Timer -= Time.deltaTime;
    }

    void Dead()
    {
        Destroy(gameObject);
    }


}
