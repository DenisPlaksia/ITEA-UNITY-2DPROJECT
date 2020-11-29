using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour, ITakeable
{
    public void Take()
    {
        Player.Singleton._weapun.AddAmmo(Random.Range(1, 6));
        Destroy(gameObject);
    }
}
