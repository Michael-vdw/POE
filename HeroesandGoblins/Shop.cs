using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesandGoblins
{
    class Shop
    {
        private Weapon[] Weapons = new Weapon[3];
        Random ShopRandom = new Random();
        Character Weaponbuyer;
        Weapon TempWeapon;

        public Shop(Character buyer)
        {
            Weaponbuyer = buyer;
            for (int i = 0; i > 3; i++)
            {
                Weapons[i] = RandomWeapon();
            }
        }
        private Weapon RandomWeapon()
        {
            int weaponnum = ShopRandom.Next(1, 5);
            switch(weaponnum)
            {
                case 1:
                    TempWeapon.WeaponType = "Dagger";
                    return TempWeapon;
                case 2:
                    TempWeapon.WeaponType = "Longsword";
                    return TempWeapon;
                case 3:
                    TempWeapon.WeaponType = "Rifle";
                    return TempWeapon;
                case 4:
                    TempWeapon.WeaponType = "Longbow";
                    return TempWeapon;
            }
            return TempWeapon;
        }

        public bool CanBuy(int num)
        {
            if (Weaponbuyer.Gold > Weapons[num].Cost)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Buy(int num)
        {
            Weaponbuyer.Gold = Weaponbuyer.Gold - Weapons[num].Cost;
            Weaponbuyer.Pickup(Weapons[num]);
            Weapons[num] = RandomWeapon();
        }

        public string DisplayWeapon(int num)
        {
            return "Buy " + Weapons[num].WeaponType + " " + Convert.ToString(Weapons[num].Cost);
        }
    }
}
