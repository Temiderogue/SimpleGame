using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGeneration : MonoBehaviour
{
    public GameObject cube;
    public void GenerateCube()
    {
        Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
        Instantiate(cube, position, Quaternion.identity);
    }
}
