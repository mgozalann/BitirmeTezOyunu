using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class ResultManager : MonoBehaviour
{
    [SerializeField] private Text trueNumText, falseNumText, totalScoreText;

    private void OnEnable()
    {
        GetComponent<CanvasGroup>().DOFade(1, 1f);
        Random.Range(1, 10)
    }

    public void GetResults(int trueNum,int falseNum,int totalScore)
    {
        trueNumText.text = trueNum.ToString() + " Adet";
        falseNumText.text = falseNum.ToString() + " Adet";
        totalScoreText.text = totalScore.ToString() + " Puan";
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
}
