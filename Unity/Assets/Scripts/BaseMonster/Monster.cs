using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
    public BaseMonster Base {get; set;}
    public int level {get; set;}
    public int Mana {get; set;}
    
    public int CurrentHP {get; set;}

    public List<Move> Moves {get; set;}

    public Monster(BaseMonster bMonster, int pLevel) {
        Base = bMonster;
        level = pLevel;
        CurrentHP = MaxHP;
        Mana = 0;

        Moves = new List<Move>();

        foreach (var more in Base.LearnableMoves) {
            if (more.LevelLearned <= level) {
                Moves.Add(new Move(more.Base));     
			}
            
            if (Moves.Count >= 4) {
                break;     
			}
		}
	}

    public int AttackStat {
        get {return Mathf.FloorToInt((Base.AttackStat * level) / 100f) + 5;}
	}

    public int DefenseStat {
        get {return Mathf.FloorToInt((Base.DefenseStat * level) / 100f) + 5;}
	}

    public int AgilityStat {
        get {return Mathf.FloorToInt((Base.AgilityStat * level) / 100f) + 5;}
	}

    public int MaxHP {
        get {return Mathf.FloorToInt((Base.MaxHP * level) / 100f) + 10;}
	}

    public bool TakeDamage(Move move, Player attacker) {

        float critialHit = 1f;

        if (Random.value * 100f <= 6.25f) {
            critialHit = 2f;
        }

        float modifiers = Random.Range(0.85f, 1f) * critialHit;
        float a = (2 * attacker.Level + 10) / 250f;
        float d = a * move._base.Power * ((float) attacker.AttackStat / DefenseStat) + 2;

        int damage = Mathf.FloorToInt(d * modifiers);

        attacker.GainMana(1);

        CurrentHP = CurrentHP - damage;

        if (CurrentHP <= 0) {
            CurrentHP = 0;
            return true;
        }
        else {
            return false;
        }
    }

    public void GainMana(int manaGained) {
        Mana = Mana + manaGained;
    }
     
    public Move MonsterMove() {

        int random = Random.Range(0, 3);

        if (Mana == 4) {
            return Moves[random];
        }
        else if (Mana == 3) {
            random = Random.Range(0, 2);
            return Moves[random];
        }
        else if (Mana == 2) {
            random = Random.Range(0, 1);
            return Moves[random];
        }
        else {
            return Moves[0];
        }
    }
}

public class MonsterDamageDetails {
    public bool Fainted {get; set;}

    public float critical {get; set;}
}