using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _losePlane;

    private void Start()
    {
        _losePlane.SetActive(false);

        Player.Singleton.deathAction += LoseGame;
    }

    private void LoseGame()
    {
        PlayerController._canMove = false;
        _losePlane.SetActive(true);
    }
}
