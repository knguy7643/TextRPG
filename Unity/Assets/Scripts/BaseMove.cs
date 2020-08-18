using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Monster/Create New Move")]
public class BaseMove : ScriptableObject
{
    [SerializeField] string moveName;

    [TextArea]
    [SerializeField] string moveDescription;

    [SerializeField] int power;
    [SerializeField] int manaCost;

    public string Name {
        get {return moveName;}
	}

    public string Description {
        get {return moveDescription;}
	}

    public int Power {
        get {return power;}
	}

    public int ManaCost {
        get {return manaCost;}
	}
}
