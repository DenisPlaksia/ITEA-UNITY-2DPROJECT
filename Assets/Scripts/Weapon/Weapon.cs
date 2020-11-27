using UnityEngine;

public class Weapon : MonoBehaviour
{
    public delegate void AmmoAction(int _coinCount);
    public event AmmoAction ammoAction;

    public static Weapon Singleton { get; private set; }
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _targetPoint;
    public int AmountAmmo { get; private set; }

    private void Awake()
    {
        Singleton = this;
    }
    private void Start()
    {
        AmountAmmo = Random.Range(1, 11);
        ammoAction?.Invoke(AmountAmmo);
    }

    public void Shoot(float angle)
    {
        if(AmmoCheck())
        {
            Instantiate(_bullet, _targetPoint.transform.position, Quaternion.Euler(new Vector3(0f,0f,angle)));
            AmountAmmo--;
            ammoAction?.Invoke(AmountAmmo);
        }
    }

    private bool AmmoCheck() => (AmountAmmo > 0) ? true : false;
}
