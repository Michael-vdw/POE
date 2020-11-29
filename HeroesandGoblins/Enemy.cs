using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesandGoblins
{
    [Serializable]
    abstract class Enemy : Character
    {
        Random random = new Random();
        public Enemy(int x, int y, int damage, int hp, int maxHP, char symbol) : base(x, y, symbol)
        {
            Damage = damage;
            HP = hp;
            MaxHP = maxHP;
        }
        public override string ToString()
        {
            return EquippedWeapon.WeaponType + ":" + nameof(Enemy) + "(" + HP + "/" + MaxHP + ")" + " at [" + X + "," + Y + "] " + "with" + EquippedWeapon.WeaponType + "(Durability:" +EquippedWeapon.Durability+",DMG"+ EquippedWeapon.Damage + ")";
        }
    }
    [Serializable]
    class Mage : Enemy
    {
        public Mage(int x, int y) : base(x, y, 5, 5, 5, 'M')
        {
            thisTile = TileType.Mage;
            EquippedWeapon = new MeleeWeapon(MeleeWeapon.Types.BareHanded);
            EquippedWeapon.Damage = 5;
        }

        public override Movement ReturnMove(Movement move)
        {
            return Movement.NoMove;
        }

        public override bool CheckRange(Character target)
        {
            for (int i = 0; i > 8; i++)
            {
                if (vision[i].ThisTile == TileType.Hero || vision[i].ThisTile == TileType.Empty)
                {
                    return true;
                }
            }
            return false;
        }
    }
    [Serializable]
    class Goblin : Enemy
    {
        public Goblin(int x, int y) : base(x, y, 1, 10, 10, 'G')
        {
            thisTile = TileType.Goblin;
            EquippedWeapon = new MeleeWeapon(MeleeWeapon.Types.Dagger);
        }

        public override Movement ReturnMove(Movement move)
        {
            Random random = new Random();
            int randomroll = random.Next(1, 5);

            while (vision[randomroll].thisTile != TileType.Empty)
            {
                randomroll = random.Next(1, 5);
            }
            return (Movement)randomroll;
        }
    }

    class Leader : Enemy
    {
        private Tile leaderTarget;
        public Tile LeaderTarget { get => leaderTarget; set => leaderTarget = value; }

        public Leader(int x, int y) : base(x, y, 2, 20, 20, 'L')
        {
            thisTile = TileType.Leader;
            EquippedWeapon = new MeleeWeapon(MeleeWeapon.Types.Longsword);
        }

        public override Movement ReturnMove(Movement move)
        {
            if (LeaderTarget.X > X && Vision[3].thisTile == TileType.Empty)
            {
                return Movement.Right;
            }
            if (LeaderTarget.X < X && Vision[2].thisTile == TileType.Empty)
            {
                return Movement.Left;
            }
            if (LeaderTarget.Y > Y && Vision[1].thisTile == TileType.Empty)
            {
                return Movement.Down;
            }
            if (LeaderTarget.Y < Y && Vision[0].thisTile == TileType.Empty)
            {
                return Movement.Up;
            }

            Random random = new Random();
            int RandomMove = random.Next(1,5);

            if (RandomMove == 1 && Vision[0].thisTile == TileType.Empty)
            {
                return Movement.Up;
            }
            if (RandomMove == 2 && Vision[1].thisTile == TileType.Empty)
            {
                return Movement.Down;
            }
            if (RandomMove == 3 && Vision[2].thisTile == TileType.Empty)
            {
                return Movement.Left;
            }
            if (RandomMove == 4 && Vision[3].thisTile == TileType.Empty)
            {
                return Movement.Right;
            }
           
            return Movement.NoMove;
        }
    }
}
