using UnityEngine;
using TMPro;

public class Apple : MonoBehaviour
{
    public TextMeshPro valueText;
    public GameObject snake;
    SnakeTail snakeTail;
    public int value;
    [SerializeField] GameObject appleBody;
    void Awake()
    {
        value = Random.Range(1, 15);
        valueText.SetText(value.ToString());
        snakeTail = snake.GetComponent<SnakeTail>();
    }
    void Update()
    {
        appleBody.transform.Rotate(0, 1.5f, 0); 
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i < value; i++)
            {
                snakeTail.AddTail();
            }
            Destroy(this.gameObject);
        }
    }
}
