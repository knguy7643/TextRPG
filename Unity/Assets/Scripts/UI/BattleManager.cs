using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public BattleMenu currentMenu;

    public GameObject playerCamera;
    public GameObject battleCamera;
    
    [Header("Selection")]
    public GameObject selectionMenu;
    public Text fight;
    private string fightT;
    public Text focus;
    private string focusT;
    public Text run;
    private string runT;
    public Text items;
    private string itemsT;

    [Header("Abilities")]
    public GameObject movesMenu;
    public GameObject moveDetails;
    public Text description;
    public Text power;
    public Text move1;
    private string move1T;
    public Text move2;
    private string move2T;
    public Text move3;
    private string move3T;
    public Text move4;
    private string move4T;

    [Header("Info")]
    public GameObject infoMenu;
    public Text infoText;

    [Header("Misc")]
    public int currentSelection;

    [Header("Player Info")]
    public GameObject player;
    public GameObject playerInfoPanel;
    public Text playerLvlInfo;
    public Text playerManaInfo;
    public Text playerHPInfo;

    [Header("Monster Info")]
    public GameObject monsterInfoPanel;
    public Text monsterName;
    public Text monsterRarityInfo;
    public Text monsterHPInfo;
    public Text monsterLvlInfo;
    public BaseMonster blankMonster;
    public GameObject spriteLocation;

    // Start is called before the first frame update
    void Start()
    {
        fightT = fight.text;
        focusT = focus.text;
        itemsT = items.text;
        runT = run.text;

        playerLvlInfo.text = playerLvlInfo.text + " " + player.GetComponent<Player>().GetLevel();
        player.GetComponent<Player>().ResetMana();
        playerManaInfo.text = playerManaInfo.text + " " + player.GetComponent<Player>().GetMana();
        playerHPInfo.text = player.GetComponent<Player>().GetCurrentHP() + "/" + player.GetComponent<Player>().GetMaxHP();

    }
     
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow)) {
              if (currentSelection < 4) {
                    currentSelection++;     
			  }
              if (currentSelection >= 4) {
                    currentSelection = 4;     
			  }
		}   
        if(Input.GetKeyDown(KeyCode.UpArrow)) {
              if (currentSelection > 0) {
                    currentSelection--;     
			  }
              if(currentSelection == 0) {
                    currentSelection = 1;  
		      }
 		}
        if (Input.GetKeyDown(KeyCode.Z)) {
            switch(currentMenu) {
            case BattleMenu.Fight:
                switch(currentSelection) {
                    case 1:
                        selectionMenu.gameObject.SetActive(false);
                        movesMenu.gameObject.SetActive(false);
                        moveDetails.gameObject.SetActive(false);
                        infoMenu.gameObject.SetActive(true);
                        infoText.text = "Player used a basic attack.";
                        currentMenu = BattleMenu.Info;
                        break;
                    case 2:
                        selectionMenu.gameObject.SetActive(false);
                        movesMenu.gameObject.SetActive(false);
                        moveDetails.gameObject.SetActive(false);
                        infoMenu.gameObject.SetActive(true);
                        infoText.text = "Player used " + player.GetComponent<Player>().GetAbilityName(1) + ".";
                        currentMenu = BattleMenu.Info;
                        break;
                    case 3:
                        selectionMenu.gameObject.SetActive(false);
                        movesMenu.gameObject.SetActive(false);
                        moveDetails.gameObject.SetActive(false);
                        infoMenu.gameObject.SetActive(true);
                        infoText.text = "Player used " + player.GetComponent<Player>().GetAbilityName(2) + ".";
                        currentMenu = BattleMenu.Info;
                        break;
                    case 4:
                        selectionMenu.gameObject.SetActive(false);
                        movesMenu.gameObject.SetActive(false);
                        moveDetails.gameObject.SetActive(false);
                        infoMenu.gameObject.SetActive(true);
                        infoText.text = "Hissatsu Funtion. Player used " + player.GetComponent<Player>().GetAbilityName(3) + ".";
                        currentMenu = BattleMenu.Info;
                        break;
				}
                break;
            case BattleMenu.Selection:
                switch(currentSelection) {
                    case 1:
                        selectionMenu.gameObject.SetActive(false);
                        movesMenu.gameObject.SetActive(true);
                        moveDetails.gameObject.SetActive(true);
                        infoMenu.gameObject.SetActive(false);
                        currentMenu = BattleMenu.Fight;
                        break;
                    case 2:
                        selectionMenu.gameObject.SetActive(false);
                        movesMenu.gameObject.SetActive(false);
                        moveDetails.gameObject.SetActive(false);
                        infoMenu.gameObject.SetActive(true);
                        infoText.text = "Player focuses and gained an additional mana.";
                        currentMenu = BattleMenu.Info;
                        break;
                    case 3:
                        selectionMenu.gameObject.SetActive(false);
                        movesMenu.gameObject.SetActive(false);
                        moveDetails.gameObject.SetActive(false);
                        infoMenu.gameObject.SetActive(true);
                        infoText.text = "No items available.";
                        currentMenu = BattleMenu.Info;
                        break;
                    case 4:
                        //RUN
                        selectionMenu.gameObject.SetActive(false);
                        movesMenu.gameObject.SetActive(false);
                        moveDetails.gameObject.SetActive(false);
                        infoMenu.gameObject.SetActive(true);
                        infoText.text = "You have successfully escaped.";
                        currentMenu = BattleMenu.Info;

                        break;        
				}
                break;
            case BattleMenu.Info:
                switch(currentSelection) {
                    case 1:
                        selectionMenu.gameObject.SetActive(true);
                        movesMenu.gameObject.SetActive(false);
                        moveDetails.gameObject.SetActive(false);
                        infoMenu.gameObject.SetActive(false);
                        break;
                    case 2:
                        selectionMenu.gameObject.SetActive(true);
                        movesMenu.gameObject.SetActive(false);
                        moveDetails.gameObject.SetActive(false);
                        infoMenu.gameObject.SetActive(false);
                        currentMenu = BattleMenu.Selection;
                        break;
                    case 3:
                        selectionMenu.gameObject.SetActive(true);
                        movesMenu.gameObject.SetActive(false);
                        moveDetails.gameObject.SetActive(false);
                        infoMenu.gameObject.SetActive(false);
                        currentMenu = BattleMenu.Selection;
                        break;
                    case 4:
                        playerCamera.SetActive(true);
                        battleCamera.SetActive(false);
                        player.GetComponent<PlayerMovement>().isAbleToMove = true;
                        break;
				}
                break;
			}
		}

        switch(currentMenu) {
            case BattleMenu.Fight:
                switch(currentSelection) {
                    case 1:
                        move1.text = "> Basic Attack";
                        move2.text = "2-Mana Attack";
                        move3.text = "3-Mana Attack";
                        move4.text = "Attack Function";
                        break;
                    case 2:
                        move1.text = "Basic Attack";
                        move2.text = "> 2-Mana Attack";
                        move3.text = "3-Mana Attack";
                        move4.text = "Attack Function";
                        break;
                    case 3:
                        move1.text = "Basic Attack";
                        move2.text = "2-Mana Attack";
                        move3.text = "> 3-Mana Attack";
                        move4.text = "Attack Function";
                        break;
                    case 4:
                        move1.text ="Basic Attack";
                        move2.text = "2-Mana Attack";
                        move3.text = "3-Mana Attack";
                        move4.text = "> Attack Function";
                        break;
		        }
                break;
            case BattleMenu.Selection:
                switch(currentSelection) {
                    case 1:
                        fight.text = "> FIGHT";
                        focus.text = focusT;
                        items.text = itemsT;
                        run.text = runT;
                        break;
                    case 2:
                        fight.text = fightT;
                        focus.text = "> FOCUS";
                        items.text = itemsT;
                        run.text = runT;
                        break;
                    case 3:
                        fight.text = fightT;
                        focus.text = focusT;
                        items.text = "> ITEMS";
                        run.text = runT;
                        break;
                    case 4:
                        fight.text = fightT;
                        focus.text = focusT;
                        items.text = itemsT;
                        run.text = "> RUN";
                        break;
		        }
                break;
		}
        
        
    }

    public void Battle(Player player, BaseMonster baseMonster) {
        if (player.GetComponent<Player>().GetAgilityStat() >= baseMonster.GetComponent<BaseMonster>().GetAgilityStat()) {
            
		}
        else {
            
		}
	}

    public void ChangeMenu(BattleMenu m, BaseMonster monster) {
        currentMenu = m;
        currentSelection = 1;
        switch(m) {
            case BattleMenu.Selection:
                selectionMenu.gameObject.SetActive(true);
                movesMenu.gameObject.SetActive(false);
                moveDetails.gameObject.SetActive(false);
                infoMenu.gameObject.SetActive(false);

                break;
            case BattleMenu.Fight:
                selectionMenu.gameObject.SetActive(false);
                movesMenu.gameObject.SetActive(true);
                moveDetails.gameObject.SetActive(true);
                infoMenu.gameObject.SetActive(false);

                break;
            case BattleMenu.Info:
                selectionMenu.gameObject.SetActive(false);
                movesMenu.gameObject.SetActive(false);
                moveDetails.gameObject.SetActive(false);
                infoMenu.gameObject.SetActive(true);
                
                break;
		}
        
        blankMonster = monster;

        monsterName.text = blankMonster.GetComponent<BaseMonster>().GetName();
        monsterRarityInfo.text = blankMonster.GetComponent<BaseMonster>().GetRarity().ToString();
        monsterHPInfo.text = blankMonster.GetComponent<BaseMonster>().GetCurrentHP() + "/" + blankMonster.GetComponent<BaseMonster>().GetMaxHP();
        monsterLvlInfo.text = "Lvl: " + blankMonster.GetComponent<BaseMonster>().GetLevel();
        spriteLocation.GetComponent<SpriteRenderer>().sprite = blankMonster.GetComponent<BaseMonster>().GetImage();
	}
}

public enum BattleMenu {
    Fight,
    Selection,
    Info,
}