using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] BasePlayer Base;
    [SerializeField] int Level;

    public Player player {get; set;}

    public void SetUp() {
        player = new Player(Base, Level);
	}
}
