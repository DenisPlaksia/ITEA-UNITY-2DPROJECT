using UnityEngine;

public class Ammo : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Player.Singleton.weapon.AddAmmo(Random.Range(1, 6));
        Destroy(gameObject);
    }
}
