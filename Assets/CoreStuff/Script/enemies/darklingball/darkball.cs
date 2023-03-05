using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class darkball : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent nmg;
    public GameObject boy;
    Rigidbody rb;

    private float health;

    private float dist;

    //color and componenet from child
    //public Component comp;  // -- be continue -- execution cannot be done cuz material arent component
    public GameObject gb;
    public Transform tf;
    public Material ma;

    void Start()
    {
        nmg = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        //health 
        health = 100;

        //using: checking transform and getting material from gameobject
        tf = this.gameObject.transform.GetChild(1);
        gb = tf.gameObject;
        ma = gb.GetComponent<SkinnedMeshRenderer>().material;
        //gb.GetComponent<SkinnedMeshRenderer>().material.color = Color.white //expanded in above steps, so that we can just use ma insted of writing whole thing.


    }

    // Update is called once per frame
    void Update()
    {
        desti();

        if (nmg.isStopped == true)
        {
            StartCoroutine(ColorAndDestroy()); // change color and then destory
        }
    }

    private void desti()
    {
        boy = GameObject.FindGameObjectWithTag("Boy");
        nmg.SetDestination(boy.transform.position);

        dist = Vector3.Distance(boy.transform.position, transform.position);

        if (dist < 2)
        {
            nmg.isStopped = true;           
            
        }
        else
        {
            if (nmg.isStopped == false)
            {
                transform.rotation = Quaternion.LookRotation(nmg.velocity.normalized);
            }
            //cant jump with navmesh agent, inorder to jump we need to disable agent and kinementics (which let nav to have proper control of obj)..
            //or else we can make ghost child of another object and let other object jump 
            
        }
    }

    

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "bullet")
        {
            health -= 50;
            //Destroy(col.gameObject); //
            if (health < 0)
            {
                Destroy(gameObject);
            }

        }
    }

    IEnumerator ColorAndDestroy()
    {
        //ma.color = Color.blue;
        ma.color = Color.Lerp(Color.red, Color.white, Mathf.PingPong(Time.time, 1));

        //stuff before waiting
        yield return new WaitForSeconds(3);
        //stuff after waiting

        if (dist < 2) {
            //Debug.Log("Death to player");
            boy.GetComponent<survive>().health -= 60;

        }

    }
    

}




//Note : CHILDREN HIRECHY IS CONTROLED BY TRANSFORM (NOT BY GAMEOBJECT)AND SO WE CANNOT ACCESS DIRECT GAMEOBJECT, WE NEED TO REFER FIND CHILD BY TRANSFORM.FINDCHILD 
//       AND THEN ATTACH PUB GAMEOBEJCT TO THAT TRANSFORM GAMEOBEJCT.