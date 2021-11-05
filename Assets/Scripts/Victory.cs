using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    // Start is called before the first frame update

    int score;
    void OnTriggerEnter(Collider other)
    
    
    {

        if (other.gameObject.CompareTag("Victory"))
        {

            SceneManager.LoadScene("VictoryScene");
        }

        }
    
    

}
