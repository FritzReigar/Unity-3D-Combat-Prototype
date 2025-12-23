using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour{

    public Transform targetTr_ = null;
    public float rotSpeed_ = 0.0f;

    private Transform tr_ = null;

    private Vector3 myUpChispas_ = new Vector3();
    private Vector3 targetOffset_ = new Vector3();
    private Quaternion deltaRot_;

    // Start is called before the first frame update
    void Start(){
        tr_ = GetComponent<Transform>();
        myUpChispas_.y = 1.0f;
        myUpChispas_.x = 0.0f;
        myUpChispas_.z = 0.0f;

        targetOffset_ = tr_.position - targetTr_.position; //World space
    }

    // Update is called once per frame
    void LateUpdate(){

        deltaRot_ = Quaternion.EulerAngles(0.0f,
            rotSpeed_ * Input.GetAxis("Mouse X") * Time.deltaTime,
            0.0f);

        targetOffset_ = deltaRot_ * targetOffset_;
        tr_.position = targetTr_.position + targetOffset_; //Place camera with rotation


        tr_.LookAt(targetTr_);

        //myUpChispas_ is equal to Vector3.up
        //tr_.RotateAround(targetTr_.position, Vector3.up,
        //    rotSpeed_ * Input.GetAxis("Mouse X") * -1.0f);
    }
}
