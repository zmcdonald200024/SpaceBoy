using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {

            source.Play();
        }
    }


}
