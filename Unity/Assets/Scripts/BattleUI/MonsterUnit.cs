using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterUnit : MonoBehaviour
{
    [SerializeField] BaseMonster Base;
    [SerializeField] int Level;

    public Monster Monster {get; set;}

    public void SetUp() {
        Monster = new Monster (Base, Level);
        GetComponent<Image>().sprite = Monster.Base.BaseMonsterSprite;
	}
}
