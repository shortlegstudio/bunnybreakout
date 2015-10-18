using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other) {
		switch (other.tag) {
		case "Ball":
			GameController.Current.BallOutOfBounds(other.gameObject);
			break;
		case "Bunny":
			GameController.Current.MissedBunny(other.gameObject);
			break;
		case "Paddle":
			break;
		default:
			Destroy (other.gameObject);
			break;
		}
	}
}
