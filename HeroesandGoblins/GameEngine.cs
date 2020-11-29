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
    [Serializable]
    class GameEngine
    {
        private Map engineMap;
        private Hero player;
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream("D:\\OneDrive\\OneDrive - Vega School\\Vega\\Game Development\\Project\\Task2\\GitRepo\\Task2\\HeroesandGoblins\\MapSaveFile.txt", FileMode.Create, FileAccess.Write);
        //private static readonly char 
        public Map EngineMap { get => engineMap; set => engineMap = value; }
        public Hero Player { get => player; set => player = value; }

        public GameEngine()
        {
            engineMap = new Map(10, 15, 10, 15, 5, 5, 5);
            player = engineMap.Player;
        }

        public void Save()
        {
            formatter.Serialize(stream, engineMap);
            stream.Close();
        }

        public void Load()
        {
            stream = new FileStream(@"D:\\OneDrive\\OneDrive - Vega School\\Vega\\Game Development\\Project\\Task2\\GitRepo\\Task2\\HeroesandGoblins\\MapSaveFile.txt", FileMode.Open, FileAccess.Read);
            engineMap = (Map)formatter.Deserialize(stream);
        }

        public void EnemyAttacks()
        {
            for (int i = 0; i < engineMap.Enemies.Length; i++)
            {
                if (engineMap.Enemies[i].thisTile == Tile.TileType.Goblin)
                {
                    for (int ivision = 0; ivision < 4; ivision++)
                    {
                        if (engineMap.Enemies[i].Vision[ivision].thisTile == Tile.TileType.Hero)
                        {
                            engineMap.Enemies[i].Attack(player);
                        }
                    }
                }
                if (engineMap.Enemies[i].thisTile == Tile.TileType.Mage)
                {
                    for (int ivision = 0; ivision < 8; ivision++)
                    {
                        if (engineMap.Enemies[i].Vision[ivision].thisTile == Tile.TileType.Hero)
                        {
                            engineMap.Enemies[i].Attack(player);
                        }

                        if (engineMap.Enemies[i].Vision[ivision].thisTile == Tile.TileType.Goblin)
                        {
                            for (int a = 0; a < engineMap.Enemies.Length; a++)
                            {
                                if (engineMap.Enemies[a].X == engineMap.Enemies[i].Vision[ivision].X && engineMap.Enemies[a].Y == engineMap.Enemies[i].Vision[ivision].Y)
                                {
                                    engineMap.Enemies[i].Attack(EngineMap.Enemies[a]);
                                }
                            }
                        }
                    }
                }
                if (engineMap.Enemies[i].thisTile == Tile.TileType.Leader)
                {
                    for (int ivision = 0; ivision < 4; ivision++)
                    {
                        if (engineMap.Enemies[i].Vision[ivision].thisTile == Tile.TileType.Hero)
                        {
                            engineMap.Enemies[i].Attack(player);
                        }
                    }
                }
            }
        }

        public void MoveEnemies()
        {
            Random randomMove = new Random();
            for (int i = 0; i < engineMap.Enemies.Length; i++)
            {
                if (engineMap.Enemies[i].thisTile == Tile.TileType.Leader)
                {
                    if (Player.Y < engineMap.Enemies[i].Y && engineMap.Enemies[i].Vision[0].thisTile == Tile.TileType.Empty)
                    {
                        engineMap.Enemies[i].Move(Character.Movement.Up);
                        engineMap.TileMap[engineMap.Enemies[i].X, engineMap.Enemies[i].Y] = engineMap.Enemies[i];
                        engineMap.TileMap[engineMap.Enemies[i].X, engineMap.Enemies[i].Y + 1] = new EmptyTile(engineMap.Enemies[i].X, engineMap.Enemies[i].Y + 1);
                        engineMap.UpdateVision();
                    }
                    else if (Player.Y > engineMap.Enemies[i].Y && engineMap.Enemies[i].Vision[1].thisTile == Tile.TileType.Empty)
                    {
                        engineMap.Enemies[i].Move(Character.Movement.Down);
                        engineMap.TileMap[engineMap.Enemies[i].X, engineMap.Enemies[i].Y] = engineMap.Enemies[i];
                        engineMap.TileMap[engineMap.Enemies[i].X, engineMap.Enemies[i].Y - 1] = new EmptyTile(engineMap.Enemies[i].X, engineMap.Enemies[i].Y - 1);
                        engineMap.UpdateVision();

                    }
                    else if (Player.X < engineMap.Enemies[i].X && engineMap.Enemies[i].Vision[2].thisTile == Tile.TileType.Empty)
                    {
                        engineMap.Enemies[i].Move(Character.Movement.Left);
                        engineMap.TileMap[engineMap.Enemies[i].X, engineMap.Enemies[i].Y] = engineMap.Enemies[i];
                        engineMap.TileMap[engineMap.Enemies[i].X + 1, engineMap.Enemies[i].Y] = new EmptyTile(engineMap.Enemies[i].X + 1, engineMap.Enemies[i].Y);
                        engineMap.UpdateVision();

                    }
                    else if (Player.X > engineMap.Enemies[i].X && engineMap.Enemies[i].Vision[3].thisTile == Tile.TileType.Empty)
                    {
                        engineMap.Enemies[i].Move(Character.Movement.Right);
                        engineMap.TileMap[engineMap.Enemies[i].X, engineMap.Enemies[i].Y] = engineMap.Enemies[i];
                        engineMap.TileMap[engineMap.Enemies[i].X - 1, engineMap.Enemies[i].Y] = new EmptyTile(engineMap.Enemies[i].X - 1, engineMap.Enemies[i].Y);
                        engineMap.UpdateVision();

                    }
                    else for (int a = 0; a > 20; a++)
                        {
                            int movenum = randomMove.Next(1, 5);
                            if (movenum == 1)
                            {
                                if (engineMap.Enemies[i].Vision[0].thisTile == Tile.TileType.Empty)
                                {
                                    engineMap.Enemies[i].Move(Character.Movement.Up);
                                    engineMap.TileMap[engineMap.Enemies[i].X, engineMap.Enemies[i].Y] = engineMap.Enemies[i];
                                    engineMap.TileMap[engineMap.Enemies[i].X, engineMap.Enemies[i].Y + 1] = new EmptyTile(engineMap.Enemies[i].X, engineMap.Enemies[i].Y + 1);
                                    engineMap.UpdateVision();
                                    break;
                                }
                            }
                            if (movenum == 2)
                            {
                                if (engineMap.Enemies[i].Vision[1].thisTile == Tile.TileType.Empty)
                                {
                                    engineMap.Enemies[i].Move(Character.Movement.Down);
                                    engineMap.TileMap[engineMap.Enemies[i].X, engineMap.Enemies[i].Y] = engineMap.Enemies[i];
                                    engineMap.TileMap[engineMap.Enemies[i].X, engineMap.Enemies[i].Y - 1] = new EmptyTile(engineMap.Enemies[i].X, engineMap.Enemies[i].Y - 1);
                                    engineMap.UpdateVision();
                                    break;
                                }
                            }
                            if (movenum == 3)
                            {
                                if (engineMap.Enemies[i].Vision[2].thisTile == Tile.TileType.Empty)
                                {
                                    engineMap.Enemies[i].Move(Character.Movement.Left);
                                    engineMap.TileMap[engineMap.Enemies[i].X, engineMap.Enemies[i].Y] = engineMap.Enemies[i];
                                    engineMap.TileMap[engineMap.Enemies[i].X + 1, engineMap.Enemies[i].Y] = new EmptyTile(engineMap.Enemies[i].X + 1, engineMap.Enemies[i].Y);
                                    engineMap.UpdateVision();
                                    break;
                                }
                            }
                            if (movenum == 4)
                            {
                                if (engineMap.Enemies[i].Vision[3].thisTile == Tile.TileType.Empty)
                                {
                                    engineMap.Enemies[i].Move(Character.Movement.Right);
                                    engineMap.TileMap[engineMap.Enemies[i].X, engineMap.Enemies[i].Y] = engineMap.Enemies[i];
                                    engineMap.TileMap[engineMap.Enemies[i].X - 1, engineMap.Enemies[i].Y] = new EmptyTile(engineMap.Enemies[i].X - 1, engineMap.Enemies[i].Y);
                                    engineMap.UpdateVision();
                                    break;
                                }
                            }
                        }
                }
                if (engineMap.Enemies[i].thisTile == Tile.TileType.Goblin)
                {
                    int movenum = randomMove.Next(1, 5);
                    switch (movenum)
                    {
                        case 1:
                            if (engineMap.Enemies[i].Vision[0].thisTile == Tile.TileType.Empty)
                            {
                                engineMap.Enemies[i].Move(Character.Movement.Up);
                                engineMap.TileMap[engineMap.Enemies[i].X, engineMap.Enemies[i].Y] = engineMap.Enemies[i];
                                engineMap.TileMap[engineMap.Enemies[i].X, engineMap.Enemies[i].Y + 1] = new EmptyTile(engineMap.Enemies[i].X, engineMap.Enemies[i].Y + 1);
                                engineMap.UpdateVision();

                            }
                            break;
                        case 2:
                            if (engineMap.Enemies[i].Vision[1].thisTile == Tile.TileType.Empty)
                            {
                                engineMap.Enemies[i].Move(Character.Movement.Down);
                                engineMap.TileMap[engineMap.Enemies[i].X, engineMap.Enemies[i].Y] = engineMap.Enemies[i];
                                engineMap.TileMap[engineMap.Enemies[i].X, engineMap.Enemies[i].Y - 1] = new EmptyTile(engineMap.Enemies[i].X, engineMap.Enemies[i].Y - 1);
                                engineMap.UpdateVision();

                            }
                            break;
                        case 3:
                            if (engineMap.Enemies[i].Vision[2].thisTile == Tile.TileType.Empty)
                            {
                                engineMap.Enemies[i].Move(Character.Movement.Left);
                                engineMap.TileMap[engineMap.Enemies[i].X, engineMap.Enemies[i].Y] = engineMap.Enemies[i];
                                engineMap.TileMap[engineMap.Enemies[i].X + 1, engineMap.Enemies[i].Y] = new EmptyTile(engineMap.Enemies[i].X + 1, engineMap.Enemies[i].Y);
                                engineMap.UpdateVision();

                            }
                            break;
                        case 4:
                            if (engineMap.Enemies[i].Vision[3].thisTile == Tile.TileType.Empty)
                            {
                                engineMap.Enemies[i].Move(Character.Movement.Right);
                                engineMap.TileMap[engineMap.Enemies[i].X, engineMap.Enemies[i].Y] = engineMap.Enemies[i];
                                engineMap.TileMap[engineMap.Enemies[i].X - 1, engineMap.Enemies[i].Y] = new EmptyTile(engineMap.Enemies[i].X - 1, engineMap.Enemies[i].Y);
                                engineMap.UpdateVision();

                            }
                            break;
                    }
                }
            }
        }

        public bool MovePlayer(Character.Movement move)
        {
            if (move == Character.Movement.Down)
            {
                if (player.Vision[1].thisTile == Tile.TileType.Empty)
                {
                    player.Move(Character.Movement.Down);
                    EngineMap.TileMap[player.X, player.Y] = player;
                    EngineMap.TileMap[player.X, player.Y - 1] = new EmptyTile(player.X, player.Y - 1);
                    EngineMap.UpdateVision();
                    return true;
                }
                if (player.Vision[1].thisTile == Tile.TileType.Gold)
                {
                    for (int i = 0; i < engineMap.Items.Length; i++)
                    {
                        if (engineMap.Items[i].X == player.X && EngineMap.Items[i].Y - 1 == player.Y)
                        {
                            player.Pickup(engineMap.Items[i]);
                        }
                    }
                    player.Move(Character.Movement.Down);
                    EngineMap.TileMap[player.X, player.Y] = player;
                    EngineMap.TileMap[player.X, player.Y - 1] = new EmptyTile(player.X, player.Y - 1);
                    EngineMap.UpdateVision();
                    return true;
                }
                else
                {
                    //MessageBox.Show("Path Blocked","Cannot move here");
                    return false;
                }
            }
            if (move == Character.Movement.Right)
            {
                if (player.Vision[3].thisTile == Tile.TileType.Empty)
                {
                    player.Move(Character.Movement.Right);
                    EngineMap.TileMap[player.X, player.Y] = player;
                    EngineMap.TileMap[player.X - 1, player.Y] = new EmptyTile(player.X - 1, player.Y);
                    EngineMap.UpdateVision();
                    return true;
                }
                if (player.Vision[3].thisTile == Tile.TileType.Gold)
                {
                    for (int i = 0; i < engineMap.Items.Length; i++)
                    {
                        if (engineMap.Items[i].X - 1 == player.X && EngineMap.Items[i].Y == player.Y)
                        {
                            player.Pickup(engineMap.Items[i]);
                        }
                    }
                    player.Move(Character.Movement.Right);
                    EngineMap.TileMap[player.X, player.Y] = player;
                    EngineMap.TileMap[player.X - 1, player.Y] = new EmptyTile(player.X - 1, player.Y);
                    EngineMap.UpdateVision();
                    return true;
                }
                else
                {
                    //MessageBox.Show("Path Blocked", "Cannot move here");
                    return false;
                }
            }
            if (move == Character.Movement.Left)
            {
                if (player.Vision[2].thisTile == Tile.TileType.Empty)
                {
                    player.Move(Character.Movement.Left);
                    EngineMap.TileMap[player.X, player.Y] = player;
                    EngineMap.TileMap[player.X + 1, player.Y] = new EmptyTile(player.X + 1, player.Y);
                    EngineMap.UpdateVision();
                    return true;
                }
                if (player.Vision[2].thisTile == Tile.TileType.Gold)
                {
                    for (int i = 0; i < engineMap.Items.Length; i++)
                    {
                        if (engineMap.Items[i].X + 1 == player.X && EngineMap.Items[i].Y == player.Y)
                        {
                            player.Pickup(engineMap.Items[i]);
                        }
                    }
                    player.Move(Character.Movement.Left);
                    EngineMap.TileMap[player.X, player.Y] = player;
                    EngineMap.TileMap[player.X + 1, player.Y] = new EmptyTile(player.X + 1, player.Y);
                    EngineMap.UpdateVision();
                    return true;
                }
                else
                {
                    //MessageBox.Show("Path Blocked", "Cannot move here");
                    return false;
                }
            }
            if (move == Character.Movement.Up)
            {
                if (player.Vision[0].thisTile == Tile.TileType.Empty)
                {
                    player.Move(Character.Movement.Up);
                    EngineMap.TileMap[player.X, player.Y] = player;
                    EngineMap.TileMap[player.X, player.Y + 1] = new EmptyTile(player.X, player.Y + 1);
                    EngineMap.UpdateVision();
                    return true;
                }
                if (player.Vision[0].thisTile == Tile.TileType.Gold)
                {
                    for (int i = 0; i < engineMap.Items.Length; i++)
                    {
                        if (engineMap.Items[i].X == player.X && EngineMap.Items[i].Y + 1 == player.Y)
                        {
                            player.Pickup(engineMap.Items[i]);
                        }
                    }
                    player.Move(Character.Movement.Up);
                    EngineMap.TileMap[player.X, player.Y] = player;
                    EngineMap.TileMap[player.X, player.Y + 1] = new EmptyTile(player.X, player.Y + 1);
                    EngineMap.UpdateVision();
                    return true;
                }
                else
                {
                    //MessageBox.Show("Path Blocked", "Cannot move here");
                    return false;
                }
            }
            return false;
        }
    }
}
