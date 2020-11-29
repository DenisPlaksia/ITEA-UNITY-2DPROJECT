using UnityEngine;

public class DangerOffButton : MonoBehaviour
{

    [SerializeField] private GameObject _dangerObjectOff;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Player>() != null)
        {
            Destroy(_dangerObjectOff);
            Destroy(this);
        }
    }
}
