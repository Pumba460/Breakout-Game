using UnityEngine;
//////////////////////////////////////////////
//Assignment/Lab/Project: Breakout Game
//Name: Samuel Benson
//Section: SGD.213.0071
//Instructor: Aurore Locklear
//Date: 04/02/2026
/////////////////////////////////////////////
/// 
/// All this script does is wait for the ball to trigger its box so the player loses a life.
public class DeadZone : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        GameManager.instance.LoseLife();
    }
}