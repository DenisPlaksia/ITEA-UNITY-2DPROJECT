using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Player.Singleton._weapon.AddAmmo(Random.Range(1, 6));
        Destroy(gameObject);
    }
}
