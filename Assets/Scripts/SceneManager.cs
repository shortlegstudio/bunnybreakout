using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneManager : MonoBehaviour {
	public bool pauseWhenOptionIsOpen = true;
	public bool loadOptionMenu = true;
	public KeyCode keyCodeForOptionMenu = KeyCode.Escape;
	public string optionMenuScene = "Option";
	public GameObject optionMenu;
	private bool optionMenuVisible;
	private float oldTimeScale;

	public void LoadLevel(string levelName) {
		Application.LoadLevel (levelName);
	}

	public void ExitGame() {
		Application.Quit ();
	}
	
	public void ResumeGame() {
		if (pauseWhenOptionIsOpen) {
			Time.timeScale = oldTimeScale;
		}
		optionMenu.SetActive (false);
		optionMenuVisible = false;
	}

	void Start() {
		Debug.Log ("Starting Menu Manager");
	}

	void Update() {
		if (Input.GetKeyDown (keyCodeForOptionMenu) && !optionMenuVisible && optionMenu) {
			showOptionMenu();
		}
	}

	private void showOptionMenu() {
		if (optionMenuVisible)
			return;

		if (pauseWhenOptionIsOpen) {
			oldTimeScale = Time.timeScale;
			Time.timeScale = 0;
		}
		optionMenu.SetActive (true);
		optionMenuVisible = true;
	}
}
