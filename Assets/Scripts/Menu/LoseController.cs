using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoseController : MonoBehaviour
{
    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _quitGameButton;
    [SerializeField] private TextMeshProUGUI _score;

    private void Start()
    {
        ShowScore();
        _newGameButton.onClick.AddListener(NewGame);
        _quitGameButton.onClick.AddListener(QuitGame);
    }

    private void ShowScore()
    {
        _score.SetText(Player.Singleton._playerData._score.ToString());
    }


    private void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

}
