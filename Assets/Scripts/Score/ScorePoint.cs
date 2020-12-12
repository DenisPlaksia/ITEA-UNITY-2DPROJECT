using UnityEngine;

public class ScorePoint : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Player.Singleton.playerData.Score++;
        Player.Singleton.TakeCoins(Player.Singleton.playerData.Score);
        Destroy(gameObject,0.01f);
    }
}
