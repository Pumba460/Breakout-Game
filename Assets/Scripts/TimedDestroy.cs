using UnityEngine;
//////////////////////////////////////////////
//Assignment/Lab/Project: Breakout Game
//Name: Samuel Benson
//Section: SGD.213.0071
//Instructor: Aurore Locklear
//Date: 04/02/2026
/////////////////////////////////////////////
/// 
/// This script just destroys the brick particles after they are used.
public class TimedDestroy : MonoBehaviour
{
    public float destroyTime = 1f;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}