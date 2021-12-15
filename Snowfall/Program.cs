using System;
using System.Collections.Generic;
using Raylib_cs;

Raylib.InitWindow(1200, 900, "Snowfall");
Raylib.SetTargetFPS(60);

Color skyBlue = new Color(135, 206, 235, 255);
List<Rectangle> snowflakes = new List<Rectangle>();
List<float> snowSpeed = new List<float>();

Random generator = new Random();


for (int i = 0; i < 50000; i++)
{
    int x = generator.Next(Raylib.GetScreenWidth());
    int y = generator.Next(Raylib.GetScreenHeight());
    int size = generator.Next(2, 7);
    snowflakes.Add(new Rectangle(x, y, size, size));

    float speed = (float) (generator.NextDouble() + 0.5);
    snowSpeed.Add(speed);
}

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(skyBlue);

    for (int i = 0; i < snowflakes.Count; i++)
    {
    Rectangle flake = snowflakes[i];
    
    flake.y += snowSpeed[i];

    if (flake.y > Raylib.GetScreenHeight())
    {
        flake.y = -10;
    }
    snowflakes[i] = flake;

    Raylib.DrawRectangleRec(snowflakes[i], Color.WHITE);
    }

    Raylib.EndDrawing();
}

