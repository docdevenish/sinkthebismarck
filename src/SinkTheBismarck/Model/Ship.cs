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
        public string Title { get; set; }
        public string Type { get; set; }
        public string Symbol { get; set; }
        public int Size { get; set; }
        public int MaxHits { get; set; }
        public int Displacement { get; set; }
        public float MaxSpeed { get; set; }
        public List<Turret> Turrets { get; set; }
    }

    public class ShipCourse  // the location and course of the ship
    {
        public float Speed { get; set; }
        public float Direction { get; set; }
        public Vector2 Position { get; set; }
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

        public string Title { get; }
        public string Type { get; }
        public string Symbol { get; }
        public int Size { get; }
        public int MaxHits { get; }
        public int Displacement { get; }
        public float MaxSpeed { get; }
        public IReadOnlyList<Turret> Turrets { get; }

        public ShipCourse Course { get; }
        public ShipStatus Status { get; }

        // here is the constructor
        public Ship(ShipModel model, ShipCourse course)
        {
            Title = model.Title;
            Type = model.Type;
            Symbol = model.Symbol;
            Size = model.Size;
            MaxHits = model.MaxHits;
            Displacement = model.Displacement;
            MaxSpeed = model.MaxSpeed;
            Turrets = model.Turrets;
            Course = course;
            Status = new ShipStatus();
        }

        // just testing that the iVehicle interface works
        public void Move(GameTime gameTime)
        {
            double scale = 0.0001;
            double deltaX = gameTime.ElapsedGameTime.Milliseconds * Course.Speed * Math.Sin(Course.Direction) * scale;
            double deltaY = -gameTime.ElapsedGameTime.Milliseconds * Course.Speed * Math.Cos(Course.Direction) * scale;
            Course.Position = Course.Position + new Vector2 ((float) deltaX, (float) deltaY);
        }


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
                Type = "Battleship",
                Symbol = "Bis.",
                Size = 3,
                MaxHits = 12,
                Displacement = 41700,
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
                Speed = 20,
                Direction= 3.4f,
                Position = new Vector2(510, 120)
            };

            return new Ship(model, course);

        }



        static public Ship getEugen()
        {
            var model = new ShipModel
            {
                Title = "Eugen",
                Type = "Cruiser",
                Symbol = "Eug.",
                Size = 2,
                MaxHits = 9,
                Displacement= 18700,
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
                Speed = 20,
                Direction= 3.4f,
                Position = new Vector2(530, 124f)
            };

            return new Ship(model, course);

        }



        static public Ship getHood()
        {
            var model = new ShipModel
            {
                Title = "Hood",
                Type = "Battle Cruiser",
                Symbol = "Hood",
                Size = 3,
                MaxHits = 10,
                Displacement= 47400,
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
                Speed = 25,
                Direction= 4.71f,
                Position = new Vector2(1300, 340),
            };

            return new Ship(model, course);

        }


        static public Ship getPOW()
        {
            var model = new ShipModel
            {
                Title = "Prince of Wales",
                Type = "Battleship",
                Symbol = "POW",
                Size = 3,
                MaxHits = 9,
                Displacement= 43800,
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
                Speed = 25,
                Direction= 4.71f,
                Position = new Vector2(1300, 380)
            };

            return new Ship(model, course);

        }


        static public Ship getRepulse()
        {
            var model = new ShipModel
            {
                Title = "Repulse",
                Type = "Battle Cruiser",
                Symbol = "Rep.",
                Size = 3,
                MaxHits = 8,
                Displacement= 27600,
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
                Speed = 0,
                Direction= 4.71f,
                Position = new Vector2(1250, 560)
            };

            return new Ship(model, course);

        }



        static public Ship getKJV()
        {
            var model = new ShipModel
            {
                Title = "King George V",
                Type = "Battleship",
                Symbol = "KGV",
                Size = 3,
                MaxHits = 10,
                Displacement= 42200,
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
                Speed = 0,
                Direction= 4.71f,
                Position = new Vector2(1250, 520f)
            };

            return new Ship(model, course);

        }


        static public Ship getRodney()
        {
            var model = new ShipModel
            {
                Title = "Rodney",
                Type = "Battleship",
                Symbol = "Rod.",
                Size = 3,
                MaxHits = 10,
                Displacement= 34300,
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
                Speed = 20,
                Direction= 5.2f,
                Position = new Vector2(1150, 960)
            };

            return new Ship(model, course);

        }

        static public Ship getNorfolk()
        {
            var model = new ShipModel
            {
                Title = "Norfolk",
                Type = "Heavy Cruiser",
                Symbol = "Norf",
                Size = 2,
                MaxHits = 5,
                Displacement= 10200,
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
                Speed = 20,
                Direction= 3.4f,
                Position = new Vector2(480, 60f)
            };

            return new Ship(model, course);

        }


        static public Ship getSuffolk()
        {
            var model = new ShipModel
            {
                Title = "Suffolk",
                Type = "Heavy Cruiser",
                Symbol = "Suff",
                Size = 2,
                MaxHits = 5,
                Displacement= 9750,
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
                Speed = 20,
                Direction= 3.4f,
                Position = new Vector2(570, 100)
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
