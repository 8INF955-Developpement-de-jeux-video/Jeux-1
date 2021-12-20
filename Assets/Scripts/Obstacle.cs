using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour

{
    [SerializeField] private float speed;
    private float previous_x;
    // Start is called before the first frame update
    private  void Start()
    {


        previous_x = transform.localPosition.x;

        if (Random.Range(0, 2) == 1)
        {
            transform.localPosition -= new Vector3(speed * Time.deltaTime, 0f, 0f);

        }
        else 
        {
            transform.localPosition += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ninja")
        {
            //tuer ninja
            //ninjaMoves.Die();
        }

    } 
    void Update()
    {
        float current_x = transform.position.x;

     if( current_x <= previous_x)
        {
            if(current_x <= -transform.parent.localScale.x / 2f - 20f)
            {
                transform.localPosition += new Vector3(speed * Time.deltaTime, 0f, 0f);
            }
            else
            {
                transform.localPosition -= new Vector3(speed * Time.deltaTime, 0f, 0f);
            }
                
        }
     else 
        {
            
            if (current_x >= transform.parent.localScale.x / 2f + 20f)
            {
                transform.localPosition -= new Vector3(speed * Time.deltaTime, 0f, 0f);
            }

            else
            {
                transform.localPosition += new Vector3(speed * Time.deltaTime, 0f, 0f);

            }

        }

        previous_x = current_x;


    }
}
