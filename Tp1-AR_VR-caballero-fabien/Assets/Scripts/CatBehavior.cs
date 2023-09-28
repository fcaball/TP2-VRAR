using UnityEngine;
public class CatBehaviour : MonoBehaviour
{
    public GameObject worldObject;

    AudioSource collisionSound;
    public GameObject fx;
    void Start()
    {
        worldObject = GameObject.Find("World");

        collisionSound = GameObject.Find("World").GetComponent<AudioSource>();

    }
    
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    { // OnCollisionEnter 

        if (other.tag == "Player")
        {
            worldObject.SendMessage("AddHit");

            if (collisionSound)
            {
                collisionSound.Play();
            }
             Instantiate(fx, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}