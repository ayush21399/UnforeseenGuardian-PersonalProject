using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerascri : MonoBehaviour
{
    //variable
    public Transform player;
    public float smoothdam = 0.3f;
    public float height = 6f;

    private Vector3 velocity = Vector3.zero;

    //methods
    private void Update()
    {
        Vector3 pos = new Vector3();
        pos.x = player.position.x;
        pos.z = player.position.z - 6f;
        pos.y =  height; //sepreat player pos with - heigh and you get damped cam

        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothdam);


    }



}
