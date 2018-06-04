﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour {

	public AudioMixerSnapshot paused;
	public AudioMixerSnapshot unpaused;
	Canvas canvas;

	void Start () {
		canvas = GetComponent <Canvas>();
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			canvas.enabled = !canvas.enabled;
			Pause ();
		}		
	}

	public void Pause () {
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		Lowpass ();
	}

	void Lowpass () {
		if (Time.timeScale == 0) {
			paused.TransitionTo (0.01f);
		}
		else {
			unpaused.TransitionTo (0.01f);
		}
	}
	public void Quit () {
#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
#else
		Application.Quit ();
#endif
	}
}
