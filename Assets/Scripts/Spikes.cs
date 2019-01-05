using UnityEngine;

public class Spikes : MonoBehaviour
{
	public int damageToPlayer = 1;
	
	PlayerController playerController;

	void Start()
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			playerController.DamagePlayer(damageToPlayer);
		}
	}
}
