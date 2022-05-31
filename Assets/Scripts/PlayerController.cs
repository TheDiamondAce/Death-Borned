using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float horizontal;
    public float speed = 7.5f;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform t;
    private BoxCollider2D coll;
    private string WALKING_ANIMATION = "Walking";
    private string JUMPING_ANIMATION = "Jumping";
    private string CROUCHING_ANIMATION = "Crouching";
    private string GROUNDED_BOOL = "Grounded";
    private string SHOOTING_ANIMATION = "shooting";
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField]
    private float attackCoolDown;
    [SerializeField]
    private Transform firePoint;
    public GameObject bullet;
    public Vector3 firepointPos;
   
    
    
    


    [SerializeField] private LayerMask jumpableGround;
    
    
    
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        t = GetComponent<Transform>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
        firepointPos = new Vector3(firepointPos.x, firepointPos.y, firepointPos.z);
        PlayerMoveKeyboard();
        AnimatePlayer();
        anim.SetBool(GROUNDED_BOOL, isGrounded());
        cooldownTimer += Time.deltaTime;
        
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            float jumpVelocity = 7.5f;
            rb.velocity =  new Vector2(rb.velocity.x, jumpVelocity);
            anim.SetBool(JUMPING_ANIMATION, true);

        }else if (isGrounded())
        {
            anim.SetBool(JUMPING_ANIMATION, false);
            return;
        }
       

    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        
    }

    public void PlayerMoveKeyboard()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
       
        
            transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetBool(CROUCHING_ANIMATION, true);
            speed = 0f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            anim.SetBool(CROUCHING_ANIMATION, false);
            speed = 7.5f;
        }






    }
    public void AnimatePlayer()
    {
        if (horizontal > 0 && isGrounded())
        {
            anim.SetBool(WALKING_ANIMATION, true);
            sr.flipX = false;
            

        }
        else if (horizontal < 0 && isGrounded())
        {
            anim.SetBool(WALKING_ANIMATION, true);
            sr.flipX = true;
            
        }
        else if (horizontal == 0)
        {
            anim.SetBool(WALKING_ANIMATION, false);
            
        }
        

        

         
       
    }
    
    
    


}
