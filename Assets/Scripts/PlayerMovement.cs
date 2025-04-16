using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float jumpTime = 0.3f;

    [SerializeField] private Transform feetPos; // generate physics detector
    [SerializeField] private LayerMask groundLayer; // layers of object

    private bool isGrounded;

    private bool isJumping;
    public bool isCrouched;
    private float jumpTimer;

    // create a reference to the Animator
    public class CharacterAnimator : MonoBehaviour
    {
        private Animator animator;

        void Start()
        {
            // Get the Animator component on this GameObject
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            // Example: Press "LeftShift" to toggle run animation
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                bool isRunning = animator.GetBool("Run");
                animator.SetBool("Run", !isRunning);
            }

        }
    }
    private void Awake()
    {
        playerRB=GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.OverlapCircle(feetPos.position, 0.25f, groundLayer) == true )
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }




        if (Input.GetButton("Jump") && isGrounded == true)
        {
            playerRB.velocity = Vector2.up * jumpForce;
            isJumping = true;
        }

        if (isJumping == true && Input.GetButton("Jump"))
        {
            if (jumpTimer < jumpTime)
            {
                playerRB.velocity = Vector2.up * jumpForce;

                jumpTimer += Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }

        }

        if(Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpTimer = 0f;
        }

        if(Input.GetButtonDown("Fire2"))
            {
            GameManager.Instance.PauseObstacles();
            isCrouched = true;
        }

        if(Input.GetButtonUp("Fire2"))
        {
            GameManager.Instance.ResumeObstacles();
            isCrouched = false;
        }
    }
}
