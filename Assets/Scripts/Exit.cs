using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
	Text gameOverText;

	void Start()
	{
		gameOverText = GameObject.FindGameObjectWithTag("GameOverText").GetComponent<Text>();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.CompareTag("Player") || !GameManager.IsAllCatsCollected()) return;
		
		gameOverText.text = $"SACRIFICE ACCEPTED\nTIME: {Time.timeSinceLevelLoad}s";
		Time.timeScale = 0;
	}
}
