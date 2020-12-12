using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IDamage
{
    private float _health = 150;
    public void GetDamage(float damage)
    {
        _health -= damage;
        if(_health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }

}
