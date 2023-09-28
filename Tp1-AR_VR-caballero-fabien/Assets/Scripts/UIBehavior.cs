using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using static GameVariables;
public class UIBehaviour : MonoBehaviour
{
    TMP_Text headText;

    [SerializeField]
    TMP_Text timerText;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "dragonHouse")
            headText = GameObject.Find("lblCats").GetComponent<TMPro.TMP_Text>();

        timerText.text = "Time :" + currentTime.ToString();
        StartCoroutine(TimerTick());

    }
    void Update()
    {

    }
    public void AddHit()
    {
        nbCats++;
        headText.text = "BobHeads: " + nbCats;
    }

    IEnumerator TimerTick()
    {
        while (currentTime > 0)
        {
            // attendre une seconde
            yield return new WaitForSeconds(1);
            currentTime--;
            timerText.text = "Time :" + currentTime.ToString();
        }
        // game over
        SceneManager.LoadScene("dragonHouse"); // le nom de votre scene
    }

}
