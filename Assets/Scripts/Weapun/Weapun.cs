using UnityEngine;

public class Weapun : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _targetPoint;
    public int AmountAmmo { get; private set; }


    private void Start()
    {
        AmountAmmo = Random.Range(0, 11);
    }

    public void Shoot()
    {
        if(AmmoCheck())
        {
            Instantiate(_bullet, _targetPoint.transform.position, Quaternion.identity);
            AmountAmmo--;
        }
    }

    private bool AmmoCheck() => (AmountAmmo > 0) ? true : false;
}
