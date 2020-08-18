using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player/Create New Player Class")]
public class BasePlayer : ScriptableObject
{
    [SerializeField] CharacterClass playerClass;
    
    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite battleSprite;

    [SerializeField] int attackStat;
    [SerializeField] int defenseStat;
    [SerializeField] int agilityStat;
    [SerializeField] int maxHP;
    [SerializeField] int startMana;

    [SerializeField] List<LearnablePlayerMove> learnablePlayerMoves;

    public CharacterClass CharacterClass {
        get {return playerClass;}
    }

    public string Description {
        get {return description;}
	}

    public Sprite Sprite {
        get {return battleSprite;}
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

    public int StartMana {
        get {return startMana;}
	}

    public List<LearnablePlayerMove> LearnablePlayerMoves {
        get {return learnablePlayerMoves;}
	}
}

[System.Serializable]
public class LearnablePlayerMove {
    [SerializeField] BaseMove moveBase;
    [SerializeField] int level;

    public BaseMove Base {
        get {return moveBase;}
	}

    public int LevelLearned {
        get {return level;}
	}
}

public enum CharacterClass {
    Force,
    Assassin,
    Braver,
    Knight,
    Bladedancer,
}
