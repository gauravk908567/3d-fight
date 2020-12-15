using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private CharacterController CharController;
    private CharacterAnimation PlayerAnimation;

    public float Movement_Speed = 3f;
    public float Gravity = 9.8f;
    public float Rotation_Speed = 0.15f;
    public float RotateDegreePerSecond = 180f;

    void Awake()
    {
        CharController = GetComponent<CharacterController>();
        PlayerAnimation = GetComponent<CharacterAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        rotate();
        AninmateWalk();
    }

    void Move()
    {
        if (Input.GetAxis(Axis.VERTICAL_AXIS) > 0)
        {
            Vector3 moveDirection = transform.forward;
            moveDirection.y -= Gravity * Time.deltaTime;
            CharController.Move(moveDirection * Movement_Speed * Time.deltaTime);
        }

        else if (Input.GetAxis(Axis.VERTICAL_AXIS) < 0)
        {
            Vector3 moveDirection = -transform.forward;
            moveDirection.y -= Gravity * Time.deltaTime;
            CharController.Move(moveDirection * Movement_Speed * Time.deltaTime);
        }
        else 
        {
            //if we don't have input 
            CharController.Move(Vector3.zero);
        }

        
    }//move



    void rotate()
    {
        Vector3 Rotation_Direction = Vector3.zero;
        if(Input.GetAxis(Axis.HORIZONTAL_AXIS)<0)
        {
           Rotation_Direction = transform.TransformDirection(Vector3.left);
        }
        if(Input.GetAxis(Axis.HORIZONTAL_AXIS)>0)
        {
             Rotation_Direction = transform.TransformDirection(Vector3.right);
        }

        if(Rotation_Direction != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Rotation_Direction), RotateDegreePerSecond * Time.deltaTime);
        }

    }//rotate

    void AninmateWalk()
    {
        if (CharController.velocity.sqrMagnitude != 0f)
        {
            PlayerAnimation.Walk(true);
        }
        else
        {
            PlayerAnimation.Walk(false);
        }
    }


}//class