using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class main_GameController : MonoBehaviour {
	
	public Camera cam;
	public GameObject[] balls;
	public float timeLeft;
	public Text timerText;
	public GameObject gameOverText;
	public GameObject restartButton;
	public GameObject splashScreen;
	public GameObject startButton;
	public main_CharController charController;
    	public GameObject gameOverImage;
    	public Image splashScreenImage;
    	public Image startButtonImage;
    	public bool played;

    private float maxWidth;
	private bool counting;

    // Use this for initialization
    void Start () {

        if (cam == null) {
			cam = Camera.main;
		}
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float ballWidth = balls[0].GetComponent<Renderer>().bounds.extents.x;
		maxWidth = targetWidth.x - ballWidth;
		timerText.text = "TIME LEFT: " + Mathf.RoundToInt (timeLeft);
	}

	void FixedUpdate () {
		if (counting) {
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0) {
				timeLeft = 0;
			}
			timerText.text = "TIME LEFT: " + Mathf.RoundToInt (timeLeft);
		}
	}

    public void StartGame () {
		splashScreen.SetActive (false);
		startButton.SetActive (false);
        gameOverImage.SetActive(false);
        charController.ToggleControl (true);
		StartCoroutine (Spawn ());
        played = true;
        splashScreenImage.enabled = false;
        startButtonImage.enabled = false;
    }

	public IEnumerator Spawn () {
		yield return new WaitForSeconds (0.5f);
		counting = true;
		while (timeLeft > 0) {
			GameObject ball = balls [Random.Range (0, balls.Length)];
			Vector3 spawnPosition = new Vector3 (
				transform.position.x + Random.Range (-maxWidth, maxWidth), 
				transform.position.y, 
				0.0f
			);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (ball, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (Random.Range (0.1f, 0.4f));
		}
		yield return new WaitForSeconds (1.0f);
        gameOverImage.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        gameOverText.SetActive(true);
        yield return new WaitForSeconds (1.0f);
		restartButton.SetActive (true);
	}
}
