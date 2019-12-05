using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8;
    public int time;
    public Rigidbody rb;
    public int cubes = 4;
    public GameObject cube;
    private int count;
    public Text countText, winText, TimeText;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        winText.text = "";
        count = 0;
        setCount();
    }

    float timeLeft = 60;

    public void Update()
    {
        timeLeft -= Time.deltaTime;
        Mathf.RoundToInt(timeLeft);
        TimeText.text = timeLeft.ToString();
        if (timeLeft < 0)
        {
            TimeText.text = "0";
            winText.text = "Your score is " + count;
        }
    }

    void FixedUpdate()
    {
        //Player Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveHorizontal, 0.2f, moveVertical);
        rb.AddForce(move * speed);
 

        //Exit Button
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cube" && timeLeft > 0)
        {
            Destroy(other.gameObject);
            count++;
            setCount();
            GenerateCube();
        }
    }

    private void setCount()
    {
        countText.text = "Count: " + count.ToString();
    }

    public void GenerateCube()
    {
        Vector3 position = new Vector3(Random.Range(-30.0f, 30.0f), 0, Random.Range(-30.0f, 30.0f));
        Instantiate(cube, position, Quaternion.identity);
    }
}
