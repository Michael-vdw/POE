﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesandGoblins
{
    [Serializable]
    abstract class Character : Tile
    {
        private protected string lootString = "";
        private protected int hp, maxHP, damage, gold;
        private protected char symbol;
        private protected Weapon equippedWeapon;
        private protected Tile[] vision = new Tile[8];

        public int HP { get => hp; set => hp = value; }
        public int MaxHP { get => maxHP; set => maxHP = value; }
        public int Damage { get => damage; set => damage = value; }
        public int Gold { get => gold; set => gold = value; }
        public char Symbol { get => symbol; set => symbol = value; }
        public Weapon EquippedWeapon { get => equippedWeapon; set => equippedWeapon = value; }
        public Tile[] Vision { get => vision; set => vision = value; }
        public string LootString { get => lootString; set => lootString = value; }
        public enum Movement
        {
            NoMove,
            Up,
            Down,
            Left,
            Right
        }

        public Character(int x, int y, char symbol) : base(x, y)
        {
            
        }

        public virtual void Attack(Character target)
        {
            target.hp -= EquippedWeapon.Damage;
        }

        public void Loot(Character target)
        {
            Gold += target.gold;
            if (EquippedWeapon.WeaponType == "BareHanded" && target.EquippedWeapon.WeaponType != "BareHanded" && ThisTile != TileType.Mage)
            {
                EquippedWeapon = target.EquippedWeapon;
                LootString = "Just Looted " + EquippedWeapon.WeaponType;
            }
        }

        public bool IsDead()
        {
            if (hp < 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool CheckRange(Character target)
        {
            if (DistanceTo(target) <= EquippedWeapon.Range)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int DistanceTo(Character target)
        {
            return Math.Abs(target.X - X) + Math.Abs(target.Y - Y);
        }

        public void Move(Movement move)
        {
            if (move == Movement.Up)
            {
                y--;
            }
            if (move == Movement.Down)
            {
                y++;
            }
            if (move == Movement.Left)
            {
                x--;
            }
            if (move == Movement.Right)
            {
                x++;
            }
        }

        public void Pickup(Item i)
        {
            Random goldRandom = new Random();
            if (i.thisTile == Tile.TileType.Weapon)
            {
                Equip((Weapon)i);
            }
            if (i.thisTile == Tile.TileType.Gold)
            {
                Gold += goldRandom.Next(1,6);
            }
        }

        public abstract Movement ReturnMove(Movement move);

        public abstract override string ToString();

        private void Equip(Weapon w)
        {
            EquippedWeapon = w;
        }
    }

    [Serializable]
    class Hero : Character
    {
        public Hero(int x, int y, int hp) : base(x, y, 'H')
        {
            this.hp = hp;
            this.maxHP = hp;
            this.damage = 2;
            thisTile = TileType.Hero;
            EquippedWeapon = new MeleeWeapon(MeleeWeapon.Types.BareHanded);
        }

        public override Movement ReturnMove(Movement move)
        {
            if (vision[Convert.ToInt32(move)].thisTile != TileType.Empty)
            {
                return Movement.NoMove;
            }
            else
            {
                return move;
            }
        }

        public override string ToString()
        {
            return "Player stats: \nHP:" + HP + "/" + MaxHP + "\nDamage:" + Damage + "\nCoordinates:" + "[" + x + "," + y + "]" + "\nGold:" + Gold + "\n" + LootString + "Current Weapon:" + EquippedWeapon.WeaponType + "\nWeapon Range:" + EquippedWeapon.Range + "\nWeapon Damage:" + EquippedWeapon.Damage + "\nWeapon Durability:" + EquippedWeapon.Durability;
        }
    }
}
