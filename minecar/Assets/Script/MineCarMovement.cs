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

    public float acceleration = 0f;
    public float maxSpeed = 0f;

    public bool alignUsingRay;
    protected float currentSpeed;
    
    enum direction
    {
        FORWARD  = 0,
        BACKWARD = 1,
        LEFT = 0,
        RIGHT = 1
    }

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
        if(Input.GetKey("w")){
            ForwardControl(direction.FORWARD);
         }

         else if(Input.GetKey("s")){
             ForwardControl(direction.BACKWARD);
         }
            
        else if(Input.GetKey("a")){
             LeftRightControl(direction.LEFT);
        }

        else if(Input.GetKey("d")){
            LeftRightControl(direction.RIGHT);
        }
    }
    
    //Forward control is responsible for putting the minecart into forward or reverse gear.
    //The direction parameter controls a selector that will change the direction by simple multiplication.
    void ForwardControl(direction selection){
        int directionSelection = 1;
        if(selection == direction.BACKWARD){
            directionSelection = -1;
        }
        connector.transform.position = connector.transform.position +  connector.transform.forward * Time.deltaTime * acceleration * directionSelection;
    }

    void LeftRightControl(direction selection){
        int directionSelection = 1;
        if(selection == direction.LEFT){
            directionSelection = -1;
        }
        transform.position = transform.position + transform.right * Time.deltaTime * acceleration * directionSelection;
    }
}