using UnityEngine;

public class DeathWall : MonoBehaviour
{
	public float speed = 0.01f;
	
	// Update is called once per frame
	void Update () {
		transform.localScale += Vector3.right * speed;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Destroy(other.gameObject);
	}
}
