﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SnakeGame.Classes;
using System.IO;

namespace SnakeGame
{
    public partial class SnakeUI : Form
    {
        private Snake snake = new Snake();
        private Food food = new Food();

        public SnakeUI()
        {
            InitializeComponent();

            //default settings
            new GameSettings();

            //sets game speed to increase every time speed is increased
            gameTimer.Interval = 1000 / GameSettings.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

            StartGame();


        }

        public void StartGame()
        {

            gameTimer.Start();

            //default settings
            new GameSettings();
            if (snake.SnakeBody != null)
            {
                snake.SnakeBody.Clear();
            }

            //sets starting point for head of snake
            snake = new Snake();
            snake.SnakeHead = new Food();
            snake.SnakeBody = new List<Food>();

            snake.SnakeHead.XPosition = 10;
            snake.SnakeHead.YPosition = 5;

            snake.SnakeBody.Add(snake.SnakeHead);

            scoreValue.Text = GameSettings.Score.ToString();
            GenerateFood();
        }

        //place food object on screen in random spot(need to find a way to not generate where body already is)
        private void GenerateFood()
        {
            int maxXPosition = gameWindow.Size.Width / GameSettings.Width;
            int maxYPosition = gameWindow.Size.Height / GameSettings.Height;

            Random randomPosition = new Random();
            food = new Food();

            for (int i = 0; i < snake.SnakeBody.Count; i++)//hopefully will not let it make a food piece where there is a body
            {
                do
                {
                    food.XPosition = randomPosition.Next(0, maxXPosition);
                    food.YPosition = randomPosition.Next(0, maxYPosition);
                } while (food.XPosition == snake.SnakeBody[i].XPosition && food.YPosition == snake.SnakeBody[i].YPosition);


                break;

            }



        }

        private void UpdateScreen(object sender, EventArgs e)
        {

            //checks to see if the direction click is possible

            if (Input.IsKeyPressed(Keys.Right) && GameSettings.Direction != Directions.Left)
            {
                GameSettings.Direction = Directions.Right;
            }
            else if (Input.IsKeyPressed(Keys.Left) && GameSettings.Direction != Directions.Right)
            {
                GameSettings.Direction = Directions.Left;
            }
            else if (Input.IsKeyPressed(Keys.Up) && GameSettings.Direction != Directions.Down)
            {
                GameSettings.Direction = Directions.Up;
            }
            else if (Input.IsKeyPressed(Keys.Down) && GameSettings.Direction != Directions.Up)
            {
                GameSettings.Direction = Directions.Down;
            }

            MovePlayer();

            gameWindow.Invalidate();

        }

        private void gameWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            if (!GameSettings.GameOver)
            {
                
                Brush snakeColor;
                for (int i = 0; i < snake.SnakeBody.Count; i++)
                {
                    snakeColor = Brushes.Black;

                    //sets color of snake
                    canvas.FillRectangle(snakeColor, new Rectangle(snake.SnakeBody[i].XPosition * GameSettings.Width,
                                                                   snake.SnakeBody[i].YPosition * GameSettings.Height,
                                                                   GameSettings.Width, GameSettings.Height));
                    //sets color of food
                    canvas.FillRectangle(Brushes.Red, new Rectangle(food.XPosition * GameSettings.Width, food.YPosition * GameSettings.Height, GameSettings.Width, GameSettings.Height));

                }
            }
            else
            {
                string gameOver = $"Game Over!\n\n Your Final Score is: {GameSettings.Score} \n\n Press Retry to play again or Cancel set score";

                if (MessageBox.Show(gameOver, "Play Again?", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                {
                    StartGame();
                }
                else
                {
                    ShowMyDialogBox();
                    //Application.Exit();
                }

            }
        }

        private void MovePlayer()
        {
            for (int i = snake.SnakeBody.Count - 1; i >= 0; i--)
            {
                //moves head
                if (i == 0)
                {
                    switch (GameSettings.Direction)
                    {
                        case Directions.Up:
                            snake.SnakeBody[i].YPosition--;
                            break;
                        case Directions.Down:
                            snake.SnakeBody[i].YPosition++;
                            break;
                        case Directions.Left:
                            snake.SnakeBody[i].XPosition--;
                            break;
                        case Directions.Right:
                            snake.SnakeBody[i].XPosition++;
                            break;

                    }


                    int maxXPosition = gameWindow.Size.Width / GameSettings.Width;
                    int maxYPosition = gameWindow.Size.Height / GameSettings.Height;

                    //detect collision with boarder
                    if (snake.SnakeBody[i].XPosition < 0 || snake.SnakeBody[i].YPosition < 0 || snake.SnakeBody[i].XPosition >= maxXPosition || snake.SnakeBody[i].YPosition >= maxYPosition)
                    {
                        Die();
                    }

                    //detect collision with body
                    for (int h = 1; h < snake.SnakeBody.Count; h++)
                    {
                        if (snake.SnakeBody[i].XPosition == snake.SnakeBody[h].XPosition && snake.SnakeBody[i].YPosition == snake.SnakeBody[h].YPosition)
                        {
                            Die();
                        }
                    }

                    //detect collision  with food
                    if (snake.SnakeBody[0].XPosition == food.XPosition && snake.SnakeBody[i].YPosition == food.YPosition)
                    {
                        Eat();
                    }
                }
                else
                {
                    //moves body
                    snake.SnakeBody[i].XPosition = snake.SnakeBody[i - 1].XPosition;
                    snake.SnakeBody[i].YPosition = snake.SnakeBody[i - 1].YPosition;
                }
            }
        }

        private void Die()
        {
            GameSettings.SetHighScore();
            GameSettings.GameOver = true;
            gameTimer.Stop();
        }

        private void Eat()
        {
            Food eatFood = new Food();
            eatFood.XPosition = snake.SnakeBody[snake.SnakeBody.Count - 1].XPosition;
            eatFood.YPosition = snake.SnakeBody[snake.SnakeBody.Count - 1].YPosition;
            snake.SnakeBody.Add(eatFood);

            GameSettings.Score += GameSettings.Points;
            scoreValue.Text = GameSettings.Score.ToString();

            GenerateFood();


        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void fileToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            gameTimer.Stop();
        }

        private void fileToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            gameTimer.Start();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {

            GameSettings.GameOver = true;
            StartGame();
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            gameTimer.Stop();
        }

        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            gameTimer.Start();
        }

        public void ShowMyDialogBox()
        {
            Form2 enterName = new Form2();
            
            enterName.Show();
      
            
        }

        private void seeHighscoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GameSettings.HighScore.ToString());
        }
    }
}
