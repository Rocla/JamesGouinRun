using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score {

    private static Score instance;

    private int nbBanana;
    private int nbFish;
    private int time;

    public Text nbBananaGuiText;
    public Text nbFishGuiText;
    public Text scoreNumberGuiText;

    private Score()
    {
        nbBanana = 0;
        nbFish = 0;
        time = 0;

        nbBananaGuiText = GameObject.Find("Canvas/BananaNumber").GetComponent<Text>();
        nbFishGuiText = GameObject.Find("Canvas/FishNumber").GetComponent<Text>();
        scoreNumberGuiText = GameObject.Find("Canvas/ScoreNumber").GetComponent<Text>();
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
}
