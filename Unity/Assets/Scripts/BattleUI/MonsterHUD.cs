using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHUD : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] Text rarityText;
    [SerializeField] Text monsterHP;
    [SerializeField] HPBar hpBar;

    Monster _monster;

    public void SetData(Monster monster) {

        _monster = monster;

        nameText.text = _monster.Base.Name;
        levelText.text = "Lvl: " + _monster.level;
        rarityText.text = _monster.Base.Rarity.ToString();
        monsterHP.text = _monster.CurrentHP + "/" + _monster.MaxHP;
        hpBar.SetHP((float)_monster.CurrentHP/_monster.MaxHP);
	}

    public IEnumerator UpdateHP() {
        
        monsterHP.text = _monster.CurrentHP + "/" + _monster.MaxHP;

        yield return hpBar.SetHPSmoothly((float)_monster.CurrentHP / _monster.MaxHP);
    }

}
