using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
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

    public void EnterBattle(Rarity rarity) {
        playerCamera.SetActive(false);
        battleCamera.SetActive(true);
	}

}
