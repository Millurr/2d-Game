using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{

    public float Health { get; set; }

    public float Stamina { get; set; }

    public float Speed { get; set; }

    public float Intelegince { get; set; }

    public float Strength { get; set; }

    public float Endurance { get; set; }

    public Character(float health, float stamina, float speed)
    {
        this.Health = health;
        this.Stamina = stamina;
        this.Speed = speed;
    }
}