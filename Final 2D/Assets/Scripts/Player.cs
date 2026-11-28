using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _kickLeft;
    [SerializeField] private GameObject _kickRight;
    [SerializeField] private GameController _gameController;
    // Add member variables to store references to this GameObject's 
    //      Rigidbody, Animator, and SpriteRenderer. **DONE**
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private float _speed;
    [SerializeField] private float _jump;


    private bool _facingLeft;
    private bool _isGrounded;

    // ------------------------------------------------------------------------
    // Add a built-in UNITY METHOD that runs EVERY FRAME.
        // Detect input to move player left/right, jump, and kick
        // Change character facing with SpriteRenderer.flipX value
        // Set animation parameters 

    private void Update()
    {


        _rigidBody.linearVelocity = new Vector2(
            Input.GetAxis("Horizontal") * _speed,
            _rigidBody.linearVelocity.y
        );

        if (Input.GetKey(KeyCode.UpArrow)) //add is grounded
        {
            _rigidBody.linearVelocity = new Vector2(
                _rigidBody.linearVelocity.x,
                _jump
            );
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            if (_isGrounded){
                _animator.SetBool("walk", true);
            }
            
            if (_facingLeft == false)
            {
                _renderer.flipX = true;
                _facingLeft = true;
            }
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            if (_isGrounded){
                _animator.SetBool("walk", true);
            }

            if (_facingLeft == true)
            {
                _renderer.flipX = false;
                _facingLeft = false;
            }
        }
       

    }
    // ------------------------------------------------------------------------
    private void Kick()
    {
        // Set animation parameter.
        _animator.SetTrigger("kick");

        // Either activate left or right kick based on character facing
    }

    // ------------------------------------------------------------------------
    // Use a built-in Unity method to detect COLLISION.
    // Use this to avoid allowing the Player to double jump- they should
    //      collide with an object with the Ground tag before being able to
    //      jump again.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            _isGrounded = true;
        }
    }
}
