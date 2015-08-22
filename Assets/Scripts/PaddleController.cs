using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {
	int gameUnitX = 16;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float mousePosInUnits = Input.mousePosition.x / Screen.width * gameUnitX;
		mousePosInUnits = Mathf.Clamp (mousePosInUnits, 0.5f, 15.5f);
		gameObject.transform.position = new Vector3 (mousePosInUnits, transform.position.y, transform.position.z);
	}
}
