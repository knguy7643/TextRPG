using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Monster/Create New Monster")]
public class BaseMonster : ScriptableObject
{
    [SerializeField] string baseMonsterName;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite baseMonsterSprite;

    [SerializeField] Rarity monsterRarity;

    //Stats
    [SerializeField] int attackStat;
    [SerializeField] int defenseStat;
    [SerializeField] int agilityStat;
    [SerializeField] int maxHP;

    [SerializeField] List<LearnableMove> learnableMoves;

    public string Name {
        get {return baseMonsterName;}
	}

    public string Description {
        get {return description;}
	}

    public Sprite BaseMonsterSprite {
        get {return baseMonsterSprite;}
	}

    public int AttackStat {
        get {return attackStat;}
	}

    public int DefenseStat {
        get {return defenseStat;}
	}

    public int AgilityStat {
        get {return agilityStat;}
	}

    public int MaxHP {
        get {return maxHP;}
	}

    public Rarity Rarity {
        get {return monsterRarity;}
	}

    public List<LearnableMove> LearnableMoves {
        get {return learnableMoves;}
	}
}

[System.Serializable]
public class LearnableMove {
    [SerializeField] BaseMove moveBase;
    [SerializeField] int level;

    public BaseMove Base {
        get {return moveBase;}
	}

    public int LevelLearned {
        get {return level;}
	}
}

public enum Rarity {
    
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
    
}