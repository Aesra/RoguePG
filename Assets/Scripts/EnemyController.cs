using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public int movementSpeed = 1;
    public Rect movementRect;

    private Vector3 direction;
    private System.DateTime directionChange;
    private Vector3 lastPosition;
  
	void Update () {
        Vector3 movement = new Vector3(0,0);

        //if (!IsInArea())
        //{
        //    ChangeDirection();
        //}

        movement = direction.Scale(movementSpeed * Time.deltaTime);

        transform.Translate(movement);
    }

    void ChangeDirection (Vector3 exclude) {
        direction = GetRandomDirection(exclude);
        directionChange = System.DateTime.Now;
    }

    bool IsInArea () {
        float x = transform.position.x;
        float y = transform.position.y;
        if (x < movementRect.xMax && x > movementRect.xMin && y < movementRect.yMax && y > movementRect.yMin) return true;
        else return false;
    }

    void OnCollisionEnter2D (Collision2D col) {
        ChangeDirection(direction);
        Debug.Log("enter");
    }

    void OnCollisionStay2D (Collision2D col) {
        if (lastPosition == transform.position) {
            ChangeDirection(new Vector3());
        }
        lastPosition = transform.position;
    }

    Vector3 GetRandomDirection () {
        System.Random random = new System.Random();
        int rand = random.Next(4);
        switch (rand)
        {
            case 0: return new Vector3(1, 0);
            case 1: return new Vector3(-1, 0);
            case 2: return new Vector3(0, 1);
            case 3: return new Vector3(0, -1);
            default: return new Vector3(0, 0);
        }
    }

    Vector3 GetRandomDirection (Vector3 exclude) {
        Vector3 value;
        do {
            value = GetRandomDirection();
        } while (value == exclude);
        return value;
    }
}
