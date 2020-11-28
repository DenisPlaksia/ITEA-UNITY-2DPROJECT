using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DengerObject : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.GetDamage(100f);
        }
    }
}
