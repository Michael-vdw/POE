using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeroesandGoblins
{
    public partial class Form1 : Form
    {
        private static readonly char cHero = 'H';
        private static readonly char cGoblin = 'G';
        private static readonly char cMage = 'M';
        private static readonly char cGold = '$';
        private static readonly char cEmpty = '.';
        private static readonly char cObstacle = 'X';
        private static readonly char cWeapon = '!';
        private static readonly char cLeader = 'L';
        GameEngine gameEngine = new GameEngine();
        public void mapDraw()
        {
            labelMap.Text = "";

            for (int y = 0; y < gameEngine.EngineMap.Height; y++)
            {
                for (int x = 0; x < gameEngine.EngineMap.Width; x++)
                {
                    if (gameEngine.EngineMap.TileMap[x, y].ThisTile == Tile.TileType.Empty)
                    {
                        labelMap.Text += cEmpty;
                    }
                    if (gameEngine.EngineMap.TileMap[x, y].ThisTile == Tile.TileType.Goblin)
                    {
                        labelMap.Text += cGoblin;
                    }
                    if (gameEngine.EngineMap.TileMap[x, y].ThisTile == Tile.TileType.Mage)
                    {
                        labelMap.Text += cMage;
                    }
                    if (gameEngine.EngineMap.TileMap[x, y].ThisTile == Tile.TileType.Hero)
                    {
                        labelMap.Text += cHero;
                    }
                    if (gameEngine.EngineMap.TileMap[x, y].ThisTile == Tile.TileType.Obstacle)
                    {
                        labelMap.Text += cObstacle;
                    }
                    if (gameEngine.EngineMap.TileMap[x, y].ThisTile == Tile.TileType.Gold)
                    {
                        labelMap.Text += cGold;
                    }
                    if (gameEngine.EngineMap.TileMap[x, y].ThisTile == Tile.TileType.Weapon)
                    {
                        labelMap.Text += cWeapon;
                    }
                    if (gameEngine.EngineMap.TileMap[x, y].ThisTile == Tile.TileType.Leader)
                    {
                        labelMap.Text += cLeader;
                    }
                }
                labelMap.Text += "\n";
            }
            lblStats.Text = gameEngine.Player.ToString();
            lblEnemies.Text = "";
            for (int b = 0; b < gameEngine.EngineMap.Enemies.Length; b++)
            {
                lblEnemies.Text += gameEngine.EngineMap.Enemies[b].ToString();
                lblEnemies.Text += "\n";
            }
        }

        public Form1()
        {
            InitializeComponent();
            rtbAttack.Text = "";
            mapDraw();
            for (int i = 0; i < gameEngine.EngineMap.Enemies.Length; i++)
            {
                cbxEnemies.Items.Add(gameEngine.EngineMap.Enemies[i]);
            }  
        }

        private void btnUp_Click_1(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.Movement.Up);
            gameEngine.MoveEnemies();
            gameEngine.EnemyAttacks();
            mapDraw();
        }

        private void btnRight_Click_1(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.Movement.Right);
            gameEngine.MoveEnemies();
            gameEngine.EnemyAttacks();
            mapDraw();
        }

        private void btnDown_Click_1(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.Movement.Down);
            gameEngine.MoveEnemies();
            gameEngine.EnemyAttacks();
            mapDraw();
        }

        private void btnleft_Click_1(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.Movement.Left);
            gameEngine.MoveEnemies();
            gameEngine.EnemyAttacks();
            mapDraw();
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            if (gameEngine.Player.CheckRange((Character)cbxEnemies.SelectedItem) == true)
            {
                gameEngine.Player.Attack((Character)cbxEnemies.SelectedItem);
                rtbAttack.Text += "Attacked successfully\n";
                gameEngine.EnemyAttacks();
            }
            else
            {
                rtbAttack.Text += "Out of range\n";
            }
            for (int i = 0; i < gameEngine.EngineMap.Enemies.Length; i++)
            {
                if (gameEngine.EngineMap.Enemies[i].HP < 1)
                {
                    gameEngine.EngineMap.TileMap[gameEngine.EngineMap.Enemies[i].X, gameEngine.EngineMap.Enemies[i].Y] = new EmptyTile(gameEngine.EngineMap.Enemies[i].X, gameEngine.EngineMap.Enemies[i].Y);
                    cbxEnemies.Items.Remove(cbxEnemies.SelectedItem);
                }
            }
            mapDraw();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            gameEngine.Save();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            gameEngine.Load();
            mapDraw();
        }
    }
}
