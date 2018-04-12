using UnityEngine;
using System.Collections;

public class main_DestroyOnContact : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		Destroy (other.gameObject);
	}
}
