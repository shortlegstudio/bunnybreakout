using UnityEngine;
using System.Collections;


public class CatchCarrot : MonoBehaviour {
	public int destroyBlockCount = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Paddle")) {
			GameObject[] bricks = BrickController.GetBricks ();
			ArrayList hitBricks = new ArrayList ();

			if (bricks.Length <= destroyBlockCount) {
				//Just break all the bricks if we only have as many bricks left as we should hit
				hitBricks.AddRange (bricks);
			} else { 
				//Select some random bricks.
				for (int i = 0; i < destroyBlockCount; i++) {
					while (hitBricks.Count < i + 1) {
						int index = Random.Range (0, bricks.Length - 1);
						GameObject b = bricks [index];
						if (!hitBricks.Contains (b)) {
							hitBricks.Add (b);
						}
					}
				}

				foreach (GameObject b in hitBricks) {
					BrickController.HitBrick (b);
				}
			}

			//Remove the carrot
			Destroy (this.gameObject);
		}


	}
}
