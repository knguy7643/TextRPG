using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] Text manaText;
    [SerializeField] Text levelText;
    [SerializeField] Text playerHP;
    [SerializeField] HPBar hpBar;

    Player _player;

    public void SetData(Player player) {

        _player = player;    

        manaText.text = "Mana: " + _player.Mana;
        levelText.text = "Lvl: " + _player.Level;
        playerHP.text = _player.CurrentHP + " / " + _player.MaxHP;
        hpBar.SetHP((float)_player.CurrentHP/_player.MaxHP);
	}

    public IEnumerator UpdateHP() {
        
        playerHP.text = _player.CurrentHP + " / " + _player.MaxHP;

        yield return hpBar.SetHPSmoothly((float)_player.CurrentHP / _player.MaxHP);
    }

    public void UpdateMana() {
        manaText.text = "Mana: " + _player.Mana;
    }
}
