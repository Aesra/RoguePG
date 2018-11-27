using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    //private float distance;
    public int movementSpeed = 1;

    private Vector3 direction = new Vector3(0, 0, 0);
    public Rect MovementRect = new Rect(0, 0, 0, 0);

    private System.DateTime directionChange;

    void Update()
    {
        Vector3 movement = new Vector3(0, 0);

        //if (!IsInArea())
        //{
        //    ChangeDirection();
        //}

        movement = direction.Scale(movementSpeed * Time.deltaTime);

        transform.Translate(movement);
    }

    void ChangeDirection()
    {
        direction = GetRandomDirection();
        directionChange = System.DateTime.Now;
    }

    bool IsInArea()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        if (x < MovementRect.xMax && x > MovementRect.xMin && y < MovementRect.yMax && y > MovementRect.yMin) return true;
        else return false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Schaden");
            other.gameObject.SetActive(false);
            GameObject.Find("SceneLoader").GetComponent<SceneController>().reloading = true;
        }
        else
        {
            ChangeDirection();
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if ((System.DateTime.Now - directionChange).TotalMilliseconds > 1000)
        {
            ChangeDirection();
        }
    }

    Vector3 GetRandomDirection()
    {
        System.Random random = new System.Random();
        int rand = random.Next(4);
        //Debug.Log(rand);
        switch (rand)
        {
            case 0: return new Vector3(1, 0);
            case 1: return new Vector3(-1, 0);
            case 2: return new Vector3(0, 1);
            case 3: return new Vector3(0, -1);
            default: return new Vector3(0, 0);
        }

    }
}
