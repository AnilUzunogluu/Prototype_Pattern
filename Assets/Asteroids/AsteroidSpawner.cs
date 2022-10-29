using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private Material _material;

    public GameObject asteroid;


    public void CreateAsteroid()
    {
        asteroid = ProcAsteroid.Clone(transform.position);
        asteroid.GetComponent<MeshRenderer>().sharedMaterial = _material;
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateAsteroid();
    }
}
