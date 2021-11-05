using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
   

    public int score = 1;
    public int total = 0;
   // public Object Col;

    
  

  

    void OnCollisionEnter(Collision collision)
        {




        //Destroy(other);
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);



            total += score;

            UIEventController.Instance.UpdateScore(total);
        }
    }
}
