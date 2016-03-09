using UnityEngine;
using System.Collections;
using System;

public class Empty : Stuff
{

    public bool Equip;

    public override bool Equipable()
    {
        throw new NotImplementedException();
    }

    public override string GetName()
    {
        return "Empty";
    }

    public override Sprite GetSprite()
    {
        throw new NotImplementedException();
    }

    public override void Use()
    {
        throw new NotImplementedException();
    }
}
