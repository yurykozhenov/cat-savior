using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float xThreshold = 4.11f;
	public float yThreshold = 2.2f;
	
	private GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{		
		var newPosition = player.transform.position + offset;

		if (newPosition.x < xThreshold)
		{
			newPosition.x = xThreshold;
		}

		if (newPosition.y < yThreshold)
		{
			newPosition.y = yThreshold;
		}
		
		transform.position = newPosition;
	}
}
