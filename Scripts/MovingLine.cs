using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingLine : MonoBehaviour
{
    public float baseSpeed = 2.0f; // Ba�lang�� h�z�
    public float speedIncreasePerLevel = 0.5f; // Seviye ba��na h�z art���
    public float range = 5.0f; // �izginin hareket edebilece�i mesafe

    private float startZ; // Ba�lang�� z pozisyonu
    private bool movingForward = true; // �izginin hareket y�n�
    private float speed; // Dinamik olarak hesaplanan h�z

    void Start()
    {
        startZ = transform.position.z;
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        speed = baseSpeed + (currentLevel * speedIncreasePerLevel);
    }

    void Update()
    {
        if (movingForward)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (transform.position.z >= startZ + range)
            {
                movingForward = false;
            }
        }
        else
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            if (transform.position.z <= startZ - range)
            {
                movingForward = true;
            }
        }
    }

}
