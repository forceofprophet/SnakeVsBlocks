using UnityEngine;
using TMPro;

public class BlockSurprise : MonoBehaviour
{
    public int value;
    public TextMeshPro valueText;
    public GameObject snake;
    SnakeTail snakeTail;
    SnakeMovement snakeMovement;
    int valueToAddScore;
    private void Awake()
    {
        valueText.SetText(value.ToString());
        snakeTail = snake.GetComponent<SnakeTail>();
        snakeMovement = snake.GetComponent<SnakeMovement>();
        snakeMovement = snake.GetComponent<SnakeMovement>();
        value = Random.Range(1, 10);
        valueToAddScore = value;
    }
    void Update()
    {
        valueText.SetText(value.ToString());
        if (value <= 0)
        {
            snakeTail.isCrazy = true;
            Destroy(this.gameObject);
            for (int i = 0; i < valueToAddScore; i++)
            {
                snakeMovement.score++;
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            snakeMovement.snakeHead.AddForce(0, 0, -2300.0f);
            value--;
            snakeTail.DeleteTail();
        }
    }
}