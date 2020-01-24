using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class disparo : MonoBehaviour
{
    int numero = 0;

    // Start is called before the first frame update
    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("lanzar"))
        {
            Debug.Log("diana");
            Destroy(collision.gameObject);
            numero++;
        }
        if (numero == 6)
        {
            SceneManager.LoadScene("Menu");
           
        }
    }
}
