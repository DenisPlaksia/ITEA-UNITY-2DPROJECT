using UnityEngine;

public class ScorePoint : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.TakeCoins();
            Destroy(gameObject);
        }
    }
}
