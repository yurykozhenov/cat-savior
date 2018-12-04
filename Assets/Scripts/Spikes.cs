using UnityEngine;

public class Spikes : MonoBehaviour {
	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			other.gameObject.GetComponent<PlayerController>().DamagePlayer(1);
		}
	}
}