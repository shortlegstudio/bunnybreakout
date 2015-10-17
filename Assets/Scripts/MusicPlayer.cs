using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	private static GameObject instance;
	public AudioClip[] songList;
	private AudioSource _player;
	private int _currentSong;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = gameObject;
			GameObject.DontDestroyOnLoad (gameObject);
		} else {
			GameObject.Destroy(gameObject);
		}
	}

	void Start() {
		_player = GetComponent<AudioSource> ();
		_currentSong = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (!_player.isPlaying) {
			playNextSong();
		}
	}

	private void playNextSong() {
		_currentSong++;
		if (_currentSong >= songList.Length) {
			_currentSong = 0;
		}

		_player.clip = songList [_currentSong];
		_player.Play ();
	}
}
