using UnityEngine;
using UnityEngine.UI;

public class AmmoController : MonoBehaviour
{
    private Text _ammoCount;

    private void Start()
    {
        _ammoCount = GetComponent<Text>();
        Weapun.Singleton.ammoAction += ShowScore;
    }
    public void ShowScore(int _ammo)
    {
        _ammoCount.text = _ammo.ToString();
    }
}
