using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    //public Text scoreText;
    //public Text levelText;
    public Image sleepStatsImage;
    public Sprite[] sleepSprite;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //UpdateUI();
        SetSleepStatUI(0);
    }

    //public void UpdateUI()
    //{
    //    scoreText.text = GameManager.instance.score.ToString();
    //    levelText.text = (11 - GameManager.instance.level).ToString();
    //}

    public void SetSleepStatUI(int i)
    {
        sleepStatsImage.sprite = sleepSprite[i];
    }
}