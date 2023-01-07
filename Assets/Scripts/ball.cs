using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    ConstantForce Constantforce;
    float force;
    bool pressed, canMoveSide, canMove;

    public float speed = 0.2f, sideSpeed = 0.2f;

    ballSpawner spawner;
    GameController gameController;

    int a = -1;
    // Start is called before the first frame update
    void Start()
    {
        Constantforce = GetComponent<ConstantForce>();
        spawner = GameObject.Find("SpawnPoint").GetComponent<ballSpawner>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        canMoveSide = true;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
        moveBall();

        print(force);
    }

    private void getInput()
    {
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                pressed = true;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                pressed = false;
                canMoveSide = false;
                canMove = false;
            }
        }
        

        if (canMoveSide)
        {
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                Vector3 temp = transform.position;
                temp.x -= sideSpeed * Time.deltaTime;
                transform.position = temp;
            }

            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                Vector3 temp = transform.position;
                temp.x += sideSpeed * Time.deltaTime;
                transform.position = temp;
            }
        }

        
    }

    void moveBall()
    {
        if (pressed)
        {
            force += speed * Time.deltaTime*50;
            a = 0;
           // print(force);
        }

       else if (!pressed && a==0)
        {
            Constantforce.force = new Vector3(0, 0, force);
            spawner.turns();
            a = 1;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "30point")
        {
            print("DONE");
            Destroy(gameObject);
            force = 0f;

            gameController.AddScore(30);
            spawner.SpawnBall();
        }

        if (other.tag == "20point")
        {
            print("DONE");
            Destroy(gameObject);
            force = 0f;

            gameController.AddScore(20);
            spawner.SpawnBall();
        }

        if (other.tag == "10point")
        {
            print("DONE");
            Destroy(gameObject);
            force = 0f;

            gameController.AddScore(10);
            spawner.SpawnBall();
        }

        if (other.tag == "disable")
        {
            Invoke("DisableBall", 3f);
        }
    }

    void DisableBall()
    {
        spawner.SpawnBall();
        Destroy(gameObject);

    }
}
