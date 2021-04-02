using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRailConnectorAlignment : MonoBehaviour
{
    public Rigidbody rb;

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
        transform.rotation = collider.gameObject.transform.rotation;
        transform.Rotate(-90, 0, 0, Space.Self);
    }

    void OnCollisionEnter(Collision collider){
        Debug.Log("Box Connector Sees " + collider.gameObject.name);
        AlignConnectorToRail(collider);
    }

    void OnCollisionStay(Collision collider){
        Debug.Log("Box is in " + collider.gameObject.name + " collider");
    }
}
