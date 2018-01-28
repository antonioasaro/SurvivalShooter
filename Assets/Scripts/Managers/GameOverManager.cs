﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
	public PlayerHealth playerHealth;       // Reference to the player's health.
	public float restartDelay = 100f;       // Time to wait before restarting the level


	Animator anim;                          // Reference to the animator component.
	float restartTimer = 0f;                     // Timer to count up to restarting the level


	void Awake ()
	{
		// Set up the reference.
		anim = GetComponent <Animator> ();
	}


	void Update ()
	{
		// If the player has run out of health...
		if(playerHealth.currentHealth <= 0)
		{
			// ... tell the animator the game is over.
			anim.SetTrigger ("GameOver");

			// .. increment a timer to count up to restarting.
			restartTimer += Time.deltaTime;

			// .. if it reaches the restart delay...
			if(restartTimer >= restartDelay)
			{
				// .. then reload the currently loaded level.
				restartTimer = 0f;
//				Application.LoadLevel(Application.loadedLevel);
				SceneManager.LoadScene (0);
			}
		}
	}
}
