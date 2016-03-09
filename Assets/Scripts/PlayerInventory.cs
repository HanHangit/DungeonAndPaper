using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour
{
    Stuff[] Inventory;
    bool[] FreePlaces;

    public int Size;
    void Start()
    {
        for (int i = 0; i < Inventory.Length; ++i)
        {
            Inventory[i] = new Empty();
            FreePlaces[i] = true;
        }
    }

    public void UseItem(int number)
    {
        if (!FreePlaces[number])
            Inventory[number].Use();
    }

    public void AddItem(Stuff ToAdd)
    {
        for (int i = 0; i < Inventory.Length; ++i)
        {
            if (FreePlaces[i])
                Inventory[i] = ToAdd;
        }
    }
}
