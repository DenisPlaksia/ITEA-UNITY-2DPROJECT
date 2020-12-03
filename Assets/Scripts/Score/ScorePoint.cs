using UnityEngine;

public class ScorePoint : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Player.Singleton.TakeCoins();
        Destroy(gameObject);
    }
}
