using UnityEngine;
using TMPro;

public class AmmoController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ammoCount;

    private void Start()
    {
        Weapon.Singleton.ammoAction += ShowScore;
    }
    public void ShowScore(int _ammo) => _ammoCount.SetText(_ammo.ToString());
}
