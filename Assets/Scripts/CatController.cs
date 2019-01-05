using UnityEngine;

public class CatController : MonoBehaviour
{
	public float soundTriggerDistance = 2;

	AudioSource audioSource;
	GameObject player;
	GameController gameController;

	// Use this for initialization
	void Start ()
	{
		audioSource = GetComponent<AudioSource>();
		player = GameObject.FindGameObjectWithTag("Player");
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		var distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
		
		audioSource.volume = distanceToPlayer < soundTriggerDistance 
			? -distanceToPlayer / soundTriggerDistance + 1
			: 0;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.gameObject.CompareTag("Player")) return;
		
		gameController.CollectCat();
		Destroy(gameObject);
	}
}
