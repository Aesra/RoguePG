using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private float distance;
    private Vector3 direction = new Vector3(1,0,0);
    private System.Random random = new System.Random();
    private System.DateTime directionChange;
    public Rect MovementRadius;
	// Use this for initialization
	void Start () {
        Debug.Log("start");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 movement = new Vector3(0,0,0);
        if (!IsInArea()) ChangeDirection();
        movement = direction.Scale(1 * Time.deltaTime);



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
        if (x < MovementRadius.xMax && x > MovementRadius.xMin && y < MovementRadius.yMax && y > MovementRadius.yMin) return true;
        else return false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        ChangeDirection();
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if((System.DateTime.Now -directionChange).TotalMilliseconds > 1000)
        {
            ChangeDirection();
        }
    }

    Vector3 GetRandomDirection ()
    {
        int ran = random.Next(4);
        Debug.Log(ran);
        switch (ran)
        {
            case 0: return new Vector3(1, 0);
            case 1: return new Vector3(-1, 0);
            case 2: return new Vector3(0, 1);
            case 3: return new Vector3(0, -1);
            default: return new Vector3(0, 0);
        }

    }
}
