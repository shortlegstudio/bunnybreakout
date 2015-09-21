using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	private SceneManager sceneManager;

	void Start() {
		sceneManager = GameObject.FindObjectOfType<SceneManager> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Ball")) {
			//If it's a ball, let's lose a life or end the game
			sceneManager.LoadLevel ("Lose");
		} else {
			//Otherwise, just kill off that object since it's no longer valuable.
			Destroy (other.gameObject);
		}

	}
}
