using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour

{
    
    NinjaMoves ninjaMoves;
    // Start is called before the first frame update
    private  void Start()
    {
        ninjaMoves = GameObject.FindObjectOfType<NinjaMoves>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ninja")
        {
            //tuer ninja
            //ninjaMoves.Die();
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
