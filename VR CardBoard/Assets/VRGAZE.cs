using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGAZE : MonoBehaviour
{

    public Image imgGaze;
    public float totalTime = 1;
    bool gvrStatus;
    float gvrTimer;

    public int distanceOfRay = 1500;
    public RaycastHit _hit;


    bool inHands = false;

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
            
            
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Teleport2"))
            {
                
                _hit.transform.gameObject.GetComponent<Teleport>().TeleportPlayer();
                
            }
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("lanzar"))
            {
                if (inHands)
                {
                    _hit.transform.gameObject.GetComponent<PlayerGrab>().soltarla();
                    inHands = false;
                    gvrStatus = false;
                    gvrTimer = 0;
                    imgGaze.fillAmount = 0;
                }
            }
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("recogerla"))
            {
                if (!inHands)
                {
                    _hit.transform.gameObject.GetComponent<PlayerGrab>().recogerla();
                    inHands = true;
                    gvrStatus = false;
                    gvrTimer = 0;
                    imgGaze.fillAmount = 0;
                }
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

