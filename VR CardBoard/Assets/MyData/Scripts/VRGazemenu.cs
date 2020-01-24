using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VRGazemenu : MonoBehaviour
{

    public Image imgGaze;
    public float totalTime = 1;
    bool gvrStatus;
    float gvrTimer;

    public int distanceOfRay = 1500;
    public RaycastHit _hit;


    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / totalTime;

        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out _hit, distanceOfRay))

        {


            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("start"))
            {

                SceneManager.LoadScene("SampleScene");

            }
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("exit"))
            {

                Application.Quit();

            }


        }
    }

    public void GVROn()
    {
        gvrStatus = true;

    }

    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
    }
}
