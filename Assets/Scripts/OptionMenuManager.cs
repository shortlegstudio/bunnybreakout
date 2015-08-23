using UnityEngine;
using System.Collections;

public class OptionMenuManager : MonoBehaviour {
	public bool pauseWhenOptionIsOpen = true;
	public KeyCode keyCodeForOptionMenu = KeyCode.Escape;

	private bool optionMenuVisible;
	private float oldTimeScale;
	private SceneManager sceneManager;

	// Use this for initialization
	void Start () {
		sceneManager = GameObject.FindObjectOfType<SceneManager> ();
		optionMenuVisible = false;
		gameObject.SetActive (false);

	}

	public void showOptionMenu() {
		Debug.Log ("Showing Option Menu");
		if (optionMenuVisible)
			return;
		
		if (pauseWhenOptionIsOpen) {
			oldTimeScale = Time.timeScale;
			Time.timeScale = 0;
		}
		gameObject.SetActive (true);
		optionMenuVisible = true;
	}

	public void ResumeGame() {
		if (pauseWhenOptionIsOpen) {
			Time.timeScale = oldTimeScale;
		}
		gameObject.SetActive (false);
		optionMenuVisible = false;
	}

	public void LoadLevel(string levelName) {
		sceneManager.LoadLevel (levelName);

	}
	
	public void ExitGame() {
		sceneManager.ExitGame ();
	}
}
