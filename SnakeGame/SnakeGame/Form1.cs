//Carol Gabriel
//1732994

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace SnakeGame
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public partial class Form1 : Form
    {
        int dotWidth = 10;
        int maxWidth = 0;
        int maxHeight = 0;
        int bodyElements = 1;
        int snakeSpeed = 10;
        Dot snakeHead;
        Dot body;
        Dot berry;
        Snake snake;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            maxWidth = this.ClientSize.Width / dotWidth;
            maxHeight = this.ClientSize.Height / dotWidth;

            CreateSnake();
            CreateBerry();
            TimerSetup();
        }

        private void TimerSetup()
        {
            timer1.Interval = 1000 / snakeSpeed;
            timer1.Tick += UpdateGameSession;
            timer1.Start();            
        }

        private void CreateSnake()
        {
            Point start = new Point(210, 200);
            snakeHead = new Dot(start, Color.PeachPuff, 10);
            snake = new Snake();
            snake.Body.Add(snakeHead);

            for (int i = 0; i <= bodyElements; i++)
            {
                Point bod = new Point();
                if (snake.Direction == Direction.Up)
                {
                    bod.X = start.X;
                    bod.Y = start.Y + i * dotWidth;
                }
                else if (snake.Direction == Direction.Down)
                {
                    bod.X = start.X;
                    bod.Y = start.Y - i * dotWidth;
                }
                else if (snake.Direction == Direction.Right)
                {
                    bod.X = start.X - i * dotWidth;
                    bod.Y = start.Y;
                }
                else if (snake.Direction == Direction.Left)
                {
                    bod.X = start.X + i * dotWidth;
                    bod.Y = start.Y;
                }
                body = new Dot(bod, Color.RoyalBlue, dotWidth);

                if (i != 0)
                {
                    snake.Body.Add(body);
                }
            }          

        }
        private void CreateBerry()
        {
            Random rnd = new Random();
            int randomX = rnd.Next(0, this.ClientSize.Width - dotWidth - dotWidth);
            int randomY = rnd.Next(0, this.ClientSize.Height - dotWidth - dotWidth);
            randomX = (dotWidth - randomX % dotWidth) + randomX;
            randomY = (dotWidth - randomY % dotWidth) + randomY;
            Point randomPoint = new Point(randomX, randomY);
            berry = new Dot(randomPoint, Color.HotPink, dotWidth);

        }

       /*private void Difficulty()
        {
            for (int i = 0; i <= bodyElements; i++)
            {
                if (bodyElements == i + 3)
                {
                    snakeSpeed = snakeSpeed + 2;
                    TimerSetup();
                    break;
                }
            }
        }*/

        private void UpdateGameSession(object sender, EventArgs e)
        {
            //Update snake Direction
            UpdateSnakeHeading(snake.Direction);

            EatBerry();

            Collision();

            //Difficulty();
            //Refresh the screen to redraw snake
            this.Refresh();            

        }

        //Update snake heading recalculate teh position of the head based on the heading
        private void UpdateSnakeHeading(Direction d)
        {
            Point newPoint;
            var upperIndex = snake.Body.Count - 2;
            for (int i = upperIndex; i > -1; i--)
            {
                Point pt = snake.Body[i].Location;
                snake.Body[i + 1].Location = pt;
            }
            if (d == Direction.Right && snake.Direction != Direction.Left)
            {
                newPoint = new Point(snake.Body[0].Location.X + dotWidth, snake.Body[0].Location.Y);
                snake.Body[0].Location = newPoint;
                snake.Direction = d;
            }
            if (d == Direction.Left && snake.Direction != Direction.Right)
            {
                newPoint = new Point(snake.Body[0].Location.X - dotWidth, snake.Body[0].Location.Y);
                snake.Body[0].Location = newPoint;
                snake.Direction = d;
            }
            if (d == Direction.Up && snake.Direction != Direction.Down)
            {
                newPoint = new Point(snake.Body[0].Location.X, snake.Body[0].Location.Y - dotWidth);
                snake.Body[0].Location = newPoint;
                snake.Direction = d;
            }
            if (d == Direction.Down && snake.Direction != Direction.Up)
            {
                newPoint = new Point(snake.Body[0].Location.X, snake.Body[0].Location.Y + dotWidth);
                snake.Direction = d;
                snake.Body[0].Location = newPoint;
            }
            // label2.Text = " Head.X = " + snake.Body[0].Location.X + " | Head.Y = " + snake.Body[0].Location.Y;


        }

        private void EatBerry()
        {
            if (snakeHead.Location == berry.Location)
            {
                bodyElements++;
                for (int i = 0; i <= bodyElements; i++)
                {
                    if (i == bodyElements)
                    {
                        Point bod = new Point();
                        if (snake.Direction == Direction.Up)
                        {
                            bod.X = snakeHead.Location.X;
                            bod.Y = snakeHead.Location.Y + i * dotWidth;
                        }
                        else if (snake.Direction == Direction.Down)
                        {
                            bod.X = snakeHead.Location.X;
                            bod.Y = snakeHead.Location.Y - i * dotWidth;
                        }
                        else if (snake.Direction == Direction.Right)
                        {
                            bod.X = snakeHead.Location.X - i * dotWidth;
                            bod.Y = snakeHead.Location.Y;
                        }
                        else if (snake.Direction == Direction.Left)
                        {
                            bod.X = snakeHead.Location.X + i * dotWidth;
                            bod.Y = snakeHead.Location.Y;
                        }
                        body = new Dot(bod, Color.RoyalBlue, dotWidth);

                        if (i != 0)
                        {
                            snake.Body.Add(body);
                        }
                    }
                }
                CreateBerry();
            }
        }

        private void Collision()
        {
            //collision with wall
            for (int i = 0; i <= bodyElements; i++)
            {
                if (snake.Body[0].Location.X == snake.Body[i].Location.X && snake.Body[0].Location.Y == snake.Body[i].Location.Y && i != 0)
                {
                    timer1.Stop();
                }
            }
            if (snake.Body[0].Location.Y < 0 || snake.Body[0].Location.Y > this.ClientSize.Height)
            {
                timer1.Stop();
            }
            else if (snake.Body[0].Location.X < 0 || snake.Body[0].Location.X > this.ClientSize.Width)
            {
                timer1.Stop();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            SolidBrush headBrush = new SolidBrush(snakeHead.Colour);
            SolidBrush bodyBrush = new SolidBrush(body.Colour);

            foreach(var bodyParts in snake.Body)
            {
                if (bodyParts == snakeHead)
                {
                    Rectangle rect = new Rectangle(bodyParts.Location.X, bodyParts.Location.Y, dotWidth, dotWidth);
                    e.Graphics.FillRectangle(headBrush, rect);
                }
                else
                {
                        Rectangle rectBody = new Rectangle(bodyParts.Location.X, bodyParts.Location.Y, dotWidth, dotWidth);
                        e.Graphics.FillRectangle(bodyBrush, rectBody);                   
                }
            }
            SolidBrush berryBrush = new SolidBrush(berry.Colour);
            Rectangle rect2 = new Rectangle(berry.Location.X, berry.Location.Y, dotWidth, dotWidth);

            e.Graphics.FillRectangle(berryBrush, rect2);

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keydata)
        {
            if (keydata == Keys.Up && snake.Direction != Direction.Down)
            {
                UpdateSnakeHeading(Direction.Up);
                return true;
            }
            if (keydata == Keys.Down && snake.Direction != Direction.Up)
            {
                UpdateSnakeHeading(Direction.Down);
                return true;
            }
            if (keydata == Keys.Left && snake.Direction != Direction.Right)
            {
                UpdateSnakeHeading(Direction.Left);
                return true;
            }
            if (keydata == Keys.Right && snake.Direction != Direction.Left)
            {
                UpdateSnakeHeading(Direction.Right);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keydata);
        }


        private class Dot
        {
            Point location;
            Color colour;
            int width;

            public Point Location { get => location; set => location = value; }
            public Color Colour { get => colour; set => colour = value; }
            public int Width { get => width; set => width = value; }

            public Dot(Point p, Color c, int w)
            {
                this.Location = p;
                this.Colour = c;
                this.Width = w;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private class Snake
        {
            private List<Dot> body;
            private Direction direction;

            public List<Dot> Body { get => body; set => body = value; }
            public Direction Direction { get => direction; set => direction = value; }

            public Snake()
            {
                Body = new List<Dot>();
                Direction = Direction.Right;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }        
}
