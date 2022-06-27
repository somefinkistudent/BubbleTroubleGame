﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTroubleGame
{
    internal class Player
    {
        //images depending on side of facing?
        //should the ammo be infinite? -Yes.
        public int position { get; set; }

        //idea: coefficient for moving, -1(left) or 1(right)
        public int directionCoef { get; set; } = 1;

        public Harpoon harpoon { get; set; }

        public int lives { get; set; } = 10;

        public Image playerImg { get; set; }

        //first or second player
        public int playerId { get; set; }

        public bool isDead { get; set; }

        public Player(int position, int playerId)
        {
            this.position = position;
            this.playerId = playerId;
            //this.harpoon = new Harpoon();
            this.isDead = false;
            //different images for different players
        }

        public void Move(int sceneWidth)
        {
            //stop at end of screen or continue from other side?
            if (directionCoef == 1)
            {
                position += 5; //might be too slow, might be too fast
                if (position > sceneWidth)
                    position = sceneWidth;
            }
            else
            {
                position -= 5;
                if (position < 0)
                    position = 0;
            }
        }

        public void ChangeDirection()
        {
            directionCoef *= -1;
            if (directionCoef == 1)
            {
                //right images
            }
            else
            {
                //left images
            }
        }

        public void Draw(Graphics g)
        {
            //different states of player? e.g. dead, walking, still
        }

        public bool isHit(List<Ball> balls)
        {
            foreach (Ball b in balls)
            {
                float ballX = b.radius + b.Center.X;
                float ballY = b.radius + b.Center.Y;
                float posX = position + playerImg.Width / 2;
                //float posY = some Y value + playerImg.Height / 2; ????
                float euclid = Math.Sqrt(Math.Pow(posX - ballX, 2) + Math.Pow(posY - ballY, 2));
                //20 is hitbox
                if (euclid <= Math.Pow(b.radius + 20, 2))
                    return true;
            }
            return false;
        }

    }
}
