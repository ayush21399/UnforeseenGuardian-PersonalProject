using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog : MonoBehaviour
{
    
    public Transform[] waypoints = new Transform[5];

    public int currentPoint;
    public int Point;
    public int speed = 2;

   
    
    
    void Start()
    {
        

        //first moving to 1st point as first random
        Point = 1;
    }

    
    void Update()
    {
       
        moveposition();        
    }

    void moveposition()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[Point].position, speed * Time.deltaTime);
        transform.LookAt(waypoints[Point]);
        transform.forward = -transform.forward; //use better version


        if (Vector3.Distance(transform.position, waypoints[Point].position) < 0.2f)
        {
            //using while to not repeat to same point again and ran into bug or weired behaviour
            currentPoint = Point;           
            while (currentPoint == Point) 
            {
                Point = Random.Range(1, 4);
            }
        }
        

        
       
    }
}
