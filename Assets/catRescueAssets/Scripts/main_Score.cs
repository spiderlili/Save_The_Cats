using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class main_Score : MonoBehaviour {

	public Text scoreText;
	public int ballValue;
    public AudioSource meow;

	private int score;

	void Start () {
		score = 0;
		UpdateScore ();
        meow = GetComponent<AudioSource>();
    }

    //moew when rescued
    void OnTriggerEnter2D (Collider2D other) {
		score += ballValue;
		UpdateScore ();
        //meow.Play();
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Bomb") {
			score -= ballValue * 2;
			UpdateScore ();
		}
	}

	void UpdateScore () {
		scoreText.text = "SCORE: " + score;
	}
}
