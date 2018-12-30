using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	static int catsCollected;
	static int totalCats;

	static Text catsText;

	void Awake()
	{
		catsText = GameObject.FindGameObjectWithTag("CatsText").GetComponent<Text>();
		
		totalCats = GameObject.FindGameObjectsWithTag("Cat").Length;
		SetText();
	}

	public static void CollectCat()
	{
		catsCollected += 1;
		SetText();
	}

	public static bool IsAllCatsCollected()
	{
		return catsCollected == totalCats;
	}

	static void SetText()
	{
		catsText.text = $"CATS: {catsCollected}/{totalCats}";
	}
}
