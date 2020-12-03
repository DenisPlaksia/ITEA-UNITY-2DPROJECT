using UnityEngine;
using System;


public class Weapon : MonoBehaviour
{
    public  event Action<int> ammoAction;

    public static Weapon Singleton { get; private set; }
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _targetPoint;
    [SerializeField] private AudioSource _shootSound;
    public int AmountAmmo { get; private set; }
    private void Awake()
    {
        Singleton = this;
        AmountAmmo = UnityEngine.Random.Range(1, 13);
    }

    private void Start()
    {
        ammoAction?.Invoke(AmountAmmo);
    }

    public void Shoot(float direction)
    {
        if (AmmoCheck())
        {
            _shootSound.Play();
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
