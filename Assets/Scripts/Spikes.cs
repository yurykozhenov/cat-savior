using UnityEngine;

public class Spikes : MonoBehaviour
{
	public int damageToPlayer = 1;
	
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			other.gameObject.GetComponent<PlayerController>().DamagePlayer(damageToPlayer);
		}
	}
}
