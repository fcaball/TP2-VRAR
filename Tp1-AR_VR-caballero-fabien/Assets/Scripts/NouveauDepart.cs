using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameVariables;
using UnityEngine.SceneManagement;

public class NouveauDepart : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    { // OnCollisionEnter 

        if (other.tag == "Player" && nbCats >= 2)
        {
            SceneManager.LoadScene("SampleScene"); // le nom de votre scene

        }
    }
}
