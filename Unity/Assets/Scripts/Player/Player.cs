using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public string playerName;
    public CharacterClass characterClass;
    public int level;

    //These field stores player stats.
    public int maxHP;
    public int currentHP;
    public int attackStat;
    public int defenseStat;
    public int abilityStat;
    public int totalExp;

    public List<Ability> abilities = new List<Ability>();

    // Start is called before the first frame update
    void Start()
    {
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetLevel() {
        return level;
	}
}

public enum CharacterClass 
{
    Braver,
    Knight,
    Assassin,
    Force,
    Bladedancer,
}
