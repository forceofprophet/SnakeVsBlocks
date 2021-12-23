using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public GameObject head;
    Transform headTransform;
    public Transform snakeTail;
    private float bodyPartDiameter = 1;
    public List<Transform> bodyParts = new List<Transform>();
    private List<Vector3> bodyPartPositions = new List<Vector3>();
    private SnakeMovement snakeMovement;
    public GameObject fracturedSnakeHead;
    private float timer = 5.0f;
    public bool isCrazy;
    Material playerMaterial;
    float materialValue;
    public UIMenu uiMenu;
    private void Awake()
    {
        playerMaterial = head.GetComponent<MeshRenderer>().sharedMaterial;
        headTransform = head.GetComponent<Transform>();
        bodyPartPositions.Add(headTransform.position);
        snakeMovement = GetComponent<SnakeMovement>();
        AddTail();
        AddTail();
        AddTail();
        isCrazy = false;
    }
    private void Update()
    {
        if (timer <= 0) isCrazy = false;
        playerMaterial.SetFloat("colorValue", materialValue);
        if (head.gameObject != null)
        {
            float distance = ((Vector3)headTransform.position - bodyPartPositions[0]).magnitude;

            if (distance > bodyPartDiameter)
            {
                Vector3 direction = ((Vector3)headTransform.position - bodyPartPositions[0]).normalized;
                bodyPartPositions.Insert(0, bodyPartPositions[0] + direction * bodyPartDiameter);
                bodyPartPositions.RemoveAt(bodyPartPositions.Count - 1);
                distance -= bodyPartDiameter;
            }
            for (int i = 0; i < bodyParts.Count; i++)
            {
                bodyParts[i].position = Vector3.Lerp(bodyPartPositions[i + 1], bodyPartPositions[i], distance / bodyPartDiameter);
            }
        }
        if (isCrazy == true)
        {
            materialValue = Mathf.Lerp(materialValue, 1.0f, 10.0f * Time.deltaTime);
            timer -= Time.deltaTime;
        }
        if (isCrazy == false)
        {
            timer = 5.0f;
            materialValue = Mathf.Lerp(materialValue, 0.0f, 10.0f * Time.deltaTime);
        }
    }
    public void AddTail()
    {
        Transform bodyPart = Instantiate(snakeTail, bodyPartPositions[bodyPartPositions.Count -1], Quaternion.identity, transform);
        bodyParts.Add(bodyPart);
        bodyPartPositions.Add(bodyPart.position);
        snakeMovement.length++;
        snakeMovement.lenghtText.SetText(snakeMovement.length.ToString());
    }
    public void DeleteTail()
    {
        if (snakeMovement.length > 0)
        {
            Destroy(bodyParts[0].gameObject);
            bodyParts.RemoveAt(0);
            bodyPartPositions.RemoveAt(0);
            snakeMovement.length--;
            snakeMovement.lenghtText.SetText(snakeMovement.length.ToString());
        }
        else
        {
            GameObject fracturedSnakeHeadObj = Instantiate(fracturedSnakeHead, transform.position, transform.rotation) as GameObject;
            Rigidbody[] allRigidBodies = fracturedSnakeHeadObj.GetComponentsInChildren<Rigidbody>();
            if (allRigidBodies.Length > 0)
            {
                foreach (var body in allRigidBodies)
                {
                    body.AddExplosionForce(150, -Vector3.forward, 10);
                }
            }
            Destroy(head.gameObject);
            snakeMovement.length--;
            snakeMovement.lenghtText.SetText(snakeMovement.length.ToString());
            uiMenu.Loss();
        }
    }
 
}

