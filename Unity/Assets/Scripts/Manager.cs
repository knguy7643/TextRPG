using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject battleCamera;

    public GameObject player;

    public List<BaseMonster> allMonsters = new List<BaseMonster>();

    public Transform defenderPod;
    public Transform attackerPod;

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

    public void EnterBattle(Rarity rarity) 
    {
        playerCamera.SetActive(false);
        battleCamera.SetActive(true);

        BaseMonster battleMonster = GetRandomMonsterFromList(GetMonsterByRarity(rarity));

        //Debug.Log(battleMonster.name);



        player.GetComponent<PlayerMovement>().isAbleToMove = false;
	}

    //Returns a list of possible monster based on its rarity.
    public List<BaseMonster> GetMonsterByRarity(Rarity rarity) 
    {
         List<BaseMonster> returnMonster = new List<BaseMonster>();
         
         foreach(BaseMonster monster in allMonsters) {
            if (monster.GetRarity() == rarity) {
                returnMonster.Add(monster);     
			}  
		 }

         return returnMonster;

	}

    //Returns a random monster from a catered list.
    public BaseMonster GetRandomMonsterFromList(List<BaseMonster> monsterList) 
    {
        BaseMonster monster = new BaseMonster();

        int index = Random.Range(0, monsterList.Count - 1);

        monster = monsterList[index];

        return monster;
	}

}
