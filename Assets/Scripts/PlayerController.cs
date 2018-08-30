using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public Text countText;
	public Text winText;
    public AudioSource audiokey;
	public AudioClip audiowin;
	AudioSource audioSource;


    private Rigidbody2D rb2d;
	private int count;
	private Animator animator;

	public GameObject bulletPrefab;
	public Transform bulletSpawn;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
		audiokey = GetComponent<AudioSource> ();
		audioSource = GetComponent<AudioSource>();
		animator = GetComponent<Animator> ();

		count = 0;
		winText.text = "";
		SetCountText ();
    }

    void FixedUpdate()
    {
		if (Input.GetKey(KeyCode.LeftArrow))
         {
             transform.position += Vector3.left * speed * Time.deltaTime;
			 animator.SetTrigger ("walk");
		 } 
         
         if (Input.GetKey(KeyCode.RightArrow))
         {
             transform.position += Vector3.right * speed * Time.deltaTime;
			 animator.SetTrigger ("walk");
		 } 
         
         if (Input.GetKey(KeyCode.UpArrow))
         {
             transform.position += Vector3.up * speed * Time.deltaTime;
			 animator.SetTrigger ("walk");
		 } 
         
         if (Input.GetKey(KeyCode.DownArrow))
         {
             transform.position += Vector3.down * speed * Time.deltaTime;
			 animator.SetTrigger ("walk");
		 } 
         
		else
		{ 
			animator.SetTrigger("idle");
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Fire();
		}
    }

	void OnTriggerEnter2D(Collider2D other){
		
		if (other.gameObject.CompareTag ("PickUp")) {
			animator.SetTrigger("attack");
			other.gameObject.SetActive (false);
			audiokey.Play ();
			count = count + 1;
			SetCountText ();
		}
	}

	void Fire()
	{
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate(
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * 6;

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 10.0f);        
	}


	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) 
		{
			winText.text = "You Win!";
			audioSource.PlayOneShot(audiowin, 0.7F);
		}
	}
}

