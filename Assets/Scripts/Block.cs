using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    public Color myColor;
    float redChannel;
    float greenChannel;
    float blueChannel;
    float alphaChannel;
    public Renderer myRenderer;
    public int value;
    public TextMeshPro valueText;
    public bool isGood;
    public bool isAlmostGood;
    public GameObject snake;
    SnakeTail snakeTail;
    SnakeMovement snakeMovement;
    int valueToAddScore;
    private void Awake()
    {
        myRenderer = GetComponent<Renderer>();
        valueText.SetText(value.ToString());
        snakeTail = snake.GetComponent<SnakeTail>();
        snakeMovement = snake.GetComponent<SnakeMovement>();
        if (isGood == true)
        {
            value = Random.Range(1, 5);
        }
        else if (isAlmostGood == true)
        {
            value = Random.Range(1, 15);
        }
        else
        {
            value = Random.Range(1, 50);
        }
        valueToAddScore = value;
    }
    void Start()
    {
        alphaChannel = 1.0f;
    }
    void Update()
    {
        valueText.SetText(value.ToString());
        myColor = new Color(redChannel, greenChannel, blueChannel, alphaChannel);
        myRenderer.material.color = myColor;
        if (value >= 40)
        {
            redChannel = 0.61f;
            greenChannel = 0.0f;
            blueChannel = 0.0f;
        }
        if (value >= 30 && value < 40)
        {
            redChannel = 0.0f;
            greenChannel = 0.0f;
            blueChannel = 0.61f;
        }
        if (value >= 20 && value < 30)
        {
            redChannel = 0.0f;
            greenChannel = 0.5f;
            blueChannel = 0.50f;
        }
        if (value > 10 && value < 20)
        {
            redChannel = 0.34f;
            greenChannel = 0.70f;
            blueChannel = 0.0f;
        }
        if (value <= 10)
        {
            redChannel = 1.0f;
            greenChannel = 0.70f;
            blueChannel = 0.2f;
        }
        if (value <= 0)
        {
            for (int i = 0; i < valueToAddScore; i++)
            {
                snakeMovement.score++;
            }
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (snakeTail.isCrazy == false)
            {
                snakeMovement.snakeHead.AddForce(0, 0, -1200.0f);
                value--;
                snakeTail.DeleteTail();
            }
            if (snakeTail.isCrazy == true)
            {
                for (int i = 0; i < valueToAddScore; i++)
                {
                    snakeMovement.score++;
                }
                Destroy(this.gameObject);
            }
        }
    }
}