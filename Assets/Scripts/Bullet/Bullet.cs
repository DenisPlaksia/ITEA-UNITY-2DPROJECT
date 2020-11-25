using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _force = 50f;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        BulletPush();
        Destroy(gameObject, 2f);
    }

    private void BulletPush() => _rigidbody2D.AddForce(transform.forward * _force, ForceMode2D.Impulse);

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<IDamage>() != null)
        {
            collision.gameObject.GetComponent<IDamage>().GetDamage(100f);
        }
    }
}
