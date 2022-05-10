using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private bool circleOnTop;
    private int whichQuery;
    private int wrongAnswerCount;

    private Image imageOnButton;

    private void Start()
    {
        circleOnTop = true;
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

    private void CheckTheResult()
    {
        if (imageOnButton.sprite == kokDisiResimler[whichQuery])
        {
            wheel.transform.DORotate(wheel.transform.rotation.eulerAngles + new Vector3(0,0,180),1f);
            GetImages();
            wrongAnswerCount = 0;
        }
        else
        {
            if (wrongAnswerCount > 2) return;
            wrongAnswerCount++;
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
                rightGrate.transform.DOLocalMove(new Vector3(83, 57, 0), .2f).OnComplete(WaitForGratesClosing);
                break;
            default:              
                break;
        }
    }

    void WaitForGratesClosing()
    {
        wheel.transform.DORotate(wheel.transform.rotation.eulerAngles + new Vector3(0, 0, 180), 1f);
        GetImages();
        wrongAnswerCount = 0;
        
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
                blackNonRoot.sprite = kokDisiResimler[whichQuery - 1];
            }
            else if (randomValue >= 66)
            {
                purpleNonRoot.sprite = kokDisiResimler[whichQuery + 1];
                blueNonRoot.sprite = kokDisiResimler[whichQuery];
                blackNonRoot.sprite = kokDisiResimler[whichQuery - 1];
            }
            else
            {
                purpleNonRoot.sprite = kokDisiResimler[whichQuery + 1];
                blueNonRoot.sprite = kokDisiResimler[whichQuery - 1];
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
                greenNonRoot.sprite = kokDisiResimler[whichQuery - 1];
            }
            else if (randomValue >= 66)
            {
                orangeNonRoot.sprite = kokDisiResimler[whichQuery + 1];
                redNonRoot.sprite = kokDisiResimler[whichQuery];
                greenNonRoot.sprite = kokDisiResimler[whichQuery - 1];
            }
            else
            {
                orangeNonRoot.sprite = kokDisiResimler[whichQuery - 1];
                redNonRoot.sprite = kokDisiResimler[whichQuery + 1];
                greenNonRoot.sprite = kokDisiResimler[whichQuery];
            }
        }
        circleOnTop = !circleOnTop;
    }
}
