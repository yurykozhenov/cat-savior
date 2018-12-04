using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static int catsCollected;

	void Start()
	{
		SetText();
	}

	public static void CollectCat()
	{
		catsCollected += 1;
		SetText();
	}

	private static void SetText()
	{
		GameObject.FindGameObjectWithTag("CatsText").GetComponent<Text>().text = String.Format("CATS: {0}/3", catsCollected);
	}
}
