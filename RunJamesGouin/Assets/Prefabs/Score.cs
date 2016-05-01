using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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

    private Score()
    {
        nbBanana = 0;
        nbFish = 0;
        time = 0;
        nbLife = 0;

        nbBananaGuiText = GameObject.Find("CanvasInGame/BananaNumber").GetComponent<Text>();
        nbFishGuiText = GameObject.Find("CanvasInGame/FishNumber").GetComponent<Text>();
        scoreNumberGuiText = GameObject.Find("CanvasInGame/ScoreNumber").GetComponent<Text>();
        nbLifeGuiText = GameObject.Find("CanvasInGame/LifeNumber").GetComponent<Text>();
    }

    public static Score getInstance()
    {
        if(instance == null)
        {
            instance = new Score();
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

    public void decLife()
    {
        nbLife--;
        nbLifeGuiText.text = nbLife.ToString();
    }
}
