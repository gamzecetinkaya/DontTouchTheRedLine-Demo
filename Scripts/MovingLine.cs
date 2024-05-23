using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingLine : MonoBehaviour
{
    public float baseSpeed = 2.0f; // Baþlangýç hýzý
    public float speedIncreasePerLevel = 0.5f; // Seviye baþýna hýz artýþý
    public float range = 5.0f; // Çizginin hareket edebileceði mesafe

    private float startZ; // Baþlangýç z pozisyonu
    private bool movingForward = true; // Çizginin hareket yönü
    private float speed; // Dinamik olarak hesaplanan hýz

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
