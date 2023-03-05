using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class survive : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;

    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
        
    }

    private void OnCollisionEnter(Collision collis)
    {
        string TagName;
        TagName = collis.gameObject.tag;

        switch (TagName)
        {
            case "darkball":
                health -= 30;
                break;

            case "purpleghost":
                health -= 50;
                break;

            case "skell":
                health -= 40;
                break;

        }

        if (health < 0)
        {
            //Destroy(gameObject);
            GameOver();
        }



    }

    private void GameOver()
    {
        if (health < 0)
        {
            //Debug.Log("health negative");
            //Destroy(gameObject);
        }
    }

}

//NOTE :: DONT USE DESTROY CHILD CUZ OF ERROE, INSTED WE WILL BRING GAME OVER SCREEN SOMEHOW WHEN WE RUN OUT OF HEALTH.