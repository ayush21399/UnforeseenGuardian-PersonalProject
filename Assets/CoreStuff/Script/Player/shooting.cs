using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{

    // only instansite bullet, bullet script will be used to guide bullet to point
    public Transform instpoint;
    public GameObject bullet;

    public Vector3 direction;
  

    void Start()
    {
        
      
    }

    // Update is called once per frame
    void Update()
    {
        shot();
       
  
    }

    private void shot()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //getting ray positiong on ground
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
            {
                //Debug.Log(hitInfo.point);

                
            }
            

            //changing aim rotation          
            //Quaternion inst = Quaternion.Euler(0, 0, 0);
            //instpoint.rotation = inst;
            instpoint.LookAt(hitInfo.point);

            Instantiate(bullet,instpoint.position,instpoint.rotation);

        }
    }
}


//note: we dirctely refered ray variable from movement script and set bul prefeb roation according to our mouse position during instantiating.
//so we dont waste time to callculate rotation after bullet drops in field, CUZ a frame misscalculation will occer as our mouse will move from shooting position
//and then bul will calculate where to go, so now problem solved as bull will just need to move ahead after instantiating cuz all other things will be redy befre. 