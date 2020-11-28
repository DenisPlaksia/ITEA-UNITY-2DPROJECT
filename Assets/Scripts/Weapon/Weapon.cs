using UnityEngine;
using System;


public class Weapon : MonoBehaviour
{
    public static event Action<int> ammoAction;

    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _targetPoint;
    public int AmountAmmo { get; private set; }

    private void Start()
    {
        AmountAmmo = UnityEngine.Random.Range(1, 13);
        ammoAction?.Invoke(AmountAmmo);
    }

    public void Shoot(float direction)
    {
        if (AmmoCheck())
        {
            Instantiate(_bullet, _targetPoint.transform.position, Quaternion.Euler(new Vector3(0f, 0f, direction)));
            AmountAmmo--;
            ammoAction?.Invoke(AmountAmmo);
        }
    }

    public void AddAmmo(int ammo)
    {
        AmountAmmo += ammo;
        ammoAction?.Invoke(AmountAmmo);
    }

    private bool AmmoCheck() => (AmountAmmo > 0) ? true : false;
}
