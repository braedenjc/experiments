using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRailConnectorAlignment : MonoBehaviour
{
    public Rigidbody rb;
    public float yOffset; //This is used to set the y co-ordinate of the box to make sure it sits on top of the rail.

    // Start is called before the first frame update
    void Start()
    {     
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AlignConnectorToRail(Collision collider){
        //Align the rotation of the connector to the rail.
        transform.rotation = collider.gameObject.transform.rotation;
        transform.Rotate(-90, 0, 0, Space.Self);

        //Center the connector on the top of the rail.
        //transform.position = collider.gameObject.transform.position;
        transform.position += new Vector3(0, yOffset, 0);
    }

    void OnCollisionEnter(Collision collider){
        Debug.Log("Box Connector Sees " + collider.gameObject.name);
        AlignConnectorToRail(collider);
    }

    void OnCollisionStay(Collision collider){
        Debug.Log("Box is in " + collider.gameObject.name + " collider");
    }

    void OnCollisionExit(Collision collider){
        Debug.Log("Box has left " + collider.gameObject.name + " collider");
    }
}
