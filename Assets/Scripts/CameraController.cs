using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject target;
    private Vector3 targetPos;
    public float followSpeed;

    private static bool cameraExists;

	void Start ()
    {
        target = GameObject.Find("Player");
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);


        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        //destroying the Camera duplicate if existing
    }
	
	void FixedUpdate ()
    {
        targetPos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
        //lerping after the player
	}
}
