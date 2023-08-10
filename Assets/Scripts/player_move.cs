using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    float h_move;
    float v_move;
    public int speed;
    bool isHorizonMove;
    Animator anime;
    Rigidbody2D rigid;
    GameObject game_Object;
    public GameManager gameManager;
    Vector3 dirVec;



    //Mobile keys
    int up_value;
    int down_value;
    int left_value;
    int right_value;
    bool up_up;
    bool down_up;
    bool left_up;
    bool right_up;
    bool up_down;
    bool down_down;
    bool left_down;
    bool right_down;



    // Start is called before the first frame update
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        transform.position = new Vector3(0.33f, 2.11f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Move value
        //PC&MOBILE
        h_move = gameManager.IsAction?0:Input.GetAxisRaw("Horizontal")+ left_value + right_value; 
        v_move = gameManager.IsAction ? 0 : Input.GetAxisRaw("Vertical")+ up_value + down_value; 

      


        //Check Button Down & Up
        //PC&MOBILE
        bool hDown = gameManager.IsAction ? false : Input.GetButtonDown("Horizontal") || left_down || right_down;
        bool vDown = gameManager.IsAction ? false : Input.GetButtonDown("Vertical") || up_down || down_down;
        bool hUp = gameManager.IsAction ? false : Input.GetButtonUp("Horizontal") || left_up || right_up;
        bool vUp = gameManager.IsAction ? false : Input.GetButtonUp("Vertical") || up_up || down_up;



        //Check Horizontal Move
        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;

        else if (hUp || vUp)
            isHorizonMove = h_move != 0;

        //Animation
        if (anime.GetInteger("hAxisRaw") != h_move)
        {
            anime.SetBool("IsChanged", true);
            anime.SetInteger("hAxisRaw", (int)h_move);
        }

        else if (anime.GetInteger("vAxisRaw") != v_move)
        {
            anime.SetBool("IsChanged", true);
            anime.SetInteger("vAxisRaw", (int)v_move);
        }

        else
        {
            anime.SetBool("IsChanged", false);
        }


        //Set direction
        if (v_move == 1 && vDown)
            dirVec = Vector3.up;
        else if (v_move == -1 && vDown)
            dirVec = Vector3.down;
        else if (h_move == -1 && hDown)
            dirVec = Vector3.left;
        else if (h_move == 1 && hDown)
            dirVec = Vector3.right;
        //Raycast

        Debug.DrawRay(rigid.position, dirVec * 0.7f, Color.green);
        RaycastHit2D raycast = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("game_Object"));

        if (raycast.collider != null)
        {
            game_Object = raycast.collider.gameObject;
        }
        else
        {
            game_Object = null;
        }

        if (Input.GetButtonDown("Jump")&&game_Object!=null)
        {
            gameManager.Action(game_Object);
            
        }


        //Mobile var Init
         up_up=false;
         down_up= false;
         left_up= false;
         right_up= false;
         up_down= false;
         down_down= false;
         left_down= false;
         right_down= false;
    }

    private void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h_move, 0) : new Vector2(0, v_move);
        rigid.velocity = moveVec*speed;
    }


    public void ButtonDown(string type)
    {
        switch (type)
        {
            case "U":
                up_value = 1;
                up_down = true;
                break;
            case "D":
                down_value = -1;
                down_down = true;
                break;
            case "L":
                left_value = -1;
                left_down = true;
                break;
            case "R":
                right_value = 1;
                right_down = true;
                break;
            case "A":
                if (game_Object != null)
                {
                    gameManager.Action(game_Object);

                }
                break;

            case "C":
                gameManager.SubmenuActive();
                break;
        }
    }

    public void ButtonUp(string type)
    {
        switch (type)
        {
            case "U":
                up_value = 0;
                up_up = true;
                break;
            case "D":
                down_value = 0;
                down_up = true;
                break;
            case "L":
                left_value = 0;
                left_up = true;
                break;
            case "R":
                right_value = 0;
                right_up = true;
                break;
           

        }
    }
   
}
