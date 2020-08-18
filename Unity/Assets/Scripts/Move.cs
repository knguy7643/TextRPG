using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move 
{
    public BaseMove _base {get; set;}

    public int manaCost {get; set;}
    
    public Move(BaseMove bMove) {
        _base = bMove;
        manaCost = _base.ManaCost;
	}
}
