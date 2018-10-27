using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;

    private bool playerMoving;
    private bool wasMovingVertical;

    private Animator anim;
    private Vector2 lastMove;

    private static bool playerExists;

    void Start ()
    {
        anim = GetComponent<Animator>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        //destroying the Player duplicate if existing
    }

    void Update()
    {
        
    }
    void FixedUpdate()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        bool isMovingHorizontal = Mathf.Abs(horizontal) > 0.5f;
        //decides whether you are walking on X-axis or not
        float vertical = Input.GetAxisRaw("Vertical");
        bool isMovingVertical = Mathf.Abs(vertical) > 0.5f;
        //decides whether you are walking on Y-axis or not

        playerMoving = true;

        if (isMovingVertical && isMovingHorizontal)
        {
            if (wasMovingVertical)
            {
                transform.Translate(new Vector2(horizontal * moveSpeed * Time.deltaTime, 0));
                lastMove = new Vector2(horizontal, 0f);
                //now walking horizontally
                anim.SetFloat("MoveY", 0f);
                anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
                //setting the values for the animator
            }
            else
            {
                transform.Translate(new Vector2(0, vertical * moveSpeed * Time.deltaTime));
                lastMove = new Vector2(0f, vertical);
                //now walking vertically
                anim.SetFloat("MoveX", 0f);
                anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
                //setting the values for the animator

            }
        }
        else if (isMovingHorizontal)
        {
            transform.Translate(new Vector2(horizontal * moveSpeed * Time.deltaTime, 0));
            wasMovingVertical = false;
            lastMove = new Vector2(horizontal, 0f);
            //now walking horizontally
            anim.SetFloat("MoveY", 0f);
            anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("LastY", 0f);
            anim.SetFloat("LastX", Input.GetAxisRaw("Horizontal"));
            //setting the values for the animator

        }
        else if (isMovingVertical)
        {
            transform.Translate(new Vector2(0, vertical * moveSpeed * Time.deltaTime));
            wasMovingVertical = true;
            lastMove = new Vector2(0f, vertical);
            //now walking vertically
            anim.SetFloat("MoveX", 0f);
            anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
            anim.SetFloat("LastX", 0f);
            anim.SetFloat("LastY", Input.GetAxisRaw("Vertical"));
            //setting the values for the animator

        }
        else
        {
            playerMoving = false;
            //not walking at all
            anim.SetFloat("MoveX", 0f);
            anim.SetFloat("MoveY", 0F);
            //setting the values for the animator
        }
    }
}
