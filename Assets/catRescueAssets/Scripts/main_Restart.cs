using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class main_Restart : MonoBehaviour {

    public main_GameController gameController;


    public void OnMouseDown () {
        SceneManager.LoadScene("game");
        gameController.StartGame();
    }

    public void PlayAgain() {
        SceneManager.LoadScene("game");
        gameController.StartGame();
    }
}
