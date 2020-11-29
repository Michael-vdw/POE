using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesandGoblins
{
    [Serializable]
    class Map
    {
        private Tile[,] tileMap;
        private Hero player;
        private Enemy[] enemies;
        private Item[] items;
        private int minWidth, maxWidth, minHeight, maxHeight, height, width, i;
        Random randomnum = new Random();

        public int MinWidth { get => minWidth; set => minWidth = value; }
        public int MaxWidth { get => maxWidth; set => maxWidth = value; }
        public int MinHeight { get => minHeight; set => minHeight = value; }
        public int MaxHeight { get => maxHeight; set => maxHeight = value; }
        public int Height { get => height; set => height = value; }
        public int Width { get => width; set => width = value; }
        public Hero Player { get => player; set => player = value; }
        public Enemy[] Enemies { get => enemies; set => enemies = value; }
        public Tile[,] TileMap { get => tileMap; set => tileMap = value; }
        public Item[] Items { get => items; set => items = value; }

        public Map(int minwidth, int maxwidth, int minheight, int maxheight, int enemynum, int gold, int weapons)
        {
            Height = randomnum.Next(minheight, maxheight);
            Width = randomnum.Next(minwidth, maxwidth);

            items = new Item[gold];
            tileMap = new Tile[width, height];
            enemies = new Enemy[enemynum];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                    {
                        tileMap[x, y] = new Obstacle(x, y);
                    }
                    else
                    {
                        tileMap[x, y] = new EmptyTile(x, y);
                    }
                }
            }

            Create(Tile.TileType.Hero);

            i = 0;
            while (i < enemynum)
            {
                int randomEnemy = randomnum.Next(1, 4);
                if (randomEnemy == 1)
                {
                    Create(Tile.TileType.Goblin);
                }
                else if (randomEnemy == 2)
                {
                    Create(Tile.TileType.Mage);
                }
                else if (randomEnemy == 3)
                {
                    Create(Tile.TileType.Leader);
                }
                i++;
            }

            i = 0;
            while (i < gold)
            {
                Create(Tile.TileType.Gold);
                i++;
            }

            i = 0;
            while (i < weapons)
            {
                Create(Tile.TileType.Weapon);
                i++;
            }

            UpdateVision();
        }
        public void UpdateVision()
        {
            player.Vision[0] = tileMap[player.X, player.Y - 1];
            player.Vision[1] = tileMap[player.X, player.Y + 1];
            player.Vision[2] = tileMap[player.X - 1, player.Y];
            player.Vision[3] = tileMap[player.X + 1, player.Y];
            player.Vision[4] = tileMap[player.X - 1, player.Y - 1];
            player.Vision[5] = tileMap[player.X + 1, player.Y - 1];
            player.Vision[6] = tileMap[player.X + 1, player.Y + 1];
            player.Vision[7] = tileMap[player.X - 1, player.Y - 1];

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].Vision[0] = tileMap[enemies[i].X, enemies[i].Y - 1];
                enemies[i].Vision[1] = tileMap[enemies[i].X, enemies[i].Y + 1];
                enemies[i].Vision[2] = tileMap[enemies[i].X - 1, enemies[i].Y];
                enemies[i].Vision[3] = tileMap[enemies[i].X + 1, enemies[i].Y];
                enemies[i].Vision[4] = tileMap[enemies[i].X - 1, enemies[i].Y - 1];
                enemies[i].Vision[5] = tileMap[enemies[i].X + 1, enemies[i].Y - 1];
                enemies[i].Vision[6] = tileMap[enemies[i].X + 1, enemies[i].Y + 1];
                enemies[i].Vision[7] = tileMap[enemies[i].X - 1, enemies[i].Y - 1];
            }
        }

        public Item GetItemAtPosition(int x, int y)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].X == x && items[i].Y == y)
                {
                    Item tempgold;
                    tempgold = items[i];
                    items[i] = null;
                    return tempgold;
                }
            }
            return null;
        }

        private Tile Create(Tile.TileType type)
        {
            int x = randomnum.Next(1, width);
            int y = randomnum.Next(1, height);

            while (tileMap[x, y].ThisTile != Tile.TileType.Empty)
            {
                x = randomnum.Next(1, width);
                y = randomnum.Next(1, height);
            }
            if (type == Tile.TileType.Hero)
            {
                player = new Hero(x, y, 40);
                tileMap[player.X, player.Y] = player;
                return player;
            }
            if (type == Tile.TileType.Gold)
            {
                items[i] = new Gold(x, y);
                tileMap[items[i].X, items[i].Y] = items[i];
                return items[i];
            }
            if (type == Tile.TileType.Goblin)
            {
                enemies[i] = new Goblin(x, y);
                tileMap[enemies[i].X, enemies[i].Y] = enemies[i];
                return enemies[i];
            }
            if (type == Tile.TileType.Mage)
            {
                enemies[i] = new Mage(x, y);
                tileMap[enemies[i].X, enemies[i].Y] = enemies[i];
                return enemies[i];
            }
            if (type == Tile.TileType.Leader)
            {
                enemies[i] = new Leader(x, y);
                tileMap[enemies[i].X, enemies[i].Y] = enemies[i];
                return enemies[i];
            }
            if (type == Tile.TileType.Weapon)
            {
                Weapon newWeapon;
                int ranWep = randomnum.Next(1, 5);
                switch (ranWep)
                {
                    case 1:
                        newWeapon = new RangedWeapon(RangedWeapon.Types.Rifle, x, y);
                        items[i] = newWeapon;
                        break;
                    case 2:
                        newWeapon = new RangedWeapon(RangedWeapon.Types.Longbow, x, y);
                        items[i] = newWeapon;
                        break;
                    case 3:
                        newWeapon = new MeleeWeapon(MeleeWeapon.Types.Dagger, x, y);
                        items[i] = newWeapon;
                        break;
                    case 4:
                        newWeapon = new MeleeWeapon(MeleeWeapon.Types.Longsword, x, y);
                        items[i] = newWeapon;
                        break;
                }
                tileMap[items[i].X, items[i].Y] = items[i];
                return items[i];
            }
            return new EmptyTile(x, y);
        }
    }
}
