using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneManager : MonoBehaviour {
	private OptionMenuManager optionMenu;

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

	public void LoadLevel(string levelName) {
		BrickController.ResetLevel ();
		Application.LoadLevel (levelName);
	}


	public void LoadNextLevel() {
		BrickController.ResetLevel ();
		Application.LoadLevel (Application.loadedLevel + 1);
	}
		

	public void BrickDestroyed() {
		if (BrickController.BreakableCount <= 0) 
			LoadNextLevel ();
	}
}
