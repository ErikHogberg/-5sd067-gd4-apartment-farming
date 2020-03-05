using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FadePanelScript : MonoBehaviour, IPointerClickHandler {
	public static FadePanelScript MainInstance;

	public Color TargetColor;
	public bool UseStartColor = false;

	public AnimationCurve FadeIncCurve;
	public AnimationCurve FadeOutcCurve;

	public float TimeToFadeIn;
	public float TimeToFadeOut;

	public UnityEvent StartEvents;
	public UnityEvent OnFadeInStartEvents;
	public UnityEvent OnFadeInCompletionEvents;
	public UnityEvent OnFadeOutStartEvents;
	public UnityEvent OnFadeOutCompletionEvents;
	public UnityEvent OnClick;

	private float time = 0;
	private bool fadingIn = true;

	private Image panel;

	void Start() {
		MainInstance = this;

		panel = GetComponent<Image>();

		if (UseStartColor) {
			TargetColor = panel.color;
		} else {
			panel.color = TargetColor;
		}

		StartEvents.Invoke();

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
			return 1f - (time / TimeToFadeOut);
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
		color.a = TargetColor.a * percentage;
		panel.color = color;

	}

	private void SetAlpha() {
		SetAlpha(GetFadePercentage());
	}


	public void StartFadeIn() {
		fadingIn = true;
		OnFadeInStartEvents.Invoke();
		time = TimeToFadeIn;
		StartAnyFade();
	}

	public void StartFadeOut() {
		fadingIn = false;
		OnFadeOutStartEvents.Invoke();
		time = TimeToFadeOut;
		StartAnyFade();
	}

	private void StartAnyFade() {
		gameObject.SetActive(true);
	}

	public void OnPointerClick(PointerEventData eventData) {
		if (time <= 0) {
			OnClick.Invoke();
		}
	}

}
