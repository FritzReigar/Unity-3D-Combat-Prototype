using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProCharacterMovement : MonoBehaviour{

    public Transform cameraTr_ = null;
    public float speed_ = 10.0f;
    public float dotOffset_ = 0.90f;
    public float rotSpeed_ = 10.0f;

    private Transform tr_ = null;
    private Vector3 movDir_ = new Vector3(); // Local to camera

    private Vector3 camDir_ = new Vector3();

    Rigidbody m_Rigidbody;
    public float m_Thrust = 20f;
    // Start is called before the first frame update
    void Start(){
        tr_ = GetComponent<Transform>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
        movDir_.z = Input.GetAxis("Vertical");
        movDir_.x = Input.GetAxis("Horizontal");

        if (Input.GetButton("Jump"))
        {
           //Apply a force to this Rigidbody in direction of this GameObjects up axis
           m_Rigidbody.AddForce(transform.up * m_Thrust);
        }

        if (movDir_.magnitude != 0.0f)
        {
        //tr_.Translate(movDir_ * speed_ * Time.deltaTime, Space.World);

        camDir_ = cameraTr_.forward;
        camDir_.y = 0.0f;
        camDir_.Normalize();

            if (Vector3.Dot(tr_.forward, camDir_) >= dotOffset_)
            {
                movDir_.Normalize();
                movDir_ = cameraTr_.TransformDirection(movDir_);
                movDir_.y = 0.0f; //Project to plane
                movDir_.Normalize();
                //MOVE!
                tr_.forward = camDir_;
                tr_.Translate(movDir_ * speed_ * Time.deltaTime, Space.World);

            }
            else //ROTATE
            {
                tr_.forward =
                    Vector3.RotateTowards(tr_.forward, camDir_,
                    rotSpeed_ * Time.deltaTime, 0.0f
                    );
            }
        }
       // Debug.Log("Dot char vs cam:" + Vector3.Dot(tr_.forward,camDir_));

    }
}
