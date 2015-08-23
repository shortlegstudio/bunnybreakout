using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	private SceneManager sceneManager;

	void Start() {
		sceneManager = GameObject.FindObjectOfType<SceneManager> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		sceneManager.LoadLevel ("Lose");
	}
}
