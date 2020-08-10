using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonster : MonoBehaviour
{
    //This field will store the monsters name.
    public string Mname;

    //This field will store the monster's spirte image.
    public Sprite image;

    //This field will store the region the monster is on.
    public RegionList regionLocation;

    //This field will store the monsters rarity.
    public Rarity rarity;
    private Rarity storedRarity;

    //These fields will store the monsters stats.
    private int currentHP;
    private int maxHP;
    private int attackStat;
    private int defenseStat;
    private int agilityStat;
    private int level;
    private int expReward;

    public GameObject player;

    public List<Ability> abilities = new List<Ability>();

    // Start is called before the first frame update
    void Start()
    {
        storedRarity = rarity;
        level = 3;
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

    public void AddMember(BaseMonster bm) {
        this.Mname = bm.Mname;
        this.image = bm.image;
        this.rarity = bm.rarity;
        this.regionLocation = bm.regionLocation;
        this.abilities = bm.abilities;
        this.currentHP = bm.currentHP;
        this.maxHP = bm.maxHP;
        this.attackStat = bm.attackStat;
        this.defenseStat = bm.defenseStat;
        this.agilityStat = bm.agilityStat;
        this.level = bm.level;
        this.expReward = bm.expReward;
	}

    public Rarity GetRarity() {
     return storedRarity;
	}
    public int GetCurrentHP() {
     return currentHP;
	}
    public int GetMaxHP() {
     return maxHP;
	}
    public int GetAttackStat() {
     return attackStat;
	}
    public int GetDefenseStat() {
     return defenseStat;
	}
    public int GetAgilityStat() {
     return agilityStat;
	}
    public int GetLevel() {
     return level;
	}
    public int GetExp() {
     return expReward;
	}
    public string GetName() {
     return Mname;
	}
    public Sprite GetImage() {
     return image;
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
