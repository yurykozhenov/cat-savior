using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float xThresholdStart = 1.95f;
	public float yThresholdStart = 1.13f;
	public float xThresholdEnd = 17.28f;
	public float yThresholdEnd = 5.50776f;
	
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
		if (player == null)
		{
			return;
		}
		
		// TODO: Maybe there's a better way to lock camera to borders?
		// Yes! Detach camera using player position, not camera position!
		var newPosition = player.transform.position + offset;

		if (newPosition.x < xThresholdStart)
		{
			newPosition.x = xThresholdStart;
		}
		
		if (newPosition.x > xThresholdEnd)
		{
			newPosition.x = xThresholdEnd;
		}

		if (newPosition.y < yThresholdStart)
		{
			newPosition.y = yThresholdStart;
		}
		
		if (newPosition.y > yThresholdEnd)
		{
			newPosition.y = yThresholdEnd;
		}
		
		transform.position = newPosition;
	}
}
