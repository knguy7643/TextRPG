using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float walkingSpeed;

    private bool isMoving;

    private Vector2 input;

    private Animator animator;

    public LayerMask solidObjectsLayer;
    public LayerMask grassLayer;

    private void Awake() {
        animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        if (!isMoving) {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if(input.x != 0) {
                input.y = 0;     
			}

            if (input != Vector2.zero) {

                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                var targetPosition = transform.position;
                targetPosition.x += input.x;
                targetPosition.y += input.y;

                if (IsPassable(targetPosition)) {
                    StartCoroutine(Move(targetPosition));
                }
			}
		}
        
        animator.SetBool("isMoving", isMoving);

    }

    private bool IsPassable(Vector3 targetPosition) {
        if (Physics2D.OverlapCircle(targetPosition, 0.2f, solidObjectsLayer) != null) {
            return false;  
		}
        else {
            return true;  
		}
	}

    public IEnumerator Move(Vector3 targetPosition) {

        isMoving = true;

        while ((targetPosition - transform.position).sqrMagnitude > Mathf.Epsilon) {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, walkingSpeed * Time.deltaTime);
            yield return null;
		}
        transform.position = targetPosition;

        isMoving = false;

        CheckForEncounter();
	}

    private void CheckForEncounter() {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, grassLayer) != null) {
            if (Random.Range(1, 101) <= 50) {
                Debug.Log("You have encountered a monster!!!");
			}
        }
	}
}
