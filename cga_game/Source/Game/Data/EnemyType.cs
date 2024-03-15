﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Strategy.Grid;

namespace Strategy
{
    class EnemyType
    {
        public string name;
        public int health;
        public int damageDealt;
        public float speed;
    }

    class EnemyGameData
    {
        public static EnemyType alien = new EnemyType() { name = EnemyTypeString.ALIEN, health = 100, damageDealt = 20, speed = 20 };
        public static EnemyType bat = new EnemyType() { name = EnemyTypeString.BAT, health = 200, damageDealt = 40, speed = 20 };
        public static EnemyType robot = new EnemyType() { name = EnemyTypeString.ROBOT, health = 70, damageDealt = 50, speed = 20 };
        public static EnemyType bomb = new EnemyType() { name = EnemyTypeString.BOMB, health = 60, damageDealt = 100, speed = 20 };
    }

    class EnemyTypeList
    {
        public static List<EnemyType> enemyTypeList = new List<EnemyType>() 
        {
            EnemyGameData.alien,
            EnemyGameData.bat,
            EnemyGameData.robot,
            EnemyGameData.bomb
        };
    }

    class EnemyTypeString
    {
        public static string ALIEN = "alien";
        public static string BAT = "bat";
        public static string ROBOT = "robot";
        public static string BOMB = "bomb";
    }
}
