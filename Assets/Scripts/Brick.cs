using UnityEngine;
//////////////////////////////////////////////
//Assignment/Lab/Project: Breakout Game
//Name: XXXXXX XXXXXX
//Section: SGD.213.0071
//Instructor: Aurore Locklear
//Date: 04/02/2026
/////////////////////////////////////////////
public class Brick: MonoBehaviour {
public GameObject brickParticle;
GameManager GM;
void Start () {
GM =
GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
}
void OnCollisionEnter (Collision other) {
Instantiate(brickParticle, transform.position, Quaternion.identity);
GM.DestroyBrick();
Destroy(gameObject);
}
}