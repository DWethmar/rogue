using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();

	}
	
    public float speed = 1.0F;
    public float jumpSpeed = 2.0F;
    public float gravity = 20.0F;

    private Vector3 moveDirection = Vector3.zero;

    void Update() {

        float inputHorizontal = Input.GetAxis("Horizontal"); //Input.GetAxis checken
        float inputVertical = Input.GetAxis("Vertical");

        CharacterController controller = GetComponent<CharacterController>();

        if (controller.isGrounded) {
            moveDirection = new Vector3(inputHorizontal, 0, inputVertical);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        bool is_walking = (Mathf.Abs(inputHorizontal) + Mathf.Abs(inputVertical)) > 0;
        anim.SetBool("isWalking", is_walking);
        if (is_walking)
        {
            anim.SetFloat("x", inputHorizontal);
            anim.SetFloat("y", inputVertical);
        }
    }
}