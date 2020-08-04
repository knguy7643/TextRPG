using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //This field stores the direction the player sprite is facing.
    Direction directionFacing;

    //This field will store the user's WASD inputs. 
    Vector2 input;

    //This field stores if the player is currently in motion.
    bool isMoving = false;

    //This field will store the player's positon before moving.
    Vector3 startingPosition;

    //This field will store the player's ending position.
    Vector3 endingPosition;

    //This field will store time as a float value.
    float time;
    
    //These fields store the player's sprite for as they move.
    public Sprite northSprite;
    public Sprite eastSprite;
    public Sprite southSprite;
    public Sprite westSprite;

    //This field will store the speed of player movement.
    public float walkingSpeed = 3f;

    public bool isAbleToMove = true;

    void start() {
        isAbleToMove = true;
	}

    // Update is called once per frame
    void Update()
    {
        if (!isMoving && isAbleToMove) { //Checks if user is already moving.
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