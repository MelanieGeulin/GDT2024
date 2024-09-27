using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int _scoreToGet = 2;
    [SerializeField]
    private TMP_Text _scoreText;
    [SerializeField]
    private GameObject _winPanel;

    private int _currentScore;

    private void OnEnable()
    {
        CoinScript.OnPickUpCoin += UpdateScore;
    }
    private void OnDisable()
    {
        CoinScript.OnPickUpCoin -= UpdateScore;
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentScore = 0;
        _winPanel.SetActive(false);

        _scoreText.text = $"{_currentScore} / {_scoreToGet}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowWinPanel()
    {
        _winPanel.SetActive(true);
    }

    public void UpdateScore()
    {
        _currentScore++;
        _scoreText.text = $"{_currentScore} / {_scoreToGet}";

        if (_currentScore >= _scoreToGet)
        {
            ShowWinPanel();
        }

    }
}
