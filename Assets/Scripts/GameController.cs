using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject successExclam;
	public GameObject ohnoExclam;

	private static GameObject _instance;
	private int _lives;
	private int _bunniesSaved;

	public int Lives {
		get { return _lives; }
	}

	public int BunniesSaved {
		get { return _bunniesSaved; }
	}

	public static GameController Current {
		get { return _instance.GetComponent<GameController>(); }
	}

	// Use this for initialization
	void Awake () {
		if (_instance == null) {
			_instance = gameObject;
			GameObject.DontDestroyOnLoad (_instance);
			Reset ();
		} else {
			Destroy (this.gameObject);
		}


	}
	
	// Update is called once per frame
	void Update () {	
	
	}

	public void LoseLife() {
		_lives--;
		if (Lives < 0) {
			findSceneManager ().LoadLevel ("Lose");
			return;
		}

		UpdateUI ();
		ResetBall ();
	}

	public void Reset() {
		_bunniesSaved = 0;
		_lives = 3;
	}

	public void CatchBunny(GameObject bunny) {
		_bunniesSaved++;
		showExclam (bunny.transform.position, successExclam);

		Destroy (bunny);
		UpdateUI ();
	}

	public void MissedBunny(GameObject bunny) {
		showExclam (bunny.transform.position + Vector3.up, ohnoExclam);
		Destroy (bunny);
	}

	public void UpdateUI() {
		Debug.LogFormat ("Updating UI: {0}, {1}", _lives, _bunniesSaved);
		GameObject ui = GameObject.FindWithTag ("livesCounter");
		if (ui != null) {
			Text lifeCounter = ui.GetComponent<Text> ();
			if (lifeCounter != null)
				lifeCounter.text = Lives.ToString ();
		}

		ui = GameObject.FindWithTag ("bunnyCounter");
		if (ui != null) {
			Text bunnyCounter = ui.GetComponent<Text> ();
			if (bunnyCounter != null)
				bunnyCounter.text = BunniesSaved.ToString ();
		}
	}

	private SceneManager findSceneManager() {
		return FindObjectOfType<SceneManager> ();
	}

	private void ResetBall() {
		BallController ball = GameObject.FindObjectOfType<BallController> ();
		ball.attachBall ();
	}

	private void showExclam(Vector3 pos, GameObject exclam) {
		if (exclam == null) {
			Debug.LogError ("Can't find Exclam!");
			return;
		}
		GameObject obj = (GameObject)Instantiate (exclam, pos, Quaternion.identity);
		Destroy (obj, 1);
	}
}
