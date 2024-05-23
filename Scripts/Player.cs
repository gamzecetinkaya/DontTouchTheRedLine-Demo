using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 2f;
    public float jumpForce = 5f;
    public float fallMultiplier = 2.5f; // Düþüþ ivmesini artýrmak için çarpan
    public float lowJumpMultiplier = 2f; // Düþük zýplama için çarpan
    private Rigidbody rb;
    private bool isGrounded;
    public GameObject panelCongratulations;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        
        Vector3 movement = new Vector3(moveVertical, 0.0f, -moveHorizontal) * speed;

        
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Yere temas varsa zýplama kuvveti uygula
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            isGrounded = false;
        }

        
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.6f);

        
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Red"))
        {
            
            Die();
        }

        if (other.CompareTag("WhiteCube"))
        {
            Material cubeMaterial = other.gameObject.GetComponent<Renderer>().material;
            if (cubeMaterial.color == Color.green)
            {
                cubeMaterial.color = Color.white; 
                other.gameObject.GetComponent<GreenCube>().cubeManager.GreenCubeTurnedWhite();
            }
        }

        if (other.gameObject.CompareTag("BlueCube"))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);

            if (other.CompareTag("BlueCube") && SceneManager.GetActiveScene().buildIndex == 9)
            {
                ShowCongratulationsPanel();
            }
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ShowCongratulationsPanel()
    {
        if (panelCongratulations != null)
        {
            panelCongratulations.SetActive(true);
            
        }
      
    }
}