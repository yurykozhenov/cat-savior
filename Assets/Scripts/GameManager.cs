using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static int catsCollected;

	public static void CollectCat()
	{
		catsCollected += 1;
		
		var text = GameObject.FindGameObjectWithTag("CatsText");
		text.GetComponent<Text>().text = String.Format("Cats collected: {0}", catsCollected);
	}
}
