using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class raoming : MonoBehaviour
{

    //public Transform desitnation;
    NavMeshAgent navMeshAgent;
    RaycastHit hit;

    //rigi
    //Rigidbody rigi;

    //facing direction
    //Vector3 velofplay;

    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        //rigi = this.GetComponent<Rigidbody>();

        //just to check nav mesh null error and all
        if (navMeshAgent == null) { Debug.Log("agent is null"); }
        else
        {
          //  SetDestination();
        }

     
    }

    void Update()
    {
        clickchecker();

        Vector3 velofplay = navMeshAgent.velocity;
        if (velofplay.magnitude != 0)
        {
            //Debug.Log(velofplay);
            playerPosCorrector();

        }
    }

    private void clickchecker()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetDestination();
        }

    }

    private void SetDestination()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100))
        {
            navMeshAgent.SetDestination(hit.point);
        }
        //Vector3 targetVector = desitnation.transform.position; 
        //navMeshAgent.SetDestination(targetVector);
    }

    private void playerPosCorrector()
    {        
        transform.rotation = Quaternion.LookRotation(navMeshAgent.velocity.normalized);
    }


}
