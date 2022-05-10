using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeManager : MonoBehaviour
{
    [SerializeField] float maxTime;
    [SerializeField] Text timeText;
    [SerializeField] GameObject gameOverPanel;

    GameManager gameManager;
    ResultManager resultManager;

    private void Start()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
        resultManager = gameOverPanel.GetComponent<ResultManager>();
        gameOverPanel.SetActive(false);
    }
    void Update()
    {
        if(maxTime > 0)
        {
            maxTime -= Time.deltaTime;
            timeText.text = ((int)maxTime).ToString();
        }
        else
        {
            gameOverPanel.SetActive(true);
            resultManager.GetResults(gameManager.TrueNum, gameManager.FalseNum, gameManager.TotalScore);
        }
    }
}
