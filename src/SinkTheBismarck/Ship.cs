using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2
{

    // Some preliminary Classes to store ship information

    public class ShipModel  // the properties of the ship
    {
        // these are properties of the ship
        public string Title { get; set; }
        public string type { get; set; }
        public string Symbol { get; set; }
        public int Size { get; set; }
        public int MaxHits { get; set; }
        public int Disp { get; set; }
        public float MaxSpeed { get; set; }
        public List<Turret> Turrets { get; set; }
    }

    public class ShipCourse  // the location and course of the ship
    {
        public float speed { get; set; }
        public float direction { get; set; }
        public Vector2 position { get; set; }
    }

    public class ShipStatus  // the status of the ship
    {
        public float hits { get; set; }
        public bool active { get; set; } = true;
        public bool bridge { get; set; } = true;
        public bool engine { get; set; } = true;
    }

    public class Turret
    {
        public int Guns { get; set; }
        public decimal Firepower { get; set; }
        public bool Active { get; set; }

        public Turret(int guns, decimal firepower)
        {
            Guns = guns;
            Firepower = firepower;
        }
    }


    // Now the Ship Class itself

    public class Ship : IVehicle
    {
        public ShipModel model;
        public ShipCourse course;
        public ShipStatus status;
       /* 
        public List<Turret> Turrets { get; set; }
  */


        // just testing that the iVehicle interface works
        public void Move(GameTime gameTime)
        {
            double scale = 0.0001;
            double deltaX = gameTime.ElapsedGameTime.Milliseconds * course.speed * Math.Sin(course.direction) * scale;
            double deltaY = -gameTime.ElapsedGameTime.Milliseconds * course.speed * Math.Cos(course.direction) * scale;
            course.position = course.position + new Vector2 ((float) deltaX, (float) deltaY);
        }

        // gun array? Gun:array[1..4, 1..4] of boolean;

        // here is the constructor
        public Ship(ShipModel model, ShipCourse course)
        {
            this.model = model;
            this.course = course;
            // set the status!!
        }


        // is this a 'setter' ?
        public void UpdateCourse(ShipCourse course)
        {
            this.course = course;
        }


       /* public void TakeHits(float hits)
        {
            Hits += hits;
            // logic for bridge/engine/active

            if (Hits > MaxHits) Active = false;
        }*/
        /*
        // the constructor
        public Ship(int _index, string _title, string _symbol, int _size, int _maxHits, float _firePower, float _maxSpeed, float _speed, float _direction, Vector2 _position)
        {
            For I:= 1 to 4 Do ship[K].Gun[I, 1]:= true;
            { gun active}
            For I:= 1 to 4 Do ship[K].Gun[I, 2]:= false;
            { re - loading}
            For I:= 1 to 4 Do ship[K].Gun[I, 4]:= false;
            { still re-loading}

            
            Title = _title;
            Symbol = _symbol;
            size = _size;
            maxHits = _maxHits;
            firePower = _firePower;
            maxSpeed = _maxSpeed;
            speed = _speed;
            direction = _direction;
            position = _position;

            hits = 0;
            active = true;
            bridge = true;
            engine = true;
            
        }  */

        public void Update()
        {

        }

        public void Draw()
        {

        }
    
        // Methods for initialising the Ships - I haven't set the turrets!!

        static public Ship getBismarck()
        {
            var model = new ShipModel
            {
                Title = "Bismarck",
                type = "Battleship",
                Symbol = "Bis.",
                Size = 3,
                MaxHits = 12,
                Disp = 41700,
                Turrets = new List<Turret>
                {
                    new Turret(2, 15),
                    new Turret(2, 15),
                    new Turret(2, 15),
                    new Turret(2, 15)
                },
                MaxSpeed = 30
            };

            var course = new ShipCourse
            {
                speed = 20,
                direction = 3.4f,
                position = new Vector2(510, 120)
            };

            return new Ship(model, course);

        }



        static public Ship getEugen()
        {
            var model = new ShipModel
            {
                Title = "Eugen",
                type = "Cruiser",
                Symbol = "Eug.",
                Size = 2,
                MaxHits = 9,
                Disp = 18700,
                Turrets = new List<Turret>
                {
                    new Turret(2, 8),
                    new Turret(2, 8),
                    new Turret(2, 8),
                    new Turret(2, 8)
                },
                MaxSpeed = 32
            };

            var course = new ShipCourse
            {
                speed = 20,
                direction = 3.4f,
                position = new Vector2(530, 124f)
            };

            return new Ship(model, course);

        }



        static public Ship getHood()
        {
            var model = new ShipModel
            {
                Title = "Hood",
                type = "Battle Cruiser",
                Symbol = "Hood",
                Size = 3,
                MaxHits = 10,
                Disp = 47400,
                Turrets = new List<Turret>
                {
                    new Turret(2, 15),
                    new Turret(2, 15),
                    new Turret(2, 15),
                    new Turret(2, 15)
                },
                MaxSpeed = 30
            };

            var course = new ShipCourse
            {
                speed = 25,
                direction = 4.71f,
                position = new Vector2(1300, 340),
            };

            return new Ship(model, course);

        }


        static public Ship getPOW()
        {
            var model = new ShipModel
            {
                Title = "Prince of Wales",
                type = "Battleship",
                Symbol = "POW",
                Size = 3,
                MaxHits = 9,
                Disp = 43800,
                Turrets = new List<Turret>
                {
                    new Turret(2, 14),
                    new Turret(4, 14),
                    new Turret(4, 14),
                    new Turret(0, 1)
                },
                MaxSpeed = 28.3f
            };

            var course = new ShipCourse
            {
                speed = 25,
                direction = 4.71f,
                position = new Vector2(1300, 380)
            };

            return new Ship(model, course);

        }


        static public Ship getRepulse()
        {
            var model = new ShipModel
            {
                Title = "Repulse",
                type = "Battle Cruiser",
                Symbol = "Rep.",
                Size = 3,
                MaxHits = 8,
                Disp = 27600,
                Turrets = new List<Turret>
                {
                    new Turret(2, 15),
                    new Turret(2, 15),
                    new Turret(2, 15),
                    new Turret(0, 1)
                },
                MaxSpeed = 31.5f
            };

            var course = new ShipCourse
            {
                speed = 0,
                direction = 4.71f,
                position = new Vector2(1250, 560)
            };

            return new Ship(model, course);

        }



        static public Ship getKJV()
        {
            var model = new ShipModel
            {
                Title = "King George V",
                type = "Battleship",
                Symbol = "KGV",
                Size = 3,
                MaxHits = 10,
                Disp = 42200,
                Turrets = new List<Turret>
                {
                    new Turret(2, 14),
                    new Turret(4, 14),
                    new Turret(4, 14),
                    new Turret(0, 1)
                },
                MaxSpeed = 28
            };

            var course = new ShipCourse
            {
                speed = 0,
                direction = 4.71f,
                position = new Vector2(1250, 520f)
            };

            return new Ship(model, course);

        }


        static public Ship getRodney()
        {
            var model = new ShipModel
            {
                Title = "Rodney",
                type = "Battleship",
                Symbol = "Rod.",
                Size = 3,
                MaxHits = 10,
                Disp = 34300,
                Turrets = new List<Turret>
                {
                    new Turret(3, 16),
                    new Turret(3, 16),
                    new Turret(3, 16),
                    new Turret(0, 1)
                },
                MaxSpeed = 23
            };

            var course = new ShipCourse
            {
                speed = 20,
                direction = 5.2f,
                position = new Vector2(1150, 960)
            };

            return new Ship(model, course);

        }

        static public Ship getNorfolk()
        {
            var model = new ShipModel
            {
                Title = "Norfolk",
                type = "Heavy Cruiser",
                Symbol = "Norf",
                Size = 2,
                MaxHits = 5,
                Disp = 10200,
                Turrets = new List<Turret>
                {
                    new Turret(2, 8),
                    new Turret(2, 8),
                    new Turret(2, 8),
                    new Turret(2, 8)
                },
                MaxSpeed = 31.5f
            };

            var course = new ShipCourse
            {
                speed = 20,
                direction = 3.4f,
                position = new Vector2(480, 60f)
            };

            return new Ship(model, course);

        }


        static public Ship getSuffolk()
        {
            var model = new ShipModel
            {
                Title = "Suffolk",
                type = "Heavy Cruiser",
                Symbol = "Suff",
                Size = 2,
                MaxHits = 5,
                Disp = 9750,
                Turrets = new List<Turret>
                {
                    new Turret(2, 8),
                    new Turret(2, 8),
                    new Turret(2, 8),
                    new Turret(2, 8)
                },
                MaxSpeed = 31.5f
            };

            var course = new ShipCourse
            {
                speed = 20,
                direction = 3.4f,
                position = new Vector2(570, 100)
            };

            return new Ship(model, course);

        }
    }
}

/*

Begin



{*** Go through the introduction to the game ***}
  Introduction;

{*** Commence the game ***}
  While not Finished Do
  Begin

    If Normal Then Normalgame;

    While not Normal Do             {This is the other animation loop}
    Begin
      ZTitle(current);
      Status(current);
      Zoom;           
      For J:=1 to 4 Do
          For K:=0 to 8 Do
          Begin
            If ship[K].gun[J,4]=false Then ship[K].gun[J,2]:=false;
            If ship[K].gun[J,4]=true Then ship[K].gun[J,4]:=false;
          End;
      Radar2;
      If ship[current].active=false then normal:=true;
    End;

    IF ship[0].Xm>190 Then Finished:=true;

  End;
 
*/
