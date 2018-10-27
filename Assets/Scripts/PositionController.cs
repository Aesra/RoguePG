using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour {

    public GameObject playerToPosition;
    public GameObject cameraToPosition;

	void Start ()
    {
        playerToPosition = GameObject.Find("Player");
        playerToPosition.transform.position = transform.position;
        cameraToPosition = GameObject.Find("Camera");
        cameraToPosition.transform.position = new Vector3(transform.position.x, transform.position.y, cameraToPosition.transform.position.z);
        //setting the player and camera position to where the LoadPosition object is located
    }
	
	void Update ()
    {
		
	}
}
