/*
    State machine and initial setup from Unity 2D Platformer Example
    Raycast Collision detection from ChatGPT

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public bool controlEnabled = true;
    public AudioSource audioSource;
    public AudioClip jumpAudio;
    public AudioClip runAudio;
    public float maxSpeed = 3f;
    public float walkSpeed = 2.5f;
    public float jumpTakeOffSpeed = 4.15f;
    public float groundDistance = 0.9f;   
    public float jumpCharge = 0.2f;
    public float jumpDivide = 1.23f;
    public float speed = 0;
    public bool IsGrounded;
    public JumpState jumpState = JumpState.Grounded;

    private float counter = 0;
    private float stuckCounter = 0;
    private Rigidbody2D body;
    internal Animator animator;
    SpriteRenderer spriteRenderer;

    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundDistance);
        IsGrounded = (body.velocity.y == 0);

        if (body.velocity.x > 0.01f)
            spriteRenderer.flipX = true;
        else if (body.velocity.x < -0.01f)
            spriteRenderer.flipX = false;

        if (controlEnabled)
            UpdateJumpState();
        UpdateAnimations();
    }

    void UpdateJumpState()
    {
        switch (jumpState)
        {
            case JumpState.Grounded:
                counter = 0;
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) {
                    jumpState = JumpState.PrepareToJump;
                }
                else if (!IsGrounded) {
                    jumpState = JumpState.InFlight;
                }
                body.velocity = new Vector2(maxSpeed * Input.GetAxis("Horizontal"), body.velocity.y);
                break;
            case JumpState.PrepareToJump:
                counter += jumpCharge;
                if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || (counter > jumpTakeOffSpeed)) {
                    jumpState = JumpState.Jumping;
                }
                speed = Mathf.Abs(body.velocity.x) > walkSpeed ? (Mathf.Abs(body.velocity.x) - 0.001f) * Input.GetAxis("Horizontal") : walkSpeed * Input.GetAxis("Horizontal");
                body.velocity = new Vector2(speed, body.velocity.y);
                break;
            case JumpState.Jumping:
                jumpState = JumpState.InFlight;
                body.velocity = new Vector2(body.velocity.x / jumpDivide, counter);
                audioSource.clip = jumpAudio;
                audioSource.Play();
                break;
            case JumpState.InFlight:
                if (IsGrounded)
                {
                    jumpState = JumpState.Landed;
                }
                else if (body.velocity.y == 0) {
                    stuckCounter += 1;
                    if (stuckCounter > 100) {
                        jumpState = JumpState.Landed;
                    }
                }
                else {
                    stuckCounter = 0;
                }
                speed = body.velocity.x + (Input.GetAxis("Horizontal")/2);
                if (Mathf.Abs(speed) > walkSpeed/jumpDivide) {
                    speed = walkSpeed/jumpDivide * (Mathf.Abs(speed)/speed);
                }
                body.velocity = new Vector2(speed, body.velocity.y);
                break;
            case JumpState.Landed:
                jumpState = JumpState.Grounded;
                
                body.velocity = new Vector2(body.velocity.x, body.velocity.y);
                break;
        }
    }

    private bool Explored1 = false;
    private bool ExploredEnd = false;
    void UpdateAnimations() {
        animator.SetBool("running", false);
        animator.SetBool("jump_prep", false);
        animator.SetBool("in_flight", false);
        animator.SetBool("Lvl1", false);
        if (SceneManager.GetActiveScene().buildIndex == 5) {
            jumpState = JumpState.Grounded;
            ExploredEnd = true;
            animator.SetBool("End", true);
            controlEnabled = false;
        } else {
            controlEnabled = true;
            animator.SetBool("End", false);
            if (SceneManager.GetActiveScene().buildIndex == 2 && !Explored1) {
                Explored1 = true;
                animator.SetBool("Lvl1", true);
            }
            switch (jumpState)
            {
                case JumpState.Grounded:
                    if (Mathf.Abs(body.velocity.x) > 0.5f) {
                        animator.SetBool("running", true);
                        if (!audioSource.isPlaying){
                            audioSource.clip = runAudio;
                            audioSource.Play();
                        }
                    }
                    break;
                case JumpState.PrepareToJump:
                    animator.SetBool("jump_prep", true);
                    break;
                case JumpState.Jumping:
                    break;
                case JumpState.InFlight:
                    animator.SetBool("in_flight", true);
                    break;
                case JumpState.Landed:
                    break;
            }
        }
        
    }

    public enum JumpState
    {
        Grounded,
        PrepareToJump,
        Jumping,
        InFlight,
        Landed
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}