using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public void PlayerInteract()
    {
        // remember that the player has "picked up" the object
        Inventory.main.hasKey = true;

        // remember that the player has "picked up" the object.
        
        Destroy(gameObject);
    }
}
