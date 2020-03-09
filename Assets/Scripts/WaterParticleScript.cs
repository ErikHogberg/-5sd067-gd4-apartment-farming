using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterParticleScript : MonoBehaviour {

	public static WaterParticleScript MainInstance;

	// private float time = 0;
	// public float SprayTime = 1f;

	private ParticleSystem WaterParticles;

	private void Start() {
		MainInstance = this;
		WaterParticles = GetComponent<ParticleSystem>();
	}

	// private void Update() {
	// 	if (WaterParticles.isEmitting) {
	// 		time -= Time.deltaTime;
	// 		if (time < 0) {
	// 			StopSpray();
	// 		}
	// 	}
	// }

	public void StartSpray() {
		// time = SprayTime;
		WaterParticles.Play();
	}

	// public void StopSpray() {
	// 	WaterParticles.Pause();
	// }


}
