using UnityEngine;

public class OneWayCollision : MonoBehaviour
{
	private EdgeCollider2D collider2D;
	private GameObject player;
	
	// Use this for initialization
	void Start ()
	{
		collider2D = GetComponent<EdgeCollider2D>();
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		collider2D.enabled = player.transform.position.y > collider2D.transform.position.y;
	}
}
