using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveScript : MonoBehaviour
{
    Gamecontroller gameController; // This will hold the reference to the GameController script.

    public Animator animator;
    public Rigidbody rb;

    //jump variables
    public float jumpForce = 10.0f;
    public Transform groundCheckTransform; // A reference to an empty GameObject placed at the character's feet
    public LayerMask groundLayer; // The layer(s) that represent the ground


    //movement variables
    float speed_magnitude = 10.0f;
    public float walkSpeed = 5.0f; //this is the value we adjust speed_magnitude by when walking
    public float runSpeed = 10.0f; //this is the value we adjust speed_magnitude by when running
    public float walkSpeed_f = 0.26f; //this is used to update the animation walking by going over the threshold
    public float runSpeed_f = 0.51f;



    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("Main Camera").GetComponent<Gamecontroller>();

    }


    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal"); //1
        float z = Input.GetAxis("Vertical"); //2

        Vector3 move = (transform.right * x + transform.forward * z) * speed_magnitude * Time.deltaTime;
        transform.position += move;

        setMovement(x, z);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetInteger("WeaponType_int", 1);
            animator.SetBool("Shoot_b", true);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            animator.SetInteger("WeaponType_int", 0);
            animator.SetBool("Shoot_b", false);

        }
        crouch();
        jump();
    }

    void jump()
    {
        bool isGrounded = Physics.Raycast(groundCheckTransform.position, Vector3.down, 0.1f, groundLayer);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("Jump_b", true);
        }
        else
        {
            animator.SetBool("Jump_b", false);
        }
    }

    void setMovement(float x, float z)
    {
        //calculate the speed based on player input 
        float inputMagnitude = new Vector2(x, z).magnitude;

        if (Input.GetKey(KeyCode.LeftShift) && inputMagnitude > 0.1f)
        { //if we press shift and are moving we must run!
            animator.SetFloat("Speed_f", runSpeed_f);
            speed_magnitude = runSpeed; //udpating the speed of the the characters movement to a run speed
        }
        else if (inputMagnitude > 0.1f)
        { //this is the walk animation
            animator.SetFloat("Speed_f", walkSpeed_f);
            speed_magnitude = walkSpeed; //udpating the speed of the the characters movement to a walk speed
        }
        else
        { //this is the idle animation
            animator.SetFloat("Speed_f", 0.0f);
        }
    }

    void crouch()
    {
        if (Input.GetKeyDown(KeyCode.C)) //1
        {
            animator.SetBool("Crouch_b", true); //2

        }
        else if (Input.GetKeyUp(KeyCode.C)) //3
        {
            animator.SetBool("Crouch_b", false);//4

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "cube")
        {
            print("We collided with the cube");
            gameController.IncreaseScore(10);
            Destroy(other.gameObject);
        }

        if (other.tag == "enemy")
        {
            print("We collided with the enemy");
            gameController.DecreaseHealth(-10);
        }
    }


}