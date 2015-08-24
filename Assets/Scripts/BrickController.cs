using UnityEngine;
using System.Collections;

public class BrickController : MonoBehaviour {
	private static int breakableCount = 0;
	public Sprite[] hitImages;
	private int timesHit;
	private SpriteRenderer spriteRenderer;
	private SceneManager sceneManager;
	private bool isBreakable = true;

	public static int BreakableCount { 
		get { return breakableCount; } 
	}

	// Use this for initialization
	void Start () {
		timesHit = 0;

		//Track components we use
		sceneManager = GameObject.FindObjectOfType<SceneManager> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();

		//Track breakable bricks
		isBreakable = gameObject.CompareTag ("Breakable");
		if (isBreakable) {
			breakableCount++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (isBreakable) {
			handleHits ();
		}
	}

	void handleHits() {
		timesHit ++;
		int maxHits = hitImages.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			sceneManager.BrickDestroyed();
			Destroy (this.gameObject);
		}
		else {
			setImage();
			
		}
	}
				             
	void setImage() {
		int spriteIndex = timesHit - 1;
		if (!hitImages [spriteIndex]) 
			Debug.LogError ("Brick missing hitImage for index: " + spriteIndex);
		spriteRenderer.sprite = hitImages[spriteIndex];
	}

	void LevelCompleted() {
		sceneManager.LoadNextLevel ();
	}
}
