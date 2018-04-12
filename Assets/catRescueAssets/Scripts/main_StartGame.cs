using UnityEngine;
using System.Collections;

public class main_StartGame : MonoBehaviour {

	public main_GameController gameController;

	void OnMouseDown () {
		gameController.StartGame ();
	}
}