using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{

    public GameObject ball;
    public GameObject myHand;
    
    Rigidbody rigido;
    float fuerza = 1500f;

    Vector3 ballPos;

    public Camera camara;

    AudioSource[] sonido;

    // Start is called before the first frame update
    void Start()
    {
        sonido = camara.GetComponents<AudioSource>();
        rigido = ball.GetComponent<Rigidbody>();
        ballPos = ball.transform.position;
    }

    // Update is called once per frame
    public void soltarla()
    {
        Debug.Log("entra");
       
            Debug.Log("IF");
            sonido[2].Play();
            rigido.AddForce(myHand.transform.forward * fuerza);
            ball.transform.SetParent(null);
            rigido.useGravity = true;
            
            //ball.transform.localPosition = ballPos;

        

    }

    public void recogerla()
    { 
           ball.transform.SetParent(myHand.transform);
           ball.transform.localPosition = new Vector3(0.5600000f, -0.03999989f, 1.000001f);
           
            rigido.useGravity = false;
            rigido.velocity = Vector3.zero;
            sonido[1].Play();
        
    }
}
