using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseController : MonoBehaviour
{
    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _quitGameButton;

    private void Start()
    {
        _newGameButton.onClick.AddListener(NewGame);
        _quitGameButton.onClick.AddListener(QuitGame);
    }

    private void NewGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    private void QuitGame() => Application.Quit();
}
