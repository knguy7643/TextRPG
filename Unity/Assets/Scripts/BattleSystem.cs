using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    BattleState state; 
    int currentAction;
    int currentMove;

    [SerializeField] BattleUnit playerUnit;
    [SerializeField] PlayerHUD playerHUD;
    [SerializeField] MonsterUnit monsterUnit;
    [SerializeField] MonsterHUD monsterHUD;
    [SerializeField] BattleDialogBox dialogBox;

    private void Start() {
        StartCoroutine(SetUpBattle());
	}

    public IEnumerator SetUpBattle() {
        playerUnit.SetUp();
        playerHUD.SetData(playerUnit.player);
        monsterUnit.SetUp();
        monsterHUD.SetData(monsterUnit.Monster);

        dialogBox.SetMoveNames(playerUnit.player.Moves);

        yield return dialogBox.TypeDialog($"You have encountered a {monsterUnit.Monster.Base.Name}.");
        yield return new WaitForSeconds(1f);

        PlayerAction();
	}

    public void PlayerAction() {
        state = BattleState.PlayerAction;

        dialogBox.EnableMoveSelector(false);

        StartCoroutine(dialogBox.TypeDialog("Choose an action."));

        dialogBox.EnableActionSelector(true);
    }

    public void PlayerMove() {
        state = BattleState.PlayerMove;

        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(false);
        dialogBox.EnableMoveSelector(true);
    }

    public IEnumerator PerformPlayerMove() {

        state = BattleState.Occupied;

        var move = playerUnit.player.Moves[currentMove];

        yield return dialogBox.TypeDialog($"Player has used {move._base.Name}.");

        yield return new WaitForSeconds(1f);

        bool isFainted = monsterUnit.Monster.TakeDamage(move, playerUnit.player);

        playerUnit.player.LoseMana(move.manaCost);

        yield return monsterHUD.UpdateHP();

        playerHUD.UpdateMana();

        if (isFainted) {
            yield return dialogBox.TypeDialog($"{monsterUnit.Monster.Base.Name} has been slained.");
        }
        else {
            StartCoroutine(PerformMonsterMove());
        }
    }

    public IEnumerator PerformMonsterMove() {
        state = BattleState.EnemyMove;

        var move = monsterUnit.Monster.MonsterMove();

        yield return dialogBox.TypeDialog($"{monsterUnit.Monster.Base.Name} used {move._base.Name}.");

        yield return new WaitForSeconds(1f);

        bool isFainted = playerUnit.player.TakeDamage(move, monsterUnit.Monster);

        yield return playerHUD.UpdateHP();

        if (isFainted) {
            yield return dialogBox.TypeDialog("You have yet to cultivate your full abilities.");
        }
        else {
            PlayerAction();
        }
    }

    void Update() {
        if (state == BattleState.PlayerAction) {
            HandleActionSelection();
        }
        else if (state == BattleState.PlayerMove) {
            HandleMoveSelection();
        }
    }

    public void HandleActionSelection() {
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            if (currentAction < 2) {
                currentAction = currentAction + 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if (currentAction > 0) {
                currentAction = currentAction - 1;
            }
        }
        
        dialogBox.UpdateActionSelection(currentAction);

        if (Input.GetKeyDown(KeyCode.Z)) {
            if (currentAction == 0) {
                //Fight
                PlayerMove();
            }
            else if (currentAction == 1) {
                //Focus
                StartCoroutine(PlayerFocus());
            }
            else if (currentAction == 2) {
                //Run

            } 
        }
    }

    public IEnumerator PlayerFocus() {
        yield return dialogBox.TypeDialog("You have focused your mind and gained 2 mana.");

        yield return new WaitForSeconds(1f);

        StartCoroutine(PerformMonsterMove());

        playerUnit.player.GainMana(2);

        playerHUD.UpdateMana();

    }

    public void HandleMoveSelection() {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (currentMove < playerUnit.player.Moves.Count - 1) {
                currentMove = currentMove + 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (currentMove > 0) {
                currentMove = currentMove - 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            if (currentMove < playerUnit.player.Moves.Count - 2) {
                currentMove = currentMove + 2;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if (currentMove > 1) {
                currentMove = currentMove - 2;
            }
        }
        
        dialogBox.UpdateMoveSelection(currentMove, playerUnit.player.Moves[currentMove]);

        if (Input.GetKeyDown(KeyCode.Z)) {
            dialogBox.EnableDialogText(true);
            dialogBox.EnableMoveSelector(false);
            if (EnoughManaToCast(playerUnit.player.Moves[currentMove])) {
                StartCoroutine(PerformPlayerMove());
            }
            else {
                StartCoroutine(NotEnoughMana());
            }
            
        }

        if (Input.GetKeyDown(KeyCode.X)) {
            PlayerAction();
        }

    }

    public IEnumerator NotEnoughMana() {
        yield return dialogBox.TypeDialog("You do not have enough mana to cast this ability.");
        
        yield return new WaitForSeconds(1f);

        dialogBox.EnableMoveSelector(true);
        dialogBox.EnableDialogText(false);
    }
    
    public bool EnoughManaToCast(Move move) {
        if (playerUnit.player.Mana >= move.manaCost) {
            return true;
        }
        else {
            return false;
        }
    }

}

public enum BattleState {
    Start,
    PlayerAction,
    PlayerMove,
    EnemyMove,
    Occupied
}