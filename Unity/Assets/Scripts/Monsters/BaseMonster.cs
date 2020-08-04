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
    public float baseHP;
    public float maxHP;
    public float baseAttack;
    public float maxAttack;
    public float baseDefense;
    public float maxDefense;
    public float agility;
    public float level;

    // Start is called before the first frame update
    void Start()
    {
        //Come back to it.
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
