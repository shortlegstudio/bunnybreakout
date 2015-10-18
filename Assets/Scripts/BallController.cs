using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
	public AudioClip boingSound;
	public float boingVolume;
	public float speed = 5.0f;
	public float minY = 0.2f;
	public bool LaunchImmediately;

	private PaddleController paddle;
	private GameObject spawnPoint;
	private Rigidbody2D rigidBody;
	private bool attachedBall = true;

	private Vector2 velocity; //Tracked for more interesting collisions
	private Vector2 lastPos;

	// Use this for initialization
	void Start () {
		spawnPoint = GameObject.FindWithTag ("ballSpawn");
		attachBall ();
		rigidBody = this.GetComponent<Rigidbody2D>();
		lastPos = this.transform.position;

		if (LaunchImmediately) {
			LaunchBall();
		}
	}

	// Update is called once per frame
	void Update () {
		if (attachedBall) {
			this.transform.position = spawnPoint.transform.position;

			if (Input.GetMouseButtonDown (0)) {
				LaunchBall ();

			}
		}
	}

	public void LaunchBall() {
		//Get Random Up Angle
		Vector2 launchAngle = new Vector2(Random.Range (-0.3f,0.3f), 1) * speed;
		rigidBody.velocity = launchAngle;
		attachedBall = false;
	}

	void FixedUpdate() {
		// Get pos 2d of the ball.
		Vector3 pos3D = transform.position;
		Vector2 pos2D = new Vector2(pos3D.x, pos3D.y);
		
		// Velocity calculation. Will be used for the bounce
		velocity = pos2D - lastPos;
		lastPos = pos2D;
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (!attachedBall) {
			AudioSource.PlayClipAtPoint(boingSound, this.transform.position, boingVolume);

			// Normal
			Vector3 N = other.contacts[0].normal;
			
			//Direction
			Vector3 V = velocity.normalized;
			
			// Reflection
			Vector3 R = Vector3.Reflect(V, N).normalized;

			if (other.gameObject.CompareTag("Paddle")) {
				//Do a little magic if you are hitting on the edge
				// We want the ball to get a little extra X push depending on how far to the side it impacted the paddle
				float xOffset = other.contacts[0].point.x - other.gameObject.transform.position.x;
				R.x += xOffset / 2;
				R.Normalize();
			} 

			//if we are below a minimum y angle force it into a more vertical orientation
			if (Mathf.Abs (R.y) < minY) {
				R.y = minY * Mathf.Sign(R.y) ;
				R.Normalize();
			}

			// Assign normalized reflection with the constant speed
			rigidBody.velocity = new Vector2(R.x, R.y) * speed;
		}
	}

	public void attachBall() {
		attachedBall = true;
	}
}
