using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject snake;
    SnakeMovement snakeMovement;
    public UIMenu uiMenu;
    private void Awake()
    {
        snakeMovement = snake.GetComponent<SnakeMovement>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            snakeMovement.isFinished = true;
            uiMenu.Won();
        }
    }
}
