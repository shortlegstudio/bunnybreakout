using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneManager : MonoBehaviour {
	private OptionMenuManager optionMenu;

	public void LoadLevel(string levelName) {
		Application.LoadLevel (levelName);
	}

	public void ExitGame() {
		Application.Quit ();
	}

	void Start() {
		optionMenu = FindObjectOfType<OptionMenuManager> ();
	}
	
	void Update() {
		if (optionMenu) {
			if (Input.GetKeyDown (optionMenu.keyCodeForOptionMenu)) {
				optionMenu.showOptionMenu ();
			}
		}
	}

	public void LoadNextLevel() {
		Application.LoadLevel (Application.loadedLevel + 1);
	}
}
