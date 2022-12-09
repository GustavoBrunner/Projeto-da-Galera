using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [System.Serializable]
    public class Player_base 
    {
        public float[] position = new float[3];
        public string name;
        public int hp;
        public int maxHp;
        public float speed;
        public int goldQtd;
        public int actualXp;
        public int level;
        public int armor;
        public int stamina;

        public Player_base (PlayerController player) //constructor, responsável por pegar um objeto player e receber seus dados. 
        {
            this.name = player.name;
            this.hp = player._hp;
            this.speed = player.targetSpeed;
            this.goldQtd = player._goldqtd;
            this.armor = player.armor;
            this.position[0] = player.transform.position.x;
            this.position[1] = player.transform.position.y;
            this.position[2] = player.transform.position.z;
            this.stamina = player.stamina;
            
        }
        

    }