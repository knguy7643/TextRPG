using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass_Tall : MonoBehaviour
{
    //This field stores the type of tile the Grass_Tall is on.
    public RegionList region;

    //This field stores the game manager object.
    private Manager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.GetComponent<PlayerMovement>()) {
            
            //Common
            float c = (0.3f);

            //Uncommon
            float uc = (0.2f);

            //Rare
            float r = (0.16f);

            //Epic
            float e = (0.075f);

            //Legendary
            float l = (0.02f);

            float random = Random.Range(0.0f, 100.0f);

            if (random < l * 100) { //Spawns a Legendary
                if (manager != null) {
                    manager.EnterBattle(Rarity.Legendary);        
				}
			}
            else if (random < e * 100) { //Spawns an Epic
                if (manager != null) {
                    manager.EnterBattle(Rarity.Epic);        
				}
			}
            else if (random < r * 100) { //Spawns a Rare
                if (manager != null) {
                    manager.EnterBattle(Rarity.Rare);        
				}
			}
            else if (random < uc * 100) { //Spawns an Uncommon
                if (manager != null) {
                    manager.EnterBattle(Rarity.Uncommon);        
				}
			}
            else if (random < c * 100) { //Spawns a Common
                if (manager != null) {
                    manager.EnterBattle(Rarity.Common);        
				}
			}
		}
	}
}
