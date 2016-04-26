using UnityEngine;
using System.Collections;

public class UIProceduralMap : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		}

  public void GoToMain(){
			UnityEngine.SceneManagement.SceneManager.LoadScene("main");
  }
}
