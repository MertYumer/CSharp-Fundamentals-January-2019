﻿namespace SimpleSnake.GameObjects
{
    using Foods;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Snake
    {
        private const char snakeSymbol = '\u25CF';

        private Queue<Point> snakeParts;
        private Wall wall;
        private Food[] foods;

        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;

        public Snake(Wall wall)
        {
            this.wall = wall;
            this.snakeParts = new Queue<Point>();
            this.foods = new Food[3];
            this.foodIndex = RandomFoodNumber;
            this.GetFoods();
            this.CreateSnake();
        }

        private int RandomFoodNumber => new Random().Next(0, this.foods.Length);

        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                this.snakeParts.Enqueue(new Point(2, topY));
            }
        }

        private void GetFoods()
        {
            this.foods[0] = new FoodHash(this.wall);
            this.foods[1] = new FoodDollar(this.wall);
            this.foods[2] = new FoodAsterisk(this.wall);
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }

        private void Eat(Point direction, Point snakeHead)
        {
            int length = this.foods[foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                this.snakeParts.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                GetNextPoint(direction, snakeHead);
            }

            this.foodIndex = this.RandomFoodNumber;
            this.foods[foodIndex].SetRandomPosition(snakeParts);
        }

        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = this.snakeParts.Last();

            this.GetNextPoint(direction, currentSnakeHead);

            bool isPointOfSnake = this.snakeParts
                .Any(x => x.LeftX == this.nextLeftX && x.TopY == nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point snakeNewHead = new Point(this.nextLeftX, this.nextTopY);

            if (wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }

            this.snakeParts.Enqueue(snakeNewHead);
            snakeNewHead.Draw(snakeSymbol);

            if (this.foods[this.foodIndex].IsFoodPoint(snakeNewHead))
            {
                this.Eat(direction, currentSnakeHead);
            }

            Point snakeTail = this.snakeParts.Dequeue();
            snakeTail.Draw(' ');

            return true;
        }
    }
}
