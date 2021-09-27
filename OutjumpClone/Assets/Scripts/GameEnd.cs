using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{

    public bool gameStart = false;
    public float speedAmount;

   
    void Update()
    {
        if (gameStart)
        {
            transform.Translate(new Vector3(0, speedAmount * Time.deltaTime, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Ball"))
        {
            Debug.Log("Carpti");
        }
    }
}
