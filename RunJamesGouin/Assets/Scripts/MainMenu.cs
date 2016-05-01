using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
	  if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}

    public void StartEndlessGame()
    {
        SceneManager.LoadScene("jump_procedural");
    }

	public void StartLevel1Game()
	{
		Application.LoadLevel("level1");
	}
}
