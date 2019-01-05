using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
	public Text gameOverText;

	GameController gameController;

	void Start()
	{
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.CompareTag("Player") || !gameController.IsAllCatsCollected()) return;
		
		gameOverText.text = $"SACRIFICE ACCEPTED\nTIME: {Time.timeSinceLevelLoad}s";
		Time.timeScale = 0;
	}
}
