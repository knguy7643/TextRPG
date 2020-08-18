using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject playerCamera;
    public GameObject battleCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera.SetActive(true);
        battleCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
