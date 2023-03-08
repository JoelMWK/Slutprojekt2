global using System;
global using Raylib_cs;
global using System.Numerics;
global using System.IO;
global using System.Text.Json;

Raylib.InitWindow(900, 540, "Platformer");
Raylib.SetTargetFPS(60);


Player player = new Player();
Enemy enemy = new Enemy();
Map map = new Map();
map.LoadMap("./stages/stage1.json");


while (!Raylib.WindowShouldClose())
{
    //Logik
    player.Update();
    enemy.Update();
    player.MapCollision();
    enemy.MapCollision();

    //Grafik
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.SKYBLUE);

    Raylib.DrawRectangle(0, 500, 900, 50, Color.GRAY);
    map.DrawMap();
    player.Draw();
    enemy.Draw();

    Raylib.EndDrawing();
}