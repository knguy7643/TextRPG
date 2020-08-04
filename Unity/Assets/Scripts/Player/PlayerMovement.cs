using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Direction directionFacing;
    Vector2 input;
    bool isMoving = false;
    Vector3 startingPosition;
    Vector3 endingPosition;
    float time;

    public Sprite northSprite;
    public Sprite eastSprite;
    public Sprite southSprite;
    public Sprite westSprite;

    public float walkingSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        if (!isMoving) {
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));  

            if (Mathf.Abs(input.x) > Mathf.Abs(input.y)) {
                input.y = 0;     
			}
            else {
                input.x = 0;     
			}

            if (input != Vector2.zero) {
                
                if (input.x < 0) { //West
                    directionFacing = Direction.West;             
				}
                if (input.x > 0) { //East
                    directionFacing = Direction.East;
				}
                if (input.y < 0) { //South
                    directionFacing = Direction.South;
				}
                if (input.y> 0) { //North
                    directionFacing = Direction.North;
				}

                switch(directionFacing) {
                
                    case Direction.North:
                        gameObject.GetComponent<SpriteRenderer>().sprite = northSprite;
                        break;
                    case Direction.East:
                        gameObject.GetComponent<SpriteRenderer>().sprite = eastSprite;
                        break;
                    case Direction.West:
                        gameObject.GetComponent<SpriteRenderer>().sprite = westSprite;
                        break;
                    case Direction.South:
                        gameObject.GetComponent<SpriteRenderer>().sprite = southSprite;
                        break;
				}

                StartCoroutine(Move(transform));
			}


		}
    }

    public IEnumerator Move(Transform ae) {

        isMoving = true;

        startingPosition = ae.position;

        time = 0;

        endingPosition = new Vector3(startingPosition.x + System.Math.Sign(input.x), startingPosition.y + System.Math.Sign(input.y), startingPosition.z);

        while (time < 1f) {
            time += Time.deltaTime * walkingSpeed;
            
            ae.position = Vector3.Lerp(startingPosition, endingPosition, time);

            yield return null;
		}

        isMoving = false;

        yield return 0;
	}
}

enum Direction {
    North, 
    East, 
    South, 
    West
}