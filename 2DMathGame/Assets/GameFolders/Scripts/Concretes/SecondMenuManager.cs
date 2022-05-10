using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SecondMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _playBut, _backBut;

    [SerializeField] private GameObject _fadePanel;

    private void Start()
    {
        if (_playBut != null)
        {
            _playBut.GetComponent<RectTransform>().localScale = Vector3.zero;
        }

        if(_backBut != null)
        {
            _backBut.GetComponent<RectTransform>().localScale=Vector3.zero;
        }

        _fadePanel.GetComponent<CanvasGroup>().DOFade(0, 1f).OnComplete(FirstSettings);
    }

    void FirstSettings()
    {
        OpenButtons();
    }

    void OpenButtons()
    {
        _playBut.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBounce);
        _backBut.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBounce);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
