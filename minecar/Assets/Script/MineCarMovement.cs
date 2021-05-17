using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineCarMovement : MonoBehaviour
{
    
    private Transform railLocation;
    private Rigidbody rb;
    private LineRenderer line;
    private BoxCollider boxConnectorCollider;

    public GameObject connector;

    public float acceleration = 1f;
    public float maxSpeed = 1f;
    public float forwardSpeed;
    public float horizontalSpeed;

    public bool alignUsingRay;
    protected float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        railLocation = GameObject.Find("Rail").transform;
        line = this.GetComponent<LineRenderer>();
        if(connector == null){
            Debug.Log("There is no set connector for the minecar to use!");
        }     
    }

    // Update is called once per frame
    void Update()
    {
        MinecarControlInput(); 
        AlignWithRail();
    }

    //Align the car using either of two detection methods.
    void AlignWithRail(){
        if(alignUsingRay){
            AlignUsingRaycast();
        }
    }

    // This method sends a raycast upwards to check for a rail.
    // Once detected, we align the car with the rotation of the rail.
    // Else, we use the box collider.
    void AlignUsingRaycast(){        
        line.SetPosition(0, rb.position);
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.up, out hit, 10f)){
            line.SetPosition(1, hit.point);
            railLocation = hit.transform;
            Debug.Log(" We hit: " + hit.collider.name);
            Debug.Log("The rotation of the rail is: " + hit.transform.rotation);
            connector.transform.rotation = hit.collider.gameObject.transform.rotation;
            connector.transform.Rotate(-90, 0, 0, Space.Self);
        }
    
    }
    
    void MinecarControlInput(){
        ForwardControl();
        LeftRightControl();
    }
    
    //Forward control is responsible for putting the minecart into forward or reverse gear.
    //The direction parameter controls a selector that will change the direction by simple multiplication.
    void ForwardControl(){
        forwardSpeed = maxSpeed * Input.GetAxis("Vertical");
        connector.transform.Translate(Vector3.forward * Time.deltaTime * acceleration * forwardSpeed);
    }

    void LeftRightControl(){
        horizontalSpeed = maxSpeed * Input.GetAxis("Horizontal");
        connector.transform.Translate(Vector3.right * Time.deltaTime * acceleration * horizontalSpeed);
    }
}