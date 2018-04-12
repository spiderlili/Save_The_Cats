using UnityEngine;
using System.Collections;

public class main_CharController : MonoBehaviour {

	public Camera cam;

	private float maxWidth;
	private bool canControl;

    // Use this for initialization

    void Start () {

        //use the main camera automatically if unassigned

		if (cam == null) {
			cam = Camera.main;
		}

        //find the borders of the 2D play area in screen space and translate it to world space

        Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);

        //find the extents of the character sprite's bounds along the X axis to clamp it exactly to the edge

		float hatWidth = GetComponent<Renderer>().bounds.extents.x;
		maxWidth = targetWidth.x - hatWidth;
		canControl = false;
	}
	
	//called at consistent intervals once per physics timeste for regular rigidbody updates

	void FixedUpdate () {
		if (canControl) {

            //look for mouse/finger pointer position, translate from screenspace into worldspace

            Vector3 rawPosition = cam.ScreenToWorldPoint (Input.mousePosition);
			Vector3 targetPosition = new Vector3 (rawPosition.x, 0.0f, 0.0f);

            //clamp the controller within the screen to keep it form leaving the game area
            //everything must be centred on the 0 axis - XYZ
            //maintain the original YZ position - only move on the X axis

            float targetWidth = Mathf.Clamp (targetPosition.x, -maxWidth, maxWidth);
			targetPosition = new Vector3 (targetWidth, targetPosition.y, targetPosition.z); 

            //find the rigidbody and attach it to the pointer to move it

            GetComponent<Rigidbody2D>().MovePosition (targetPosition);
		}
	}

	public void ToggleControl (bool toggle) {
		canControl = toggle;
	}
}

//screen space is pixels and viewport space is simply a normalised value