using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject player;
    public float speed;
    //public bool isGrounded;
    //public float jumpHeight = 3.0f;
    //public LayerMask layerMask;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float Xaxis = Input.GetAxis("Horizontal") * speed;
        float Zaxis = Input.GetAxis("Vertical") * speed;

        Vector3 movePos = transform.right * Xaxis + transform.forward * Zaxis;
        Vector3 newMovePos = new Vector3(movePos.x, rb.velocity.y, movePos.z);

        rb.velocity = newMovePos;


        //Goling to add jump if there is more time......
        //isGrounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 0.4f, layerMask);

        //if (Input.GetButtonDown("Jump") && isGrounded)
        //{

        //}

    }
}
