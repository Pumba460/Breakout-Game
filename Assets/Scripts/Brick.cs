using UnityEngine;
//////////////////////////////////////////////
//Assignment/Lab/Project: Breakout Game
//Name: Samuel Benson
//Section: SGD.213.0071
//Instructor: Aurore Locklear
//Date: 04/02/2026
/////////////////////////////////////////////
public class Brick : MonoBehaviour
{   //Connects the brick particles to the brick, they will activate when the brick is destroyed.
    public GameObject brickParticle;
    //Checks fot the ball to colide with the bricks so they will be destroyed on impact and have the ball bounce off.
    void OnCollisionEnter(Collision other)
    {
        Instantiate(brickParticle, transform.position, Quaternion.identity);
        GameManager.instance.DestroyBrick();
        Destroy(gameObject);
    }
}