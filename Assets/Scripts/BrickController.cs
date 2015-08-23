using UnityEngine;
using System.Collections;

public class BrickController : MonoBehaviour {
	public int maxHits = 1;
	public Sprite[] hitImages;
	private int timesHit;
	private SpriteRenderer spriteRenderer;
	private SceneManager sceneManager;

	// Use this for initialization
	void Start () {
		timesHit = 0;
		sceneManager = GameObject.FindObjectOfType<SceneManager> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other) {
		Debug.Log ("Brick Hit");
		timesHit ++;

		if (timesHit >= maxHits) {
			Destroy (this.gameObject);
			SimulateWin(); //TODO Make this better
		}
		else if(hitImages.Length > 0) {
			//If we have some alternate images after taking damage, apply those
			if (timesHit < hitImages.Length) {
				spriteRenderer.sprite = hitImages[timesHit];
			}
		}

	}

	void SimulateWin() {
		sceneManager.LoadNextLevel ();
	}
}
