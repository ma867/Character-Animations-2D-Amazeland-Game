using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZOMBIE8 : MonoBehaviour {
private Animator animator;
	public Text loseText;
	
	
    public float speed;
    public Transform target1;
    public Transform target2;
    private float direction=1.0f;
    private float currentPosition=0.0f;
	
	
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		loseText.text ="";
	}
	
	// Update is called once per frame
	void Update () {
		currentPosition = Mathf.Clamp01(currentPosition + speed * Time.deltaTime * direction);
        if(direction == 1.0f && currentPosition > 0.99f) {direction=-1.0f;}
		if(direction ==-1.0f && currentPosition < 0.01f) {direction= 1.0f;}
       
        transform.position = Vector3.Lerp(target1.position, target2.position, currentPosition);
	}

	void OnTriggerEnter2D(Collider2D other){
	
		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.SetActive (false);
			animator.SetTrigger("z8jump");
			loseText.text = "You Lose!";
		}
	}
}
