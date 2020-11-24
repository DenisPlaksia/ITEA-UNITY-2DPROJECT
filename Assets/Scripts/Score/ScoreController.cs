using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    private void Start()
    {
        Player.Singleton.coinsAction += ShowScore;
    }
    public void ShowScore(int _score)
    {
        _scoreText.text = _score.ToString();
    }
}
