using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject healthBar;

    public void SetHP(float hpFactor) {
        healthBar.transform.localScale = new Vector3(hpFactor, 1f);
	}

    public IEnumerator SetHPSmoothly(float newHP) {
        float curHP = healthBar.transform.localScale.x;

        float changeAmount = curHP - newHP;

        while (curHP - newHP > Mathf.Epsilon) {
            curHP = curHP - changeAmount * Time.deltaTime;
            healthBar.transform.localScale = new Vector3 (curHP, 1f);
            yield return null;
        }

        healthBar.transform.localScale = new Vector3 (newHP, 1f);
    }
}
