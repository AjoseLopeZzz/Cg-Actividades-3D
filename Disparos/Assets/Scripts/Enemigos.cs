using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    public int health;

    public void takeDamege(int dmg)
    {
        health -= dmg;

        if (health <= 0)
        {

        }
}
