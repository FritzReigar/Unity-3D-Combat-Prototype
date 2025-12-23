using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public float speed_ = 0.0f; // m/sec
    public float speedRot_ = 10.0f; // degrees/sec

    private Transform tr_ = null;
    private Vector3 movDir_ = new Vector3(); //Local space

    // Start is called before the first frame update
    void Start(){
        tr_ = GetComponent<Transform>();
        //movDir_ = new Vector3();
    }

    // Update is called once per frame
    void Update(){
        movDir_.z = Input.GetAxis("Vertical");
        movDir_.x = Input.GetAxis("Horizontal");

        movDir_.Normalize();
        //movDir_ = movDir_.normalized;
        //movDir_ = Vector3.Normalize(movDir_);
        //tr_.Translate(movDir_ * speed_ * Time.deltaTime);
        movDir_ = tr_.TransformDirection(movDir_); //movDir_ now is in global space
        //tr_.position += movDir_ * speed_ * Time.deltaTime;
        tr_.Translate(movDir_ * speed_ * Time.deltaTime, Space.World);

        tr_.Rotate(Vector3.up, speedRot_ * Input.GetAxis("Mouse X")) ;
    }
}
