using UnityEngine;
using System.Collections;

public class BrickController : MonoBehaviour {
	private static int breakableCount = 0;

	public Sprite[] hitImages;
	public AudioClip destroySound;
	public float breakVolume;
	public GameObject explosion;
	public float spawnBonusChance = 0.15f;
	public GameObject bonus;
	
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

	public static GameObject[] GetBricks() {
		return GameObject.FindGameObjectsWithTag ("Breakable");
	}

	public static void HitBrick(GameObject brick) {
		if (brick.CompareTag ("Breakable")) {
			BrickController bc = brick.GetComponent<BrickController>();
			bc.handleHits();
		}
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
		if (isBreakable && other.gameObject.CompareTag("Ball")) {
			handleHits ();
		}
	}

	public void handleHits() {
		timesHit ++;
		int maxHits = hitImages.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			sceneManager.BrickDestroyed();
			AudioSource.PlayClipAtPoint(destroySound, this.transform.position, breakVolume);
			GameObject exp = (GameObject)Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);
			Destroy (exp, 2); // Make sure to destroy explosion after it's run for a bit
			Destroy (this.gameObject);
			SpawnBonus();
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

	void SpawnBonus() {
		if (Random.value < spawnBonusChance) {
			Instantiate(bonus, this.transform.position, Quaternion.identity);
		}
	}
	
}
