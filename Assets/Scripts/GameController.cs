using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public Text catsText;
	
	int catsCollected;
	int totalCats;

	void Awake()
	{	
		totalCats = GameObject.FindGameObjectsWithTag("Cat").Length;
		SetText();
	}

	public void CollectCat()
	{
		catsCollected += 1;
		SetText();
	}

	public bool IsAllCatsCollected()
	{
		return catsCollected == totalCats;
	}

	void SetText()
	{
		catsText.text = $"CATS: {catsCollected}/{totalCats}";
	}
}
