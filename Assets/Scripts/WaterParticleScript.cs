using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterParticleScript : MonoBehaviour {

	public static WaterParticleScript MainInstance;

	private ParticleSystem WaterParticles;

	public string SoundEffect;

	private void Start() {
		MainInstance = this;
		WaterParticles = GetComponent<ParticleSystem>();
	}
	
	public void StartSpray() {
		WaterParticles.Play();
		AudioManager.instance.Play(SoundEffect);
	}

}
