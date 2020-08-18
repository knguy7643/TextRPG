using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogBox : MonoBehaviour
{
    [SerializeField] Text dialogText;
    [SerializeField] int lettersPerSecond;

    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject moveSelector;
    [SerializeField] GameObject moveDetails;

    [SerializeField] List<Text> actionTexts;
    [SerializeField] List<Text> moveTexts;

    [SerializeField] Text moveManaCost;
    [SerializeField] Text movePowerText;

    [SerializeField] Color highlightedColor;

    public void SetDialog(string dialog) {
        dialogText.text = dialog;
	}

    public IEnumerator TypeDialog(string dialog) {
        dialogText.text = "";

        foreach (var letter in dialog.ToCharArray()) {
            dialogText.text += letter;  
            yield return new WaitForSeconds(1f/lettersPerSecond);
		}
	}

    public void EnableDialogText(bool enabled) {
        dialogText.enabled = enabled;
    }

    public void EnableActionSelector(bool enabled) {
        actionSelector.SetActive(enabled);
    }

    public void EnableMoveSelector(bool enabled) {
        moveDetails.SetActive(enabled);
        moveSelector.SetActive(enabled);
    }

    public void UpdateActionSelection(int selectedAction) {
        for (int x = 0; x < actionTexts.Count; x++) {
            if (x == selectedAction) {
                actionTexts[x].color = highlightedColor;
            }
            else {
                actionTexts[x].color = Color.black;
            }
        }
    }

    public void UpdateMoveSelection(int selectedMove, Move move) {
        for (int x = 0; x < moveTexts.Count; x++) {
            if (x == selectedMove) {
                moveTexts[x].color = highlightedColor;
            }
            else {
                moveTexts[x].color = Color.black;
            }
        }

        moveManaCost.text = "Mana: " + move.manaCost;
        movePowerText.text = "Power: " + move._base.Power;
    }

    public void SetMoveNames(List<Move> moves) {
        for (int i = 0; i < moveTexts.Count; i++) {
            if (i < moves.Count) {
                moveTexts[i].text = moves[i]._base.Name;
            }
            else {
                moveTexts[i].text = "-";
            }
        }
    }

    
}
