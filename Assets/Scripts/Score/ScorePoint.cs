using UnityEngine;

public class ScorePoint : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Player.Singleton._playerData._score++;
        Player.Singleton.TakeCoins(Player.Singleton._playerData._score);
        Destroy(gameObject);
    }
}
