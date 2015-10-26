using UnityEngine;
using System.Collections;

public class Wiggle : MonoBehaviour {
	private float wiggles = 0;
	public float Wiggleness = 5f;
	public float WiggleSpeed = 0.2f;
	public float WiggleVariation = 0f;
	public float WiggleSpeedVariation = 0f;

	// Use this for initialization
	void Start () {
		Wiggleness += Random.Range (-WiggleVariation, WiggleVariation);
		WiggleSpeed += Random.Range (-WiggleSpeedVariation, WiggleSpeedVariation);
		wiggles = Wiggleness * 0.5f;  //start int he middle of your wiggles
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward * WiggleSpeed);
		wiggles += Time.deltaTime;
		if (wiggles > Wiggleness) { 
			WiggleSpeed *= -1;
			wiggles = 0;
		}
	}
}
