using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCube : MonoBehaviour
{
    public CubeControl cubeManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            
            Material cubeMaterial = GetComponent<Renderer>().material;
            if (cubeMaterial.color == Color.green)
            {
                cubeMaterial.color = Color.white;
                cubeManager.GreenCubeTurnedWhite();
            }
        }
    }
}
