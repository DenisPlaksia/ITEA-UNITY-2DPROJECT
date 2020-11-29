using UnityEngine;

public class ScorePoint : MonoBehaviour, ITakeable
{
    public void Take()
    {
        Player.Singleton.TakeCoins();
        Destroy(gameObject);
    }
}
