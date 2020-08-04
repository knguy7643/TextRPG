using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonster : MonoBehaviour
{
    public string name;
    public Sprite image;
    public RegionList regionLocation;
    public Rarity rarity;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}
