using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeControl : MonoBehaviour
{

    public int greenCubeCount = 6; // Yeþile dönüþecek küp sayýsý
    public GameObject[] cubes; // Küplerin dizisi
    public GameObject blueCube;
    private int greenCubesTurnedWhite = 0; // Beyaza döndürülen yeþil küp sayýsý

    private void Start()
    {
        
        ChangeRandomCubesColor();
        blueCube.SetActive(false); 
    }

    private void ChangeRandomCubesColor()
    {
        
        ShuffleArray(cubes);

        
        for (int i = 0; i < greenCubeCount && i < cubes.Length; i++)
        {
           
            Material cubeMaterial = cubes[i].GetComponent<Renderer>().material;
            cubeMaterial.color = Color.green;
            cubes[i].tag = "WhiteCube"; 

           
            GreenCube greenCube = cubes[i].GetComponent<GreenCube>();
            if (greenCube == null)
            {
                greenCube = cubes[i].AddComponent<GreenCube>();
            }
            greenCube.cubeManager = this;
        }
    }

   
    private void ShuffleArray(GameObject[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            GameObject temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }

    public void GreenCubeTurnedWhite()
    {
       
        greenCubesTurnedWhite++;
        

        
        if (greenCubesTurnedWhite >= greenCubeCount)
        {
            blueCube.SetActive(true);
        }
    }

   
    public void OnBlueButtonPressed()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1); 
    }

}

