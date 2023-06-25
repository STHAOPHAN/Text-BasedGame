using System;
using System.Timers;

namespace Text_BasedGame.Models
{
    public class Creature
    {
        public string name { get; set; }
        public int level { get; set; }
        public float maxHealth { get; set; }
        public float curHealth { get; set; }
        public int damage { get; set; }
        public int armor { get; set; }
        public float attackSpeed { get; set; }

        private System.Timers.Timer attackTimer;
        private bool canAttack = true;

        public Creature()
        {
        }

        public Creature(string name, int level, float maxHealth, float curHealth, int damage, int armor, float attackSpeed)
        {
            this.name = name;
            this.level = level;
            this.maxHealth = maxHealth;
            this.curHealth = curHealth;
            this.damage = damage;
            this.armor = armor;
            this.attackSpeed = attackSpeed;

            attackTimer = new System.Timers.Timer(attackSpeed * 1000);
            attackTimer.Elapsed += AttackTimer_Elapsed;
            attackTimer.AutoReset = false;
        }

        public virtual void Attack(Creature target)
        {
            if (canAttack)
            {
                Console.WriteLine($"{name} attacks {target.name}!");

                // Logic xử lý tấn công
                // ...

                canAttack = false;
                attackTimer.Start();
            }
        }

        private void AttackTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            canAttack = true;
        }
    }
}
