using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private TMP_Text resultScoreText;
    [SerializeField] private Button startButton;
    [SerializeField] private Button retryButton;
    [SerializeField] private Canvas startCanvas;
    [SerializeField] private Canvas gameCanvas;
    [SerializeField] private Canvas resultCanvas;


    public event Action OnStartButtonClick;
    public event Action OnRetryButtonClick;


    private void OnEnable()
    {
        startButton.onClick.AddListener(StartButtonClick);
        retryButton.onClick.AddListener(RetryButtonClick);
    }


    private void OnDisable()
    {
        startButton.onClick.RemoveAllListeners();
        retryButton.onClick.RemoveAllListeners();
    }


    public void SetCountdownText(string text)
    {
        countdownText.text = text;
    }


    public void SetGameScoreText(string text)
    {
        scoreText.text = text;
    }


    public void SetResultScoreText(string text)
    {
        resultScoreText.text = text;
    }


    public void SetStartCanvasActive(bool active) => startCanvas.gameObject.SetActive(active);
    public void SetGameCanvasActive(bool active) => gameCanvas.gameObject.SetActive(active);
    public void SetResultCanvasActive(bool active) => resultCanvas.gameObject.SetActive(active);



    private void StartButtonClick()
    {
        OnStartButtonClick?.Invoke();
    }


    private void RetryButtonClick()
    {
        OnRetryButtonClick?.Invoke();
    }
}
