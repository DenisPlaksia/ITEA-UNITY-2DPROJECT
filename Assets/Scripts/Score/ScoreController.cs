using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    

    private void Start()
    {
        //_scoreText = GetComponent<TextMeshPro>();
        Player.Singleton.coinsAction += ShowScore;
    }
    public void ShowScore(int _score)
    {
        _scoreText.SetText(_score.ToString());
    }
}
