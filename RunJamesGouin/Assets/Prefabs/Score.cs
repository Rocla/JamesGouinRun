using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class Score {

    private static Score instance;

    private int nbBanana;
    private int nbFish;
    private int time;
    private int nbLife;

    private Text nbBananaGuiText;
    private Text nbFishGuiText;
    private Text scoreNumberGuiText;
    private Text nbLifeGuiText;

    private Canvas canvasLifeOver;
    private Image imageLifeOver;

    private bool reload;

    private Score()
    {
        reload = false;

        loadCanvas();

        nbBanana = 0;
        nbFish = 0;
        time = 0;
        nbLife = 0;
        incLife();
    }

    public void loadCanvas()
    {
        nbBananaGuiText = GameObject.Find("CanvasInGame/BananaNumber").GetComponent<Text>();
        nbFishGuiText = GameObject.Find("CanvasInGame/FishNumber").GetComponent<Text>();
        scoreNumberGuiText = GameObject.Find("CanvasInGame/ScoreNumber").GetComponent<Text>();
        nbLifeGuiText = GameObject.Find("CanvasInGame/LifeNumber").GetComponent<Text>();

        canvasLifeOver = GameObject.Find("CanvasLifeOver").GetComponent<Canvas>();
        imageLifeOver = GameObject.Find("ImageLifeOver").GetComponent<Image>();
        canvasLifeOver.gameObject.SetActive(false);
    }

    public static Score getInstance()
    {
        if(instance == null)
        {
            instance = new Score();     
        }

        if(instance.reload)
        {
            instance.loadCanvas();
        }

        return instance;
    }


    public void incBanana()
    {
        nbBanana++;
        nbBananaGuiText.text = nbBanana.ToString();
        updateScore();
    }

    public void incFish()
    {
        nbFish++;
        nbFishGuiText.text = nbFish.ToString();
        updateScore();
    }

    private void updateScore()
    {
        int score = nbBanana * 1000 + nbFish * 100;
        scoreNumberGuiText.text = score.ToString();
    }

    public void incLife()
    {
        nbLife++;
        nbLifeGuiText.text = nbLife.ToString();
    }

    public String decLife()
    {
        nbLife--;
        nbLifeGuiText.text = nbLife.ToString();

        if (nbLife < 0)
        {
            return "RestartGame";
        }
        else
        {
            reload = true;
            // RESTART LEVEL
            imageLifeOver.GetComponent<CanvasRenderer>().SetAlpha(0.1f);
            canvasLifeOver.gameObject.SetActive(true);
            imageLifeOver.CrossFadeAlpha(1f, 0.001f, false);

            return "RestartLevel";
        }
    }
}
