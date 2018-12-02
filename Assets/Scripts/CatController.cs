using UnityEngine;

public class CatController : MonoBehaviour
{
	public float soundTriggerDistance = 10;
	
	private AudioSource audioSource;
	private GameObject player;

	// Use this for initialization
	void Start ()
	{
		audioSource = GetComponent<AudioSource>();
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		var distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
		
		audioSource.volume = distanceToPlayer < soundTriggerDistance 
			? -distanceToPlayer / soundTriggerDistance + 1
			: 0;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			audioSource.Stop();
			Camera.main.GetComponent<AudioSource>().Play();
			Time.timeScale = 0;
		}
	}
}
