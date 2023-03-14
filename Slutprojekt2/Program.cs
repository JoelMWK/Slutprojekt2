global using System;
global using Raylib_cs;
global using System.Numerics;
global using System.IO;
global using System.Text.Json;

Raylib.InitWindow(900, 540, "Platformer");
Raylib.SetTargetFPS(60);


//Player player = new Player();
//Archer archer = new Archer();
//Spearman spearman = new Spearman();
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
        //player.Update();
        //archer.Update();
        // spearman.Update();
        classSelector.Update();
        enemy.Update();
        //archer.MapCollision();
        //spearman.MapCollision(); 
        //player.MapCollision();
        enemy.MapCollision();

        //Grafik
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.SKYBLUE);

        map.DrawMap();
        classSelector.Draw();
        //archer.Draw();
        //spearman.Draw();
        //player.Draw();
        enemy.Draw();

        Raylib.EndDrawing();
    }
}