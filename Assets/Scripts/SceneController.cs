using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public int levelToLoad;

	void Start ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(levelToLoad);
        }
        //if player steps into the Trigger a choosen scene is loaded
    }
}
