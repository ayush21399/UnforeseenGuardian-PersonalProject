using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bul : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rg;
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        rg.AddForce(transform.forward * 80);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision coli)
    {
        Destroy(this.gameObject);
    }

}
