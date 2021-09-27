using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Ball")]
    Rigidbody2D rigi;
    public float speed;
    int isRight = 1;
    public float jumpDistance;
    public Camera cameraC;
    public int starAmount=0;
    public GameObject completeCanvas;
    public GameObject failCanvas;
    public GameObject game;

   
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        
    }

   
    void Update()
    {
        transform.Translate(isRight * Time.deltaTime*speed,0,0);
        if (Input.GetMouseButtonDown(0)&& rigi.velocity.y==0)
        {
            rigi.velocity = Vector2.up * jumpDistance;
            if (GameObject.Find("GameEnd").GetComponent<GameEnd>().gameStart == false){
                GameObject.Find("GameEnd").GetComponent<GameEnd>().gameStart = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Corner"))
        {
            cameraC.GetComponent<CameraSc>().shake = true;
            if (isRight == 1)
            {
                isRight = -1;
            }
            else
            {
                isRight = 1;

            }
        }
    }
    void OnBecameInvisible()
    {
        game.SetActive(false);
        failCanvas.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Star"))
        {
            collision.gameObject.SetActive(false);
            starAmount++;
        }
        if (collision.transform.CompareTag("Final"))
        {
            game.SetActive(false);
            completeCanvas.SetActive(true);
            failCanvas.SetActive(false);
        }
        if (collision.transform.CompareTag("GameEnd"))
        {
            game.SetActive(false);
            failCanvas.SetActive(true);
        }
    }
}
