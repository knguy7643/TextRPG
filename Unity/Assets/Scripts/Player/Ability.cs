using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public string abilityName;
    public int manaCost;
    public float damageModifier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Ability(string name, int mana, float dmg) {
        abilityName = name;
        manaCost = mana;
        damageModifier = dmg;
	}

    public string GetName() {
        return abilityName;
	}
}
