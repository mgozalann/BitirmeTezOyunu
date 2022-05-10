using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Sprite[] kokIciResimler, kokDisiResimler;
    [SerializeField] private Image purpleNonRoot, blueNonRoot, blackNonRoot;
    [SerializeField] private Image orangeNonRoot, redNonRoot, greenNonRoot;
    [SerializeField] private Image upperQuery, lowerQuery;
    [SerializeField] private Image leftGrate, rightGrate;
    [SerializeField] GameObject wheel;
    [SerializeField] private Image trueIcon, falseIcon;
    [SerializeField] private GameObject icons;
    [SerializeField] private Text trueNumText, falseNumText, totalScoreText;


    public int TrueNum => trueNum;
    public int FalseNum => falseNum;
    public int TotalScore => totalScore;

    private bool circleOnTop;
    private bool isTurnedFinished;


    private int whichQuery;
    private int wrongAnswerCount;
    int trueNum, falseNum, totalScore;



    private Image imageOnButton;

    private void Start()
    {
        circleOnTop = true;

        isTurnedFinished = true;
        trueNum = 0;
        falseNum = 0;
        totalScore = 0;
        trueNumText.text = trueNum.ToString();
        falseNumText.text = falseNum.ToString();
        totalScoreText.text = totalScore.ToString();

        GetImages();
    }
    private void Update()
    {
        ChaseGrates();
    }
    public void ButonaBasýldý(string name)
    {
        switch (name)
        {
            case "Purple":
                imageOnButton = purpleNonRoot;
                break;
            case "Green":
                imageOnButton = greenNonRoot;
                break;
            case "Blue":
                imageOnButton = blueNonRoot;
                break;
            case "Red":
                imageOnButton = redNonRoot;
                break;
            case "Orange":
                imageOnButton = orangeNonRoot;
                break;
            default:
                imageOnButton = blackNonRoot;
                break;
        }
        CheckTheResult();
    }

    public void BackToTheMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    private void CheckTheResult()
    {
        if(!isTurnedFinished) return;
        if (imageOnButton.sprite == kokDisiResimler[whichQuery])
        {
            isTurnedFinished = false;
            wheel.transform.DORotate(wheel.transform.rotation.eulerAngles + new Vector3(0, 0, 180), 1f);
            isTurnedFinished = true;


            wrongAnswerCount = 0;
            trueNum++;
            trueNumText.text = trueNum.ToString();
            totalScore += 20;
            totalScoreText.text = totalScore.ToString();

            GetImages();
            SetIcons(true);
        }
        else
        {
            if (wrongAnswerCount == 2) return;
            falseNum++;
            falseNumText.text = falseNum.ToString();
            totalScore -= 5;
            totalScoreText.text = totalScore.ToString();

            wrongAnswerCount++;
            SetIcons(false);
        }
    }

    private void ChaseGrates()
    {
        switch (wrongAnswerCount)
        {
            case 0:
                leftGrate.transform.localPosition = new Vector3(-190, 57, 0);
                rightGrate.transform.localPosition = new Vector3(200, 57, 0);
                break;
            case 1:
                leftGrate.transform.DOLocalMove(new Vector3(-133, 57, 0), .2f);
                rightGrate.transform.DOLocalMove(new Vector3(141.5f, 57, 0), .2f);
                break;
            case 2:
                leftGrate.transform.DOLocalMove(new Vector3(-76, 57, 0), .2f);
                rightGrate.transform.DOLocalMove(new Vector3(83, 57, 0), .2f);
                Invoke("WaitForGratesClosing", 1f);
                break;
            default:
                break;
        }
    }

    void WaitForGratesClosing()
    {
        if (wrongAnswerCount == 2)
        {
            wrongAnswerCount = 0;
            isTurnedFinished = false;
            wheel.transform.DORotate(wheel.transform.rotation.eulerAngles + new Vector3(0, 0, 180), 0.5f);
            isTurnedFinished = true;
            GetImages();
        }
    }

    void SetIcons(bool isTrue)
    {
        icons.GetComponent<CanvasGroup>().alpha = 1;
        trueIcon.gameObject.SetActive(isTrue);
        falseIcon.gameObject.SetActive(!isTrue);
        icons.GetComponent<CanvasGroup>().DOFade(0, 1f);
    }
    void GetImages()
    {
        whichQuery = Random.Range(0, kokIciResimler.Length - 3);
        int randomValue = Random.Range(0, 100);

        if (circleOnTop)
        {
            upperQuery.sprite = kokIciResimler[whichQuery];
            if (randomValue <= 33)
            {
                purpleNonRoot.sprite = kokDisiResimler[whichQuery];
                blueNonRoot.sprite = kokDisiResimler[whichQuery + 1];
                blackNonRoot.sprite = kokDisiResimler[whichQuery + 2];
            }
            else if (randomValue >= 66)
            {
                purpleNonRoot.sprite = kokDisiResimler[whichQuery + 1];
                blueNonRoot.sprite = kokDisiResimler[whichQuery];
                blackNonRoot.sprite = kokDisiResimler[whichQuery + 2];
            }
            else
            {
                purpleNonRoot.sprite = kokDisiResimler[whichQuery + 1];
                blueNonRoot.sprite = kokDisiResimler[whichQuery + 2];
                blackNonRoot.sprite = kokDisiResimler[whichQuery];
            }
        }
        else
        {
            lowerQuery.sprite = kokIciResimler[whichQuery];
            if (randomValue <= 33)
            {
                orangeNonRoot.sprite = kokDisiResimler[whichQuery];
                redNonRoot.sprite = kokDisiResimler[whichQuery + 1];
                greenNonRoot.sprite = kokDisiResimler[whichQuery + 2];
            }
            else if (randomValue >= 66)
            {
                orangeNonRoot.sprite = kokDisiResimler[whichQuery + 1];
                redNonRoot.sprite = kokDisiResimler[whichQuery];
                greenNonRoot.sprite = kokDisiResimler[whichQuery + 2];
            }
            else
            {
                orangeNonRoot.sprite = kokDisiResimler[whichQuery + 2];
                redNonRoot.sprite = kokDisiResimler[whichQuery + 1];
                greenNonRoot.sprite = kokDisiResimler[whichQuery];
            }
        }
        circleOnTop = !circleOnTop;
    }
}
