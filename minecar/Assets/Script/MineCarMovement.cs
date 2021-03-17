using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineCarMovement : MonoBehaviour
{
    
    private Transform railLocation;
    private Rigidbody rb;
    private LineRenderer line;
    private HingeJoint hinge;

    private GameObject connector;

    public float acceleration = 0f;
    public float maxSpeed = 0f;
    protected float currentSpeed;
    
    enum direction{
        FORWARD  = true,
        BACKWARD = false,
        LEFT = true,
        RIGHT = false
    };

    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        rb = GetComponent<Rigidbody>();
        connector = GameObject.Find("CartRailConnector");
        railLocation = GameObject.Find("Rail").transform;
        line = this.GetComponent<LineRenderer>();      
    }

    // Update is called once per frame
    void Update()
    {
        MinecarControlInput(); 
        AlignWithRail();
    }

    // This method sends a raycast upwards to check for a rail.
    // Once detected, we align the car with the rotation of the rail.
    // This allows us keep our control direction sane and easy to understand.
    void AlignWithRail(){
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
    
    void MinecarControlInput(){
        if(Input.GetKey("w")){
            ForwardControl(FORWARD);
         }
         else if(Input.GetKey("s")){
             ForwardControl(BACKWARD);
         }
            
        else if(Input.GetKey("a")){
             LeftRightControl(LEFT);
        }

        else if(Input.GetKey("d")){
            LeftRightControl(RIGHT);
        }
    }
    
    //Forward control is responsible for putting the minecart into forward or reverse gear.
    //The bool parameter controls a selector that will change the direction by simple multiplication.
    void ForwardControl(bool forward){
        int directionSelection = 1;
        if(!forward){
            directionSelection = -1;
        }
        connector.transform.position =  connector.transform.position +  connector.transform.forward * Time.deltaTime * acceleration * directionSelection;
    }

    void LeftRightControl(bool right){
        int directionSelection = 1;
        if(!right){
            directionSelection = -1;
        }
        transform.position = transform.position + transform.right * Time.deltaTime * acceleration * directionSelection;
    }
}
