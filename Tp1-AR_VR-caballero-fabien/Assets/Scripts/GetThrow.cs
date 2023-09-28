using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetThrow : MonoBehaviour
{
    public TMP_Text PressEToGet;
    public TMP_Text infos ;
    private bool CanTakeIt = false;
    private bool isTake = false;
    private GameObject Object;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CanTakeIt && Object != null)
        {
            Object.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            Object.transform.position = GameObject.Find("TakeInRightHand").transform.position;
            Object.transform.parent = GameObject.Find("TakeInRightHand").transform;
            Object.transform.localScale*=0.2f;
            PressEToGet.gameObject.SetActive(false);
            isTake = true;
            
            infos.text="Bravo, maintenant vous pouvez les lancer en pressant sur le clic gauche de la souris";

        }

        if (Input.GetButtonDown("Fire1") && Object != null && isTake)
        {
            Object.transform.parent = null;
            Object.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            Object.transform.localScale/=0.2f;

            Object.gameObject.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward * 1500));
            isTake = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "getable")
        {
            Debug.Log("entré");
            if (!isTake)
            PressEToGet.gameObject.SetActive(true);
            Object = other.gameObject;
            CanTakeIt = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "getable")
        {
            Debug.Log("sorti");
            PressEToGet.gameObject.SetActive(false);
            Object = null;
            CanTakeIt = false;
        }
    }
}

