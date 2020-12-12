using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _chestDeathParticle;
    [SerializeField] private List<GameObject> _secretObject = new List<GameObject>();

    public void Interact()
    {
        if(Player.Singleton.HasKey)
        {
            Instantiate(_chestDeathParticle, transform.position,Quaternion.identity);
            Instantiate(_secretObject[Random.Range(0,_secretObject.Count)], new Vector2(transform.position.x, transform.position.y + 1.5f), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
