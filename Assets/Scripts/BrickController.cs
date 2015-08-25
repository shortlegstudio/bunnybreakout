using UnityEngine;
using System.Collections;

public class BrickController : MonoBehaviour {
	private static int breakableCount = 0;

	public Sprite[] hitImages;
	public AudioClip destroySound;
	public float breakVolume;
	public GameObject explosion;
	
	private int timesHit;
	private SpriteRenderer spriteRenderer;
	private SceneManager sceneManager;
	private bool isBreakable = true;
	
	public static int BreakableCount { 
		get { return breakableCount; } 
	}

	public static void ResetLevel() {
		breakableCount = 0;
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
			AudioSource.PlayClipAtPoint(destroySound, this.transform.position, breakVolume);
			Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);
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

}
