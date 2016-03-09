using UnityEngine;
using System.Collections;

public class SwordCollision : MonoBehaviour {

    public float Damage;
    public float AttackSpeed;
    public string Name;
    public bool Equip;
    public float Range;
    Sword sword;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            sword = new Sword(Damage, Name, Equip, AttackSpeed,Range, GetComponent<SpriteRenderer>().sprite);
            other.GetComponent<PlayerInventory>().AddItem(sword);
            Destroy(gameObject);
        }
    }
}
