using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesandGoblins
{
    abstract class Weapon : Item
    {
        private protected int damage, range, durability, cost;
        private protected string weaponType;

        public int Damage { get => damage; set => damage = value; }
        public virtual int Range { get => range; set => range = value; }
        public int Durability { get => durability; set => durability = value; }
        public int Cost { get => cost; set => cost = value; }
        public string WeaponType { get => weaponType; set => weaponType = value; }

        public Weapon(char symbol, int x = 0, int y = 0) : base(x,y)
        {
            ThisTile = TileType.Weapon;
        }
    }

    class MeleeWeapon : Weapon
    {
        private static char defaultSymbol = '!';

        public enum Types
        {
            BareHanded,
            Dagger,
            Longsword
        }
        public override int Range { get => range; set => range = 1; }

        public MeleeWeapon(Types type, int x = 0, int y = 0 ) : base(defaultSymbol,x, y)
        {
            if (type == Types.Dagger)
            {
                WeaponType = "Dagger";
                Durability = 10;
                Damage = 3;
                Cost = 3;
            }
            if (type == Types.Longsword)
            {
                WeaponType = "Longsword";
                Durability = 6;
                Damage = 4;
                Cost = 5;
            }
            if (type == Types.BareHanded)
            {
                WeaponType = "BareHanded";
                Range = 1;
                Damage = 2;
            }
        }

    }

    class RangedWeapon : Weapon
    {
        public Types thisWeapon;
        private static char defaultSymbol = '!';

        public Types ThisWeapon { get => thisWeapon; set => thisWeapon = value; }
        public enum Types
        {
            Rifle,
            Longbow
        }
        public override int Range { get => range; set => range = 1; }

        public RangedWeapon(Types type, int x = 0, int y = 0) : base(defaultSymbol, x, y)
        {
            if (type == Types.Rifle)
            {
                WeaponType = "Rifle";
                Durability = 3;
                Range = 3;
                Damage = 5;
                Cost = 7;
            }
            if (type == Types.Longbow)
            {
                WeaponType = "Longbow";
                Durability = 4;
                Range = 2;
                Damage = 4;
                Cost = 6;
            }
        }

    }
}
