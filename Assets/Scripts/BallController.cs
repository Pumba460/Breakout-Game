using UnityEngine;
//////////////////////////////////////////////
//Assignment/Lab/Project: Breakout Game
//Name: Samuel Benson
//Section: SGD.213.0071
//Instructor: Aurore Locklear
//Date: 04/02/2026
/////////////////////////////////////////////
public class BallController : MonoBehaviour {
public float initialVelocity = 600f;    //Sets up the volocity of the ball
private Rigidbody rb;   //Variable for ridgid body compenet
private bool ballInPlay;    //Bool to find if the balls is in motion
//On wake this gets the ridgid body compenet
void Awake ()
{
rb = GetComponent<Rigidbody>();
}
//Update method that checks on a loop for the ball to be fired. Once ball has been fired it un parents the ball from th paddle and sets to not Kinmatic. It will then be shot out and set into its play state.
void Update ()
{
if (Input.GetButtonDown("Fire1") && ballInPlay == false) {
transform.parent = null; //unparent the ball from paddle
ballInPlay = true;
rb.isKinematic = false;
rb.AddForce(new Vector3(initialVelocity,initialVelocity, 0));
}
}
}
