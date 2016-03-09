using UnityEngine;
using System.Collections;
using System;

public class Sword : Stuff{

    public bool Equip;
    public string Name;
    public float Damage;

    public Sword(float Damage, string Name, bool Equipable)
    {
        this.Damage = Damage;
        this.Name = Name;
        Equip = Equipable;
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
        throw new NotImplementedException();
    }

    public override Stuff HardCopy()
    {
        return new Sword(Damage, Name, Equip);
    }
}
