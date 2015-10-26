using UnityEngine;
using System.Collections;

public class Fall : MonoBehaviour {
	private Rigidbody2D _body;
	public float speed = 5f;
	public float variation = 0f;

	// Use this for initialization
	void Start () {
		_body = GetComponent<Rigidbody2D> ();

		//Pick some variation on speed;
		speed += Random.Range (-variation, variation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		_body.velocity = Vector2.down * speed;
	}
}
