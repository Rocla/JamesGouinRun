using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSuccessScript : MonoBehaviour {

    private Canvas canvasGameOver;
    private Image imageGameOver;
    private Button buttonBackToMenu;
    private Button buttonRestartGame;
    private Text scoreText;

    // Use this for initialization
    void Start () {

        imageGameOver = transform.Find("ImageGameOver").GetComponent<Image>();
        buttonRestartGame = transform.Find("RestartButton").GetComponent<Button>().GetComponent<Button>();
        buttonBackToMenu = transform.Find("BackToMenuButton").GetComponent<Button>().GetComponent<Button>();

        buttonRestartGame.onClick.AddListener(() => {
            SceneManager.LoadScene("level1");
        });

        buttonBackToMenu.onClick.AddListener(() => {
            SceneManager.LoadScene("main");
        });

        scoreText = transform.Find("Score").GetComponent<Text>();
        scoreText.text = "Score : " + Score.getInstance().getScore();

    }

    // Update is called once per frame
    void Update () {
	
	}
}
