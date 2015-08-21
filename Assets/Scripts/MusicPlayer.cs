using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	private static GameObject instance;


	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = gameObject;
			GameObject.DontDestroyOnLoad (gameObject);
		} else {
			GameObject.Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
