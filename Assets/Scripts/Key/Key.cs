using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Player.Singleton.HasKey = true;
        Destroy(gameObject);
    }
}
