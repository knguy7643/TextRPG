using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonster : MonoBehaviour
{
    //This field will store the monsters name.
    public string name;

    //This field will store the monster's spirte image.
    public Sprite image;

    //This field will store the region the monster is on.
    public RegionList regionLocation;

    //This field will store the monsters rarity.
    public Rarity rarity;

    //These fields will store the monsters stats.
    private int currentHP;
    private int maxHP;
    private int attackStat;
    private int defenseStat;
    private int agilityStat;
    public int level;
    private int expReward;

    // Start is called before the first frame update
    void Start()
    {
        if (rarity == Rarity.Legendary) {
            maxHP = level * 8;
            currentHP = maxHP;
            attackStat = 9 * (level - 1);
            defenseStat = 9 * (level - 1);
            agilityStat = 9 * (level - 1);
		}
        else if (rarity == Rarity.Epic) {
            maxHP = level * 7;
            currentHP = maxHP;
            attackStat = 8 * (level - 1);
            defenseStat = 8 * (level - 1);
            agilityStat = 8 * (level - 1);  
		}
        else if (rarity == Rarity.Rare) {
            maxHP = level * 6;
            currentHP = maxHP;
            attackStat = 7 * (level - 1);
            defenseStat = 7 * (level - 1);
            agilityStat = 7 * (level - 1);  
		}
        else if (rarity == Rarity.Uncommon) {
            maxHP = level * 5;
            currentHP = maxHP;
            attackStat = 6 * (level - 1);
            defenseStat = 6 * (level - 1);
            agilityStat = 6 * (level - 1);  
		}
        else {
            maxHP = level * 4;
            currentHP = maxHP;
            attackStat = 5 * (level - 1);
            defenseStat = 5 * (level - 1);
            agilityStat = 5 * (level - 1);  
		}

        
    }

    public Rarity GetRarity() {
     return rarity;
	}
}

//This enum will dictate a monster's rarity.
public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}
