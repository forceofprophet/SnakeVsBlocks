using UnityEngine;
using TMPro;

public class SnakeMovement : MonoBehaviour
{
    public Rigidbody snakeHead;
    public float horz;
    private Vector2 touchLastPos;
    private float sideStep;
    private Camera mainCamera;
    public TextMeshPro lenghtText;
    public float forwardSpeed = 12;
    public float sensitivity = 10;
    public int length = 0;
    private SnakeTail snakeTail;
    float velocity = 0.5f;
    public bool isFinished = false;
    public int score;

    private void Awake()
    {
        mainCamera = Camera.main;
        snakeHead = GetComponent<Rigidbody>();
        snakeTail = GetComponent<SnakeTail>();

        lenghtText.SetText(length.ToString());
    }
    private void Update()
    {
        sideStep = horz;
        if (Input.GetKeyDown(KeyCode.O))
        {
            snakeTail.AddTail();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            snakeTail.DeleteTail();
        }
        horz = Input.GetAxis("Horizontal");
        if (Input.GetMouseButtonDown(0))
        {
            touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            sideStep = 0;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 delta = (Vector2)mainCamera.ScreenToViewportPoint(Input.mousePosition) - touchLastPos;
            sideStep += delta.x * sensitivity;
            touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }
        if (length < 0)
        {
            Destroy(snakeHead.gameObject);
        }
    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(sideStep) > 5) sideStep = 5 * Mathf.Sign(sideStep);
        snakeHead.velocity = new Vector3(sideStep * 11, 0, forwardSpeed);
        sideStep = 0;
        if (snakeTail.isCrazy == true)
        {
            forwardSpeed = Mathf.SmoothDamp(forwardSpeed, 18.0f, ref velocity, 0.5f);
        }
        if (snakeTail.isCrazy == false)
        {
            forwardSpeed = Mathf.SmoothDamp(forwardSpeed, 12.0f, ref velocity, 0.5f);
        }
        if(isFinished == true)
        {
            forwardSpeed = Mathf.Lerp(forwardSpeed, 0.0f, 5);
            horz = 0;
        }
    }
}
