﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Strategy.Grid;
using MonoGame.Extended.Entities;
using System;

namespace Strategy
{
    class Transform
    {
        public Vector2 worldPos;
        public GridPosition gridPos;
        public int scale;

        //public string tag;
        //public Action<int, int> OnCollisionEnter;
    }
}
