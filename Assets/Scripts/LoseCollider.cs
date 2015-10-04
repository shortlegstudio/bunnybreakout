using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Ball")) {
			//If it's a ball, let's lose a life or end the game
			GameController.Current.LoseLife();
		} else {
			//Otherwise, just kill off that object since it's no longer valuable.
			Destroy (other.gameObject);
		}
	}
}
