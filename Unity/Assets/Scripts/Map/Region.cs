using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

//This enum will help determine what monster spawns where.
public enum RegionList
{ 
    Grass,
    Sand,
    Water,
    Sea,
    Ice,
    Cave
}