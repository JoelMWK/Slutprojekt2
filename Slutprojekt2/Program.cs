global using System;
global using Raylib_cs;
global using System.Numerics;
global using System.IO;
global using System.Text.Json;

Raylib.InitWindow(900, 900, "Platformer");
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
    Raylib.ClearBackground(Color.WHITE);

    Raylib.DrawRectangle(0, 850, 900, 50, Color.GRAY);
    map.DrawMap();
    player.Draw();

    Raylib.EndDrawing();
}