using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    private inputhand inpt;
    private Rigidbody rigi;//we can also do like rotatetowardsmovementvec script, return movement and check magnitude as uncomeneted in idlemove script

    [SerializeField]
    private float movespeed;
    [SerializeField]
    private float rotatespeed;
    [SerializeField]
    private Camera cam;

    private float startingYpos;
    private float timtime;
    private float stoptime;

  


    private void Awake()
    {
        inpt = GetComponent<inputhand>();
        rigi = GetComponent<Rigidbody>();
    }
    void Start()
    {
        startingYpos = transform.position.y;
    }

    
    void Update()
    {
        var targetVec = new Vector3(inpt.InputVector.x, 0, inpt.InputVector.y);

        //move dir we aim
        //var moveVec = moveTowardsTarget(targetVec);
        moveTowardsTarget(targetVec);

        //rotate dir we aim
        //rotateTowardMovementVec(moveVec);
        rotateTowardsMouseVec();

        idlemoves(targetVec);
    }

    private void moveTowardsTarget(Vector3 targeVec) //change void to vector3 and with return and vallue assigned via var moveVec = moveTowardsTarget(targetVec); will do work
    {
        var speed = movespeed * Time.deltaTime;
        //transform.Translate(targeVec * speed);
        var targetpos = transform.position + targeVec * speed;
        transform.position = targetpos;

        //return targeVec;
    }

    private void rotateTowardsMouseVec()
    {
        Ray ray = cam.ScreenPointToRay(inpt.MousePos);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            var targ = hitInfo.point;           
            targ.y = transform.position.y;
            transform.LookAt(targ);

           
        }
    }

    //private void rotateTowardMovementVec(Vector3 moveVec)
    //{
    //    if (moveVec.magnitude == 0) { return; }
    //    var rotation = Quaternion.LookRotation(moveVec);
    //    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotatespeed);
    //}

    private void idlemoves(Vector3 tarvec)
    {
        Vector3 updown;
        updown = transform.position;
        //var starttime = 0;   

        if (tarvec.magnitude == 0)
        {
            timtime = Time.time - stoptime;           
            //Debug.Log("idle active");           
            updown.y = startingYpos + (Mathf.Sin(timtime * 2f) * 0.2f); //time * freq) * amplitude
            transform.position = updown;
        }
        else
        {            
            updown.y = startingYpos;
            transform.position = updown;
            stoptime = Time.time;
        }
        
       
     


    }

}
