using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	public SceneManager sceneManager;

	void OnTriggerEnter2D(Collider2D other) {
		Application.LoadLevel ("Lose");
	}
}
