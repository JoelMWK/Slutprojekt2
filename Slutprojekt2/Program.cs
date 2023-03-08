global using System;
global using Raylib_cs;
global using System.Numerics;
global using System.IO;
global using System.Text.Json;

Raylib.InitWindow(900, 540, "Platformer");
Raylib.SetTargetFPS(60);


Player player = new Player();
Map map = new Map();
map.LoadMap("./stages/stage1.json");


while (!Raylib.WindowShouldClose())
{
    //Logik
    player.Update();
    player.UpdateGun();

    //Grafik
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.SKYBLUE);

    Raylib.DrawCircle(750, 80, 50, Color.YELLOW);
    Raylib.DrawCircle(720, 70, 10, Color.WHITE);
    Raylib.DrawCircle(780, 70, 10, Color.WHITE);
    Raylib.DrawRectangle(725, 100, 50, 8, Color.WHITE);
    Raylib.DrawRectangle(0, 500, 900, 50, Color.GRAY);
    map.DrawMap();
    player.Draw();

    Raylib.EndDrawing();
}