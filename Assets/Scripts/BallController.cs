using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
	private PaddleController paddle;
	private Vector3 paddleToBallVector;
	private Rigidbody2D rigidBody;
	private bool attachedBall = true;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<PaddleController> ();
		paddleToBallVector = transform.position - paddle.transform.position;
		rigidBody = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (attachedBall) {
			this.transform.position = paddle.transform.position + paddleToBallVector;

			if (Input.GetMouseButtonDown (0)) {
				rigidBody.velocity = new Vector2 (2f, 10f);
				attachedBall = false;
			}
		}
	}
}
