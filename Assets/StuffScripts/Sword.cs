using UnityEngine;
using System.Collections;
using System;

public class Sword : Stuff
{

    bool Equip;
    string Name;
    float Damage;
    float AttackSpeed;
    float Range;
    Sprite sprite;
    Vector2 Position;
    PlayerAttributes PlyAttribute;

    public Sword(float Damage, string Name, bool Equipable, float AttackSpeed, float Range, Sprite sprite)
    {
        this.AttackSpeed = AttackSpeed;
        this.Damage = Damage;
        this.Name = Name;
        this.sprite = sprite;
        this.Range = Range;
        Equip = Equipable;
        PlyAttribute = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>();
    }

    public override bool Equipable()
    {
        return Equip;
    }

    public override string GetName()
    {
        return Name;
    }

    public override void Use()
    {
        if (PlyAttribute.GetTimer() <= 0)
        {
            Position = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y);
            Debug.Log(Name + " Attack!");
            PlyAttribute.SetAttackSpeed(AttackSpeed);
            PlyAttribute.ResetAttackTimer();
            int size = 0;
            GameObject[] Enemy;
            EnemyAttributes[] EnemyHealth;
            Enemy = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject t in Enemy)
            {
                Vector2 EnemyPosition = new Vector2(t.transform.position.x, t.transform.position.y);
                if ((EnemyPosition - Position).magnitude <= Range)
                    ++size;
            }
            EnemyHealth = new EnemyAttributes[size];
            for (int i = 0; i < Enemy.Length; ++i)
            {
                Vector2 EnemyPosition = new Vector2(Enemy[i].transform.position.x, Enemy[i].transform.position.y);
                if (Enemy[i].tag == "Enemy" && (EnemyPosition - Position).magnitude <= Range)
                    EnemyHealth[i] = Enemy[i].GetComponent<EnemyAttributes>();
            }
            foreach (EnemyAttributes t in EnemyHealth)
            {
                t.AddLife(-Damage);
            }
            Debug.Log(EnemyHealth.Length);
        }

    }

    public override Sprite GetSprite()
    {
        return sprite;
    }
}
