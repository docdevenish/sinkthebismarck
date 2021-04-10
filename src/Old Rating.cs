using System;
namespace Game2

public class Rating
{

    private int no;
    private string title;
    private string symbol;
    private int size;
    private int maxHits;
    private float firePower;
    private float maxSpeed;
    private float speed;
    private float direction;
    private Vector2 position;


    private float hits;
    private bool active;
    private bool bridge;
    private bool engine;

    // gun array? Gun:array[1..4, 1..4] of boolean;

 


    // the constructor
    public Rating(_index, _title, _symbol, _size, _maxHits, _firePower, _maxSpeed, _speed, _direction, _position)
	{
        /*For I:= 1 to 4 Do ship[K].Gun[I, 1]:= true;
        { gun active}
        For I:= 1 to 4 Do ship[K].Gun[I, 2]:= false;
        { re - loading}
        For I:= 1 to 4 Do ship[K].Gun[I, 4]:= false;
        { still re-loading}*/

        no = _index;
        title = _title;
        symbol = _symbol;
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

    }

    public void Update()
    {
        
    }

    public void Draw()
    {

    }

    public getBismarck()
    {
        return new Rating(0, 'Bismarck', 'Bis.', 3, 12, 1, 30, 25, 270, (500,500));
    }



}



/*
 * class Aircraft:

    def __init__ (self, mass, engine, wing_area, dia, drag_area):
        self.mass = mass
        self.engine = engine
        self.wing_Area = wing_area
        self.dia = dia
        self.drag_Area = drag_area


def get_camel():
    return Aircraft(650, 97, 21.5, 2.59, 0.81)


def get_se5a():
    return Aircraft(878, 110, 22.7, 2.36, 0.85)

 *    Rating=object
         No:integer;
         Xm,Ym:real;
         Title:string;
         Titlesh:string;
         Symbol:string;
         Active:Boolean;
         FirePower:Real;
         Speed,Maxspeed:real;
         Dirn:real;
         Hits:real;
         Size:Integer;
         Maxhits:Integer;
         Gun:array[1..4,1..4]of boolean;
         Bridge,Engine:boolean;
         Procedure Fire;
         Procedure BisFire;
         Procedure displaymap;
         Procedure Respond;
         Procedure Update;
         Procedure Get_course;
         Procedure Get_speed;
   End;



Procedure Rating.Get_course;
Var
  T:real;
Begin
  T:=random;
  If T>0.4 Then
  Begin
    If T<0.6 Then Dirn:=255;
    If (0.6<T) and (T<0.8) Then Dirn:=270;
    If 0.8<T Then Dirn:=285;
  End;
  If Ym>latitude Then Dirn:=0;
End;
  
Procedure Rating.Get_speed;
Var
  T:real;
Begin
  T:=random;
  If T>0.4 Then
  Begin
    If T<0.65 Then Speed:=18;
    If (0.65<T) and (T<0.9) Then Speed:=22;
    If 0.9<T Then Speed:=26;
  End;
  If Speed>Maxspeed then speed:=Maxspeed;
End;

Procedure Rating.Displaymap;
Var
   Color:integer;

Begin
   setcolor(yellow);
   SetTextJustify(CenterText, CenterText);
   SetTextStyle(2, HorizDir, 0);
   If Active=true Then
   Begin
     OutTextXY(round(Xm),round(Ym),symbol);
   End;
End;

Procedure Rating.Update;
Var
  Zspeed:real;
Begin
  If normal Then Zspeed:=Speed Else Zspeed:=Speed/30;
  Xm:=Xm+Zspeed*0.5*cos(3.14156*dirn/180.0);
  Ym:=Ym-Zspeed*0.5*sin(3.14156*dirn/180);
End;


    
Procedure Initialize;
Var
     I,K:Integer;
     T:Real;
Begin
     Randomize;
     T:=random;
     latitude:=170;
     If T<0.66 Then latitude:=180;
     If T<0.33 Then latitude:=190;
     Reconn:=false;
     Finished:=false;
     Normal:=true;
     Together:=true;
     noreconn:=0;
     For K:=0 to 11 Do
     Begin
       For I:=1 to 4 Do ship[K].Gun[I,1]:=true;    {gun active}
       For I:=1 to 4 Do ship[K].Gun[I,2]:=false;   {re-loading}
       For I:=1 to 4 Do ship[K].Gun[I,4]:=false;   {still re-loading}
       ship[K].Bridge:=true;
       ship[K].Engine:=true;
     End;
     For I:=0 to 8 Do
     RD[I].no:=I;
         Ship[0].Xm:=70;
         Ship[0].Ym:=30;
         Ship[0].No:=0;
         Ship[0].Symbol:='<Bism.>';
         Ship[0].Active:=True;
         Ship[0].FirePower:=1;
         Ship[0].Speed:=25;
         Ship[0].MaxSpeed:=30;
         Ship[0].dirn:=270;
         Ship[0].Hits:=0;
         Ship[0].Size:=3;
         Ship[0].Maxhits:=12;

         Ship[1].Xm:=71;
         Ship[1].Ym:=30.5;
         Ship[1].No:=1;
         Ship[1].Symbol:='<Eugen>';
         Ship[1].Active:=True;
         Ship[1].FirePower:=0.8;
         Ship[1].Speed:=25;
         Ship[1].MaxSpeed:=30;
         Ship[1].dirn:=270;
         Ship[1].Hits:=0;
         Ship[1].Size:=2;
         Ship[1].Maxhits:=9;
         ship[1].gun[4,1]:=false;

         Ship[2].Xm:=150;
         Ship[2].Ym:=78;
         Ship[2].No:=2;
         Ship[2].Symbol:='<Hood>';
         Ship[2].Title:='Battleship Hood';
         Ship[2].Titlesh:='Hood';
         Ship[2].Active:=True;
         Ship[2].FirePower:=1;
         Ship[2].Speed:=25;
         Ship[2].MaxSpeed:=28;
         Ship[2].dirn:=180;
         Ship[2].Hits:=0;
         Ship[2].Size:=3;
         Ship[2].Maxhits:=10;

         Ship[3].Xm:=150;
         Ship[3].Ym:=81;
         Ship[3].No:=3;
         Ship[3].Symbol:='<P.W.>';
         Ship[3].Title:='Battle Cruiser Prince of Wales';
         Ship[3].Titlesh:='Prince of Wales';
         Ship[3].Active:=True;
         Ship[3].FirePower:=0.8;
         Ship[3].Speed:=25;
         Ship[3].MaxSpeed:=30;
         Ship[3].dirn:=180;
         Ship[3].Hits:=0;
         Ship[3].Size:=3;
         Ship[3].Maxhits:=9;

         Ship[6].Xm:=181;
         Ship[6].Ym:=101;
         Ship[6].No:=6;
         Ship[6].Symbol:='<Rep.>';
         Ship[6].Title:='Battle Cruiser Repulse';
         Ship[6].Titlesh:='Repulse';
         Ship[6].Active:=True;
         Ship[6].FirePower:=0.8;
         Ship[6].Speed:=25;
         Ship[6].MaxSpeed:=30;
         Ship[6].Dirn:=180;
         Ship[6].Hits:=0;
         Ship[6].Size:=3;
         Ship[6].Maxhits:=8;
         ship[6].gun[4,1]:=false;

         Ship[5].Xm:=180;
         Ship[5].Ym:=98.5;
         Ship[5].No:=5;
         Ship[5].Symbol:='<K.G.5>';
         Ship[5].Title:='Battleship King George V';
         Ship[5].Titlesh:='King George V';
         Ship[5].Active:=True;
         Ship[5].FirePower:=0.8;
         Ship[5].Speed:=25;
         Ship[5].MaxSpeed:=35;
         Ship[5].dirn:=180;
         Ship[5].Hits:=0;
         Ship[5].Size:=3;
         Ship[5].Maxhits:=10;

         Ship[4].Xm:=170;
         Ship[4].Ym:=115;
         Ship[4].No:=4;
         Ship[4].Symbol:='<Rod.>';
         Ship[4].Title:='Battleship Rodney';
         Ship[4].Titlesh:='Rodney';
         Ship[4].Active:=True;
         Ship[4].FirePower:=1;
         Ship[4].Speed:=25;
         Ship[4].MaxSpeed:=28;
         Ship[4].dirn:=180;
         Ship[4].Hits:=0;
         Ship[4].Size:=3;
         Ship[4].Maxhits:=10;

         Ship[7].Xm:=74;
         Ship[7].Ym:=27.5;
         Ship[7].No:=7;
         Ship[7].Symbol:='<Norf>';
         Ship[7].Title:='Cruiser Norfolk';
         Ship[7].Titlesh:='Cruiser Norfolk';
         Ship[7].Active:=True;
         Ship[7].FirePower:=0.5;
         Ship[7].Speed:=25;
         Ship[7].MaxSpeed:=33;
         Ship[7].Dirn:=270;
         Ship[7].Hits:=0;
         Ship[7].Size:=2;
         Ship[7].Maxhits:=5;
         ship[7].gun[4,1]:=false;

         Ship[8].Xm:=75;
         Ship[8].Ym:=30;
         Ship[8].No:=8;
         Ship[8].Symbol:='<Suff>';
         Ship[8].Title:='Cruiser Suffolk';
         Ship[8].Titlesh:='Cruiser Suffolk';
         Ship[8].Active:=True;
         Ship[8].FirePower:=0.5;
         Ship[8].Speed:=25;
         Ship[8].MaxSpeed:=33;
         Ship[8].dirn:=270;
         Ship[8].Hits:=0;
         Ship[8].Size:=2;
         Ship[8].Maxhits:=5;
         ship[8].gun[4,1]:=false;

End;                                                    {Initialize}



*/
