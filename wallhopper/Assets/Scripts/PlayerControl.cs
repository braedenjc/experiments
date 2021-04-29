using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpForce = 1f;
    public float gravityOffset = 1f;

    public bool isOnGround = true;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround){
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    void OnCollisionEnter(Collision collision){
        isOnGround = true;
    }
}
