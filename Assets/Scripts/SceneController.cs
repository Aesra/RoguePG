using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public int levelToLoad;
    public bool reloading = false;
    public float waitForReload = 2;
    public GameObject Player;

	void Start ()
    {
        Player = GameObject.Find("Player");
	}

    private void Update ()
    {
        if (reloading)
        {
            waitForReload -= Time.deltaTime;
            if (waitForReload <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Player.SetActive(true);
            }
        }
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
