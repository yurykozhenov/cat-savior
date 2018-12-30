using UnityEngine;

public class AttachPlayer : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			other.transform.parent = transform;
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			other.transform.parent = null;
		}
	}
}
