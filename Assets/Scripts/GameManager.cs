using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static int catsCollected;
	private static GameObject text;

	void Start()
	{
		text = GameObject.FindGameObjectWithTag("CatsText");
	}
	
	public static void CollectCat()
	{
		catsCollected += 1;
		text.GetComponent<Text>().text = String.Format("Cats collected: {0}", catsCollected);
	}
}
