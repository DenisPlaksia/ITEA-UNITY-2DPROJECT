using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Destroy(gameObject, 0.3f);
        }
    }
}
