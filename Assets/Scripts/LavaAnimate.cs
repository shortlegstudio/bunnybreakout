using UnityEngine;
using System.Collections;

public class LavaAnimate : MonoBehaviour {
	public float _flowSpeed;
	public float _minX = -0.5f;
	public float _maxX = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = new Vector3 ();
		pos.x = transform.position.x - _flowSpeed * Time.deltaTime;

		//flip around if we have looped
		if (pos.x < _minX)
			pos.x = _maxX;

		pos.y = transform.position.y;
		pos.z = transform.position.z;

		transform.position = pos;

	}
}
