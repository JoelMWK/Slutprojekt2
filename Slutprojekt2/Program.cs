global using System;
global using Raylib_cs;
global using System.Numerics;
global using System.IO;
global using System.Text.Json;

Raylib.InitWindow(900, 540, "Platformer");
Raylib.SetTargetFPS(60);


ClassSelector classSelector = new ClassSelector();
Enemy enemy = new Enemy();
Map map = new Map();
map.LoadMap("./stages/stage1.json");


while (!Raylib.WindowShouldClose())
{
    if (!classSelector.selected)
    {
        classSelector.ChoosePlayer();
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.BLACK);
        Raylib.EndDrawing();
    }
    else
    {
        //Logik
        enemy.Update();
        classSelector.Update();
        enemy.MapCollision();

        //Grafik
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.SKYBLUE);

        map.DrawMap();
        enemy.Draw();
        classSelector.Draw();

        Raylib.EndDrawing();
    }
}