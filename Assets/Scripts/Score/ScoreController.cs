﻿using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    

    private void Start()
    {
        Player.Singleton.coinsAction += ShowScore;
    }

    private void ShowScore(int _score) => _scoreText.SetText(_score.ToString());
}
