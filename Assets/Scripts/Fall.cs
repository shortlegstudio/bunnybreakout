using UnityEngine;
using System.Collections;

public class Fall : MonoBehaviour {
	private Rigidbody2D _body;
	public float speed = 5f;

	// Use this for initialization
	void Start () {
		_body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		_body.velocity = Vector2.down * speed;
	}
}
