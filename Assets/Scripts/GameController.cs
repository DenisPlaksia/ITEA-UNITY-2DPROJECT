using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _winPanel;

    private void Start()
    {
        _losePanel.SetActive(false);
        _winPanel.SetActive(false);

        Player.Singleton.deathAction += LoseGame;
        Player.Singleton.winAction += WinGame;
    }

    private void LoseGame()
    {
        PlayerController._canMove = false;
        _losePanel.SetActive(true);
    }

    private void WinGame()
    {
        PlayerController._canMove = false;
        _winPanel.SetActive(true);
    }
}
