using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ballSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    int count = 1;

    public Text turnCountTxt;

    public GameObject gameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Sphere").GetComponent<Renderer>().material.SetColor("_Color", Color.black);
        turnCountTxt.text = "" + 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBall()
    {
        if (count < 5)
        {
           GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);

            var cubeRenderer = ball.GetComponent<Renderer>();

            if (count == 2) 
               cubeRenderer.material.SetColor("_Color", Color.blue);

            if (count == 3) 
               cubeRenderer.material.SetColor("_Color", Color.red);

            if (count == 4) 
               cubeRenderer.material.SetColor("_Color", Color.green);
        }

        else
        {
            StartCoroutine(gameOver());
            
         }
       
    }

    public void turns()
    {
        count++;

        turnCountTxt.text = "" + (5 - count);
    }

    IEnumerator gameOver()
    {
        yield return new WaitForSeconds(0.5f);
        gameOverUI.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        gameOverUI.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
