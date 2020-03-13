using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class AudioManager : MonoBehaviour {

	public bool DisableSound = false;

	public sounds[] Sounds;

	public UnityEvent OnFirstAwake;

	public static AudioManager instance;


	private void Awake() {
		if (instance == null)
			instance = this;
		else {
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);

		foreach (sounds s in Sounds) {
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}

		// Play(MainTheme);
		OnFirstAwake.Invoke();
	}

	public void Start() {
		// Scene currentS = SceneManager.GetActiveScene();
		// if (currentS.name != "Menu") {
		// 	PlayMusic(1);
		// } else {
		// 	PlayMusic(0);
		// }
	}

	public void Play(string name) {
		if (DisableSound){
			return;
		}

		sounds s = CheckSound(name);
		if (s == null) {
			return;
		}

		s.source.Play();
		// Debug.Log("played sound " + name);

	}

	private sounds CheckSound(string name) {
		sounds s = Array.Find(Sounds, sounds => sounds.Name == name);
		if (s == null) {
			Debug.LogWarning("Sound:" + name + "not found!");
			return null;
		}

		return s;
	}

	// public void PlayMusic(int song) {
	// 	string name = "";

	// 	switch (song) {
	// 		case 0:
	// 			name = "MenuTheme";
	// 			break;

	// 		case 1:
	// 			name = "Theme";
	// 			break;
	// 	}

	// 	sounds p = Array.Find(Sounds, sounds => sounds.Name == "MenuTheme");
	// 	p.source.Stop();
	// 	sounds q = Array.Find(Sounds, sounds => sounds.Name == "Theme");
	// 	q.source.Stop();
	// 	sounds s = Array.Find(Sounds, sounds => sounds.Name == name);
	// 	s.source.Play();
	// }
}

[System.Serializable]
public class sounds {
	public string Name;

	public AudioClip clip;

	[Range(0f, 1f)]
	public float volume;

	[Range(.1f, 3f)]
	public float pitch;

	public bool loop;

	[HideInInspector]
	public AudioSource source;
}
