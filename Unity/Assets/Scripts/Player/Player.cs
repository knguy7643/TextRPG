using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public string playerName;
    public CharacterClass characterClass;
    public int level;
    private int mana;

    //These field stores player stats.
    private int maxHP;
    private int currentHP;
    private int attackStat;
    private int defenseStat;
    private int agilityStat;
    private int totalExp;

    private List<Ability> abilities;

    public Sprite image;

    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        mana = 0;
        abilities = new List<Ability>(4);
        abilities.Add(new Ability("Basic Attack", 0, 0.0f));
        if (characterClass == CharacterClass.Braver) {
            abilities.Add(new Ability("Gale Punch", 0, 0.0f));
            abilities.Add(new Ability("Phoenix Fist", 0, 0.0f));
            abilities.Add(new Ability("Nemesis Jet Striker", 0, 1f));
		}
        if (characterClass == CharacterClass.Knight) {
            abilities.Add(new Ability("Light Phalanx", 0, 0.0f));
            abilities.Add(new Ability("Halberd Ray", 0, 0.0f));
            abilities.Add(new Ability("Seraphic Wing Dive Strike", 0, 1f));
		}
        if (characterClass == CharacterClass.Assassin) {
            abilities.Add(new Ability("Phantom Dive", 0, 0.0f));
            abilities.Add(new Ability("Backstab", 0, 0.0f));
            abilities.Add(new Ability("Phantom Blade Void Fang Slash", 0, 1f));
		}
        if (characterClass == CharacterClass.Force) {
            mana = 1;
            abilities.Add(new Ability("Ice Bolt", 0, 0));
            abilities.Add(new Ability("World's End", 0, 0));
            abilities.Add(new Ability("Meteor Prominence Breaker", 0, 1f));
		}
        if (characterClass == CharacterClass.Bladedancer) {
            abilities.Add(new Ability("Sword Bit", 0, 0.0f));
            abilities.Add(new Ability("last Breath", 0, 0.0f));
            abilities.Add(new Ability("Ikaros Force Zero 00-Sword", 0, 1f));
		}
    }

    public string GetAbilityName(int num) {
        return abilities[num].GetName();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetMana() {
        if (characterClass == CharacterClass.Force) {
            mana = 1;
        }
        else {
            mana = 0;  
		}
	}

    public int GetLevel() {
        return level;
	}

    public int GetMana() {
        return mana;
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

}

public enum CharacterClass 
{
    Braver,
    Knight,
    Assassin,
    Force,
    Bladedancer,
}
