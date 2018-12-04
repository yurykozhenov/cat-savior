using System;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour {
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player") && GameManager.catsCollected == 3)
		{
			GameObject.FindGameObjectWithTag("GameOverText").GetComponent<Text>()
				.text = String.Format("SACRIFICE ACCEPTED\nTIME: {0}s", Time.timeSinceLevelLoad);
			Time.timeScale = 0;
		}
	}
}
