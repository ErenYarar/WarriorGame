using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnimator;
    public float moveSpeed = 1f, jumpSpeed = 1f, jumpFreq = 1f, nextJumpTime;
    bool facingRight = true;
    public bool isGrounded = false;
    public Transform onGroundCheckPosition;
    public float onGroundCheckRadius;
    public LayerMask onGroundCheckLayer;
    
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

   
    void Update()
    {
        HorizontalMove();
        onGroundCheck();
        if(playerRB.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }
        else if(playerRB.velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }
        if(Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            soundManager.PlaySound("playerJump");
            nextJumpTime = Time.timeSinceLevelLoad + jumpFreq;
            Jump();
        }
    }

    void HorizontalMove()
    {
        if(!this.playerAnimator.GetCurrentAnimatorStateInfo(0).IsTag("playerAttack"))
        {
            playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);
        }

        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));
 
    }

    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }
    void Jump()
    {
        playerRB.AddForce(new Vector2(0f, jumpSpeed));
    }

    void onGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(onGroundCheckPosition.position, onGroundCheckRadius, onGroundCheckLayer);
        playerAnimator.SetBool("playerJump", isGrounded);
    }

}
