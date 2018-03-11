using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SnakeGame.Classes;

namespace SnakeGame
{
    public partial class SnakeUI : Form
    {
        private List<Food> snakeBody = new List<Food>();
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

        private void StartGame()
        {
            gameOverLabel.Visible = false;
            //default settings
            new GameSettings();

            snakeBody.Clear();
            //sets starting point for head of snake
            Food snakeHead = new Food();
            snakeHead.XPosition = 10;
            snakeHead.YPosition = 5;
            snakeBody.Add(snakeHead);

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

            for (int i = 0; i < snakeBody.Count; i++)//hopefully will not let it make a food piece where there is a body
            {
                do
                {
                    food.XPosition = randomPosition.Next(0, maxXPosition);
                    food.YPosition = randomPosition.Next(0, maxYPosition);
                } while (food.XPosition == snakeBody[i].XPosition && food.YPosition == snakeBody[i].YPosition);


                break;

            }



        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            //checks if game is over
            if (GameSettings.GameOver)
            {
                if (Input.IsKeyPressed(Keys.Enter))
                {
                    StartGame();
                }
            }
            else//checks to see if the direction click is possible
            {
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
            }
            gameWindow.Invalidate();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gameWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            if (!GameSettings.GameOver)
            {
                Brush snakeColor;
                for (int i = 0; i < snakeBody.Count; i++)
                {
                    snakeColor = Brushes.Black;

                    canvas.FillRectangle(snakeColor, new Rectangle(snakeBody[i].XPosition * GameSettings.Width,
                                                                   snakeBody[i].YPosition * GameSettings.Height,
                                                                   GameSettings.Width, GameSettings.Height));

                    canvas.FillRectangle(Brushes.Red, new Rectangle(food.XPosition * GameSettings.Width, food.YPosition * GameSettings.Height, GameSettings.Width, GameSettings.Height));

                }
            }
            else
            {
                string gameOver = $"Game Over!\n Your Final Score is: {GameSettings.Score} \n Press Enter to Play Again";
                gameOverLabel.Text = gameOver;
                gameOverLabel.Visible = true;
            }
        }

        private void MovePlayer()
        {
            for (int i = snakeBody.Count - 1; i >= 0; i--)
            {
                //moves head
                if (i == 0)
                {
                    switch (GameSettings.Direction)
                    {
                        case Directions.Up:
                            snakeBody[i].YPosition--;
                            break;
                        case Directions.Down:
                            snakeBody[i].YPosition++;
                            break;
                        case Directions.Left:
                            snakeBody[i].XPosition--;
                            break;
                        case Directions.Right:
                            snakeBody[i].XPosition++;
                            break;

                    }


                    int maxXPosition = gameWindow.Size.Width / GameSettings.Width;
                    int maxYPosition = gameWindow.Size.Height / GameSettings.Height;

                    //detect collision with boarder
                    if (snakeBody[i].XPosition < 0 || snakeBody[i].YPosition < 0 || snakeBody[i].XPosition >= maxXPosition || snakeBody[i].YPosition >= maxYPosition)
                    {
                        Die();
                    }

                    //detect collision with body
                    for (int h = 1; h < snakeBody.Count; h++)
                    {
                        if (snakeBody[i].XPosition == snakeBody[h].XPosition && snakeBody[i].YPosition == snakeBody[h].YPosition)
                        {
                            Die();
                        }
                    }

                    //detect collision  with food
                    if (snakeBody[0].XPosition == food.XPosition && snakeBody[i].YPosition == food.YPosition)
                    {
                        Eat();
                    }
                }
                else
                {
                    //moves body
                    snakeBody[i].XPosition = snakeBody[i - 1].XPosition;
                    snakeBody[i].YPosition = snakeBody[i - 1].YPosition;
                }
            }
        }

        private void Die()
        {
            GameSettings.GameOver = true;
        }

        private void Eat()
        {
            Food eatFood = new Food();
            eatFood.XPosition = snakeBody[snakeBody.Count - 1].XPosition;
            eatFood.YPosition = snakeBody[snakeBody.Count - 1].YPosition;
            snakeBody.Add(eatFood);

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


    }
}
