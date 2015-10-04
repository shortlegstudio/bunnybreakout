using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {
	int gameUnitX = 16;
	public bool autoPlay = false;
	private BallController ball;

	void Start() {
		ball = GameObject.FindObjectOfType<BallController> ();
	}

	void Update () {
		if (autoPlay) {
			AIMovement ();
		} else {
			MoveWithMouse ();
		}
	}


	void MoveWithMouse() {
		float mousePosInUnits = Input.mousePosition.x / Screen.width * gameUnitX;
		mousePosInUnits = Mathf.Clamp (mousePosInUnits, 0.5f, 15.5f);
		gameObject.transform.position = new Vector3 (mousePosInUnits, transform.position.y, transform.position.z);
	}

	void AIMovement() {
		Vector3 newPosition = new Vector3(ball.transform.position.x, transform.position.y, transform.position.z);
		gameObject.transform.position = newPosition;
	}

	void OnCollisionEnter2D(Collision2D other) {
		switch (other.gameObject.tag) {
		case "Bunny":
			catchBunny (other.gameObject);
			break;
		case "Ball":
			spinBall(other.contacts[0].point, other.gameObject);
			break;
		}
		
	}

	private void catchBunny(GameObject go) {
		Destroy (go);
	}
	
	private void spinBall(Vector2 touchPoint, GameObject go) {

	}
	
}
