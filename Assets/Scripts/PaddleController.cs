using UnityEngine;
//////////////////////////////////////////////
//Assignment/Lab/Project: Breakout Game
//Name: Samuel Benson
//Section: SGD.213.0071
//Instructor: Aurore Locklear
//Date: 04/02/2026
/////////////////////////////////////////////

public class PaddleController : MonoBehaviour {
public float paddleSpeed = 1f;  //Sets paddle speed
private Vector3 playerPos = new Vector3 (0, -9.5f, 0);  //Vector variable to track the player position
//Update method will constantly update the paddles location and also move it when the left and right arrow keys are presed.
void Update ()
{
float xPos = transform.position.x + (Input.GetAxis("Horizontal") *
paddleSpeed);
playerPos = new Vector3 (Mathf.Clamp (xPos, -8f, 8f), -9.5f, 0f);
transform.position = playerPos;
}
}
