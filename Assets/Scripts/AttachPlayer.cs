using UnityEngine;

public class AttachPlayer : MonoBehaviour
{
	private GameObject player;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == player)
		{
			player.transform.parent = transform;
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject == player)
		{
			player.transform.parent = null;
		}
	}
}
