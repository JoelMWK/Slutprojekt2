﻿global using System;
global using Raylib_cs;
global using System.Numerics;
global using System.IO;
global using System.Text.Json;

Raylib.InitWindow(900, 540, "Topdown");
Raylib.SetTargetFPS(60);

ClassSelector classSelector = new ClassSelector();
EnemySpawner enemySpawner = new EnemySpawner();
Map map = new Map();
map.LoadMap("./stages/stage1.json");

while (!Raylib.WindowShouldClose())
{
    if (!classSelector.Selected)
    {
        classSelector.ChoosePlayer();
    }
    else
    {
        //Logik
        enemySpawner.Update();
        classSelector.Update();

        //Grafik
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.SKYBLUE);
        Raylib.BeginMode2D(ClassSelector.players[classSelector.ClassIndex].Cam.Camera2D);

        map.DrawMap();
        enemySpawner.Draw();
        classSelector.Draw();

        Raylib.EndMode2D();
        Raylib.EndDrawing();
    }
}