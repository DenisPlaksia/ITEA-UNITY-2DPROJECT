using UnityEngine;
using TMPro;

public class AmmoController : MonoBehaviour
{
    private TextMeshProUGUI _ammoCount;

    private void Start()
    {
        _ammoCount = GetComponent<TextMeshProUGUI>();
        Weapon.ammoAction += ShowScore;
    }
    public void ShowScore(int _ammo)
    {
        _ammoCount.SetText(_ammo.ToString());
    }
}
