using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoD
{
    public class Character
    {
        public float Health {get;set;}
        public float Stamina {get;set;}

        public float Speed {get;set;}

        public Character(float health, float stamina, float speed)
        {
            this.Health = health;
            this.Stamina = stamina;
            this.Speed = speed;
        }
    }
}