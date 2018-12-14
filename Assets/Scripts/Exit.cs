using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.CompareTag("Player") || GameManager.catsCollected != 3) return;
		
		GameObject.FindGameObjectWithTag("GameOverText").GetComponent<Text>()
			.text = $"SACRIFICE ACCEPTED\nTIME: {Time.timeSinceLevelLoad}s";
		Time.timeScale = 0;
	}
}
