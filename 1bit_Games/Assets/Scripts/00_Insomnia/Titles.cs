using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Titles : MonoBehaviour
{
    public Text IntroText;
    public Text TitleText;
    public string[] introTextArray;

    public float ShowTimer;


    private float alpha = 0;
    private bool fadeIn;
    private bool fadeOut;
    
    private bool switcher = false;
    private float timer;
    private int introIndex = 0;
    private int titleIndex = 0;

    private bool showIntro;
    private bool showTitle;

    public Color startColor;
    public Color endColor;

    void Start()
    {
        showIntro = true;
        timer = 1;
    }

    void Update()
    {
        if (GameManager.instance.isGameEnd)
        {
            TitleText.text = "Sleeping";
        }
        else
        {
            FadeIn();
            if (timer <= 0)
            {
                ShowIntroText();
                ShowTitleText();
                timer = ShowTimer;
            }
            timer -= Time.deltaTime;
            if (timer <= 2 && switcher)
            {
                fadeIn = false;
                fadeOut = true;
                switcher = false;
            }
            FadeOut();
        }
    }

    void FadeIn()
    {
        if (fadeIn) 
        {
            IntroText.color = Color.Lerp(startColor, endColor, alpha);
            alpha += Time.deltaTime * 0.4f;
            if (alpha >= 1)
                fadeIn = false;
        }
    }

    void FadeOut()
    {
        if (fadeOut)
        {
            IntroText.color = Color.Lerp(startColor, endColor, alpha);
            alpha -= Time.deltaTime * 0.4f;
            if (alpha <= 0)
                fadeOut = false;
        }
    }

    void ShowIntroText()
    {
        if (showIntro)
        {
            fadeIn = true;
            fadeOut = false;
            switcher = true;
            IntroText.text = introTextArray[introIndex];
            introIndex++;
            if (introIndex >= introTextArray.Length) 
            {
                showIntro = false;
                IntroText.gameObject.SetActive(false);
                TitleText.gameObject.SetActive(true);
                showTitle = true;
            }
        }
    }

    void ShowTitleText()
    {
        if (showTitle)
        {
            if (titleIndex == 0)
            {
                TitleText.text = "Insomnia";
                TitleText.fontSize = 213;
            }
            if (titleIndex == 1)
            {
                TitleText.text = "A narutocyx production";
                TitleText.fontSize = 87;
            }
            if (titleIndex == 2)
            {
                gameObject.SetActive(false);
                GameManager.instance.isGameStart = true;
            }
            titleIndex++;
        }
    }
}
