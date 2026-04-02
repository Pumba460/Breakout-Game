using UnityEngine;
//////////////////////////////////////////////
//Assignment/Lab/Project: Breakout Game
//Name: XXXXXX XXXXXX
//Section: SGD.213.0071
//Instructor: Aurore Locklear
//Date: 04/02/2026
/////////////////////////////////////////////
public class DeadZone : MonoBehaviour {
GameManager GM;
void Start () {
GM =
GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
}
void OnTriggerEnter (Collider col) {
GM.LoseLife();
}
}