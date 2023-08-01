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
    // Start is called before the first frame update
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //Move value
        h_move = gameManager.IsAction?0:Input.GetAxisRaw("Horizontal");
        v_move = gameManager.IsAction ? 0 : Input.GetAxisRaw("Vertical");


        //Check Button Down & Up
        bool hDown = gameManager.IsAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = gameManager.IsAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = gameManager.IsAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = gameManager.IsAction ? false : Input.GetButtonUp("Vertical");


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
    }

    private void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h_move, 0) : new Vector2(0, v_move);
        rigid.velocity = moveVec*speed;
    }
   
}
