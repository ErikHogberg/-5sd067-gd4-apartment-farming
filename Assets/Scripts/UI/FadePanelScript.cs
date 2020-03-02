using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FadePanelScript : MonoBehaviour {
	public static FadePanelScript MainInstance;

	public AnimationCurve FadeIncCurve;
	public AnimationCurve FadeOutcCurve;

	public float TimeToFadeIn;
	public float TimeToFadeOut;

	public UnityEvent OnFadeInStartEvents;
	public UnityEvent OnFadeInCompletionEvents;
	public UnityEvent OnFadeOutStartEvents;
	public UnityEvent OnFadeOutCompletionEvents;

	private float time = 0;
	private bool fadingIn = true;

	public bool FadeInOnStart = true;

	private Image panel;

	void Start() {
		MainInstance = this;

		panel = GetComponent<Image>();

		if (FadeInOnStart) {
			StartFadeIn();
		}
	}

	private void OnDestroy() {
		MainInstance = null;
	}

	void Update() {

		time -= Time.deltaTime;
		if (time < 0) {
			if (fadingIn) {
				OnFadeInCompletionEvents.Invoke();
				gameObject.SetActive(false);
			} else {
				OnFadeOutCompletionEvents.Invoke();
			}
		}

		SetAlpha();

	}

	private float GetFadePercentage() {
		if (fadingIn) {
			return time / TimeToFadeIn;
		} else {
			return time / TimeToFadeOut;
		}
	}

	private void SetAlpha(float percentage) {
		if (percentage > 1.0f) {
			percentage = 1.0f;
		}
		if (percentage < 0.0f) {
			percentage = 0.0f;
		}

		Color color = panel.color;
		color.a = percentage;
		panel.color = color;

	}

	private void SetAlpha(){
		SetAlpha(GetFadePercentage());
	}


	public void StartFadeIn() {
		fadingIn = true;
		OnFadeInStartEvents.Invoke();
		StartAnyFade();
	}

	public void StartFadeOut() {
		fadingIn = false;
		OnFadeOutStartEvents.Invoke();
		StartAnyFade();
	}

	private void StartAnyFade() {
		time = TimeToFadeIn;
		gameObject.SetActive(true);
	}


}
