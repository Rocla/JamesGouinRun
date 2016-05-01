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

    private int score;

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

        score = 0;
        nbBanana = 0;
        nbFish = 0;
        time = 0;
        nbLife = 3;

        loadCanvas();
    }

    public void loadCanvas()
    {
        nbBananaGuiText = GameObject.Find("CanvasInGame/PanelInGame/BananaNumber").GetComponent<Text>();
        nbBananaGuiText.text = nbBanana.ToString();
        nbFishGuiText = GameObject.Find("CanvasInGame/PanelInGame/FishNumber").GetComponent<Text>();
        nbFishGuiText.text = nbFish.ToString();
        nbLifeGuiText = GameObject.Find("CanvasInGame/PanelInGame/LifeNumber").GetComponent<Text>();
        nbLifeGuiText.text = nbLife.ToString();

        scoreNumberGuiText = GameObject.Find("CanvasInGame/PanelInGame/ScoreNumber").GetComponent<Text>();
        updateScore();

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
            try
            {
                instance.loadCanvas();
            }
            catch
            {
                // DO NOTHING
            }
            
            instance.reload = false;
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
        score = nbBanana * 1000 + nbFish * 100;
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

        // RESTART LEVEL
        imageLifeOver.GetComponent<CanvasRenderer>().SetAlpha(0.1f);
        canvasLifeOver.gameObject.SetActive(true);
        imageLifeOver.CrossFadeAlpha(1f, 0.001f, false);

        reload = true;

        if (nbLife < 0)
        {
            nbLife = 3;
            nbBanana = 0;
            nbFish = 0;
            return "RestartGame";
        }
        else
        {
            return "RestartLevel";
        }
    }

    public int getScore()
    {
        return score;
    }
}
