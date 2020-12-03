using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoseContrller : MonoBehaviour
{
    [SerializeField] private Button _newGameButton;


    private void Start()
    {
        _newGameButton.onClick.AddListener(NewGame);
    }


    private void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
