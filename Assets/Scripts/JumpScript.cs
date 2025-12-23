using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{

    bool bJumping_ = false;
    bool bCancelJump_ = false;
    public LayerMask raycastAffectedLayers_;
    public float jumpForce_ = 100.0f;
    public float floorRCOffset_ = 0.01f;
    private Vector3 checkFloorBox_ = new Vector3();
    bool bOnFloor_ = false;
    Vector3 currentVelocity_ = new Vector3();
    Rigidbody rb_ = null;
    Transform tr_ = null;
    CapsuleCollider collider_ = null;

    // Start is called before the first frame update
    void Start(){
        rb_ = GetComponent<Rigidbody>();
        tr_ = GetComponent<Transform>();
        collider_ = GetComponent<CapsuleCollider>();

        checkFloorBox_.x = collider_.radius;
        checkFloorBox_.z = collider_.radius;
        checkFloorBox_.y = floorRCOffset_;
    }

    // Update is called once per frame
    void Update(){

        bOnFloor_ = CheckFloor();

        if (bOnFloor_){

            bJumping_ = Input.GetButtonDown("Jump");
        }
        bCancelJump_ = Input.GetButtonUp("Jump");
    }

    bool CheckFloor(){

        Debug.DrawLine(rb_.position, rb_.position - (tr_.up *
                ((collider_.height * 0.5f) + floorRCOffset_)), Color.magenta
                );

        //if (Physics.Raycast(rb_.position,-tr_.up, (collider_.height*0.5f) + floorRCOffset_)){

        //    return true;
        //}

        if (Physics.CheckBox(rb_.position - tr_.up * (collider_.height * 0.5f),
            checkFloorBox_, tr_.rotation, raycastAffectedLayers_.value)
           ){

            return true;
        }

        return false;
    }

    private void FixedUpdate(){

        if (bJumping_ && !bCancelJump_){
            bJumping_ = false;
            bOnFloor_ = false;

            rb_.AddForce(tr_.up * jumpForce_, ForceMode.Impulse);

        }else if (bCancelJump_){
            if(rb_.velocity.y >= 0.0f){
                currentVelocity_ = rb_.velocity;
                currentVelocity_ *= 0.15f;
                rb_.velocity = currentVelocity_;
            }
        }

    }
}
