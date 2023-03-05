using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;


public class ghostpurplebox : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent nmg;
    public GameObject boy;

    //health
    private float health;
    void Start()
    {
        nmg = GetComponent<NavMeshAgent>();

        health = 100;
        
    }

    // Update is called once per frame
    void Update()
    {
        desti();

        Vector3 vel = nmg.velocity;
        if (vel.magnitude != 0)
        {
            Invoke("moveaction",0.5f); //used invoke bcz of lookrotion popup comment saying it set to zero
            
        }

    }

    private void desti()
    {
        boy = GameObject.FindGameObjectWithTag("Boy");
        nmg.SetDestination(boy.transform.position);

    }

    private void moveaction()
    {
            transform.rotation = Quaternion.LookRotation(nmg.velocity.normalized);
    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Boy")
        {
            Destroy(gameObject);
        }

        if(col.gameObject.tag == "bullet")
        {
            health -= 50;
            if (health < 0)
            {
                Destroy(gameObject);
            };
        }
    }

}
