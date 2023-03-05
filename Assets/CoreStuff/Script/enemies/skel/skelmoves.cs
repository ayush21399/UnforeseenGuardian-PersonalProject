using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class skelmoves : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent nmg;
    public GameObject boy;

    //animator
    public Animator anim;
   
    void Start()
    {
        nmg = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        //finding and using boy's componenet for helath and navigation
        boy = GameObject.FindGameObjectWithTag("Boy");
        
    }

    // Update is called once per frame
    void Update()
    {
        desti();

        Vector3 vel = nmg.velocity;
        if (vel.magnitude != 0)
        {
            Invoke("moveaction", 0.5f); //used invoke bcz of lookrotion popup comment saying it set to zero

        }
    }

    private void desti()
    {
        
        nmg.SetDestination(boy.transform.position);

        float dist = Vector3.Distance(boy.transform.position, transform.position);
        if (dist < 2)
        {
            nmg.isStopped = true;
            anim.SetBool("nearenemy", true);
            if (!IsInvoking("attack"))
            {
                InvokeRepeating("attack", 3f, 2f);
            }
        }
        else
        {
            nmg.isStopped = false;
            anim.SetBool("nearenemy", false);
            if (IsInvoking("attack"))
            {
                CancelInvoke("attack");
            }
        }
       
    }

    private void moveaction()
    {
        if (nmg.isStopped == false)
        {
            transform.rotation = Quaternion.LookRotation(nmg.velocity.normalized);
        }
    
    }

    void attack()
    {
        boy.GetComponent<survive>().health -= 50;
    }



}
