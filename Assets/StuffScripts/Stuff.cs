using UnityEngine;
using System.Collections;

public abstract class Stuff : MonoBehaviour {

    public abstract void Use();
    public abstract string GetName();
    public abstract bool Equipable();
    public abstract Stuff HardCopy();
}
