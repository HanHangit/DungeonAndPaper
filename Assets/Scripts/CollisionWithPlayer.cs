using UnityEngine;
using System.Collections;

public class CollisionWithPlayer : MonoBehaviour {

    float Damage;

    public void SetDamage(float AddDamage)
    {
        Damage = AddDamage;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerAttributes>().AddLife(-Damage);
        }
    }

}
