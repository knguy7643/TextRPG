using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    public BasePlayer Base {get; set;}
    public int Level {get; set;}

    public int CurrentHP {get; set;}

    public int Mana {get; set;}

    public List<Move> Moves {get; set;}

    public Player(BasePlayer _Base, int level) {
        Base = _Base;
        Level = level;
        Mana = Base.StartMana;
        CurrentHP = MaxHP;

         Moves = new List<Move>();

        foreach (var more in Base.LearnablePlayerMoves) {
            if (more.LevelLearned <= Level) {
                Moves.Add(new Move(more.Base));     
			}
            
            if (Moves.Count >= 4) {
                break;     
			}
		}

	}

    public int AttackStat {
        get {return Mathf.FloorToInt((Base.AttackStat * Level) / 100f) + 5;}
	}

    public int DefenseStat {
        get {return Mathf.FloorToInt((Base.DefenseStat * Level) / 100f) + 5;}
	}

    public int AgilityStat {
        get {return Mathf.FloorToInt((Base.AgilityStat * Level) / 100f) + 5;}
	}

    public int MaxHP {
        get {return Mathf.FloorToInt((Base.MaxHP * Level) / 100f) + 10;}
	}

    public bool TakeDamage(Move move, Monster attacker) {

        float critialHit = 1f;

        if (Random.value * 100f <= 6.25f) {
            critialHit = 2f;
        }

        float modifiers = Random.Range(0.85f, 1f) * critialHit;
        float a = (2 * attacker.level + 10) / 250f;
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

    public void GainMana(int numManaGained) {
        Mana = Mana + numManaGained;
    }

    public void LoseMana(int numManaLost) {
        Mana = Mana - numManaLost;
        if (Mana < 0) {
            Mana = 0;
        }
    }
}
