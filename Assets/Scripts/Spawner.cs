using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] KeyCode KeyCode;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode))
        {
            Instantiate(prefab);
        }
    }
}
