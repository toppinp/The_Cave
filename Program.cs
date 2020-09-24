using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace TheCave
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "";
            int hitPoints = 0;
            int damage = 0;
            string command = "";
            string command2;
            int rat = 0;
            string verb = "";
            string monster = "";
            int monsterDamage = 0;

            do
            {
                name = getName();

                sayHello(name);

                while (true)
                {
                    command = caveEntrance();
                    command.ToUpper();
                    if (command == "GO INTO CAVE" || command == "GO IN CAVE" || command == "CAVE" || command == "GO CAVE" || command == "IN CAVE")
                    {
                        hitPoints = 10;
                        rat = 10;
                        damage = 5;
                        command2 = caveRoom1();
                        break;
                    }
                    else if (command == "GO HOME" || command == "HOME")
                    {
                        earlyHome();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Command.  Please try again.");
                        Console.WriteLine("");
                    }
                }

                damage = caveRoom1Selection(command2, damage);

                caveRoom2();

                do
                {
                    command = prompt();
                    (rat, hitPoints) = ratEncounter(command, damage, rat, verb, monsterDamage, hitPoints, monster);


                } while (rat > 0 && hitPoints > 0);

                if (hitPoints <= 0)
                {
                    youHaveDied();
                }

                Console.WriteLine("");
                Console.WriteLine("This is as far as I have gotten.  What do you think?");
                Console.WriteLine("");
                System.Environment.Exit(1);

            } while (hitPoints > 0);


        }



        static string getName()
        {
            string name = "";
            Console.Write("Hello adventurer! What is your name: ");
            name = Console.ReadLine();
            Console.WriteLine("");
            return name;
        }

        static void sayHello(string name)
        {
            Console.WriteLine($"Hello {name}.  Let's begin, shall we?");
            Console.WriteLine("");
        }

        static string caveEntrance()
        {
            string answer = "";
            Console.WriteLine
                ("You find yourself in front of a gaping, dark hole in the mountain just outside of town.  Having grown up here, you are well aware that this hole leads into " +
                "a cave that (to your knowledge) has never been fully mapped.  Lucy stands behind you, a sly grin on her face.  You know that she fully expects you to chicken out" +
                " and not go into the cave.  Then she can talk about how she called it, and all of her friends will taunt you relentlessly.  What do you do?");
            Console.WriteLine("");
            Console.Write("GO INTO CAVE or GO HOME: ");
            answer = Console.ReadLine();
            Console.WriteLine("");

            return answer;
        }

        static void earlyHome()
        {
            Console.WriteLine("You decide that you don't care what Lucy and her dumb friends think.  You are not about to break you neck in a dark smelly cave just for their entertainment!" +
                "  Instead, you turn from the cave, stare straight ahead, and ignore the taunts from the group.  You head home to do your chores and get a jump on that math homework.");
            Console.WriteLine("");
            Console.WriteLine("THE END");
            System.Environment.Exit(1);
            return;
        }

        static string caveRoom1()
        {
            string answer = "";
            Console.WriteLine("You walk carefully into the cave, letting your eyes adjust to the abrupt loss of sunlight.  Even so, you nearly trip over a large rock on the cave floor." +
                "  As you steady yourself against the cave wall, you see something completely unexpected sitting about 20 feet away, propped up against the opposing wall; a metal sword!" +
                "  You blink a few times before coming to the conclusion that it is actually there, and not some stress-induced hallucination.  You don't know what is further into the cave." +
                "  What do you want to do?");
            Console.WriteLine("");
            Console.Write("PICK UP ROCK or TAKE SWORD or DO NOTHING: ");
            answer = Console.ReadLine();
            Console.WriteLine("");
            return answer;
        }
        
        static int caveRoom1Selection(string command2, int damage)
        {
            do
            {
                command2.ToUpper();
                if (command2 == "PICK UP ROCK" || command2 == "ROCK" || command2 == "TAKE ROCK")
                {
                    takeRock();
                    damage += 1;
                    command2 = "HIT";
                    continue;
                }
                else if (command2 == "TAKE SWORD" || command2 == "SWORD" || command2 == "PICK UP SWORD")
                {
                    takeSword();
                    damage += 3;
                    command2 = "HIT";
                    continue;
                }
                else if (command2 == "DO NOTHING")
                {
                    doNothing();
                    command2 = "HIT";
                    continue;
                }
                else
                {
                    Console.WriteLine("Invalid Command.  Please try again.");
                    Console.WriteLine("");
                    command2 = caveRoom1();
                }
            } while (command2 != "HIT");
            return damage;
        }
        static void takeRock()
        {
            Console.WriteLine("");
            Console.WriteLine("You pick up a rock the size of a softball, thinking that it could cause a bit of damage if you ran into something in the cave.  You then decide to travel further in.");
            Console.WriteLine("");
            Console.WriteLine("Press ENTER to continue.");
            Console.ReadLine();
        }

        static void takeSword()
        {
            Console.WriteLine("");
            Console.WriteLine("You tenatively touch the sword, as if it might bite you if you move too fast.  \"What is this even doing in here?\", you think.  As you grab the hilt and hold the longsword up," +
                "it feels somehow right in your hand, as if it was yours at some point.  The large piece of metal gives you an unreasonable confidence.  So, you head further into the cave.");
            Console.WriteLine("");
            Console.WriteLine("Press ENTER to continue.");
            Console.ReadLine();
        }
        static void doNothing()
        {
            Console.WriteLine("");
            Console.WriteLine("You decide that you would probably end up hurting yourself if you started carrying around possible weapons, especially that sword.  \"Why is it even in here?!\", you think." +
                "  Well, the only way is further into the cave, or you could run right out and face Lucy and her friends, like a chicken....  No, into the cave we go.");
            Console.WriteLine("");
            Console.WriteLine("Press ENTER to continue.");
            Console.ReadLine();
        }

        static void caveRoom2()
        {
            Console.WriteLine("");
            Console.WriteLine("As you step further into the cave, you see a large rat scurries across the cave floor.  However, it stops once it sees you!  The rat doesn't seem afraid.  In fact," +
                " it starts to slowly move towards you, the hair on it's back raising!  You need to do something quick, before it tries to make you it's lunch!  What do you do?");
            Console.WriteLine("");
        }

        static (int, int) ratEncounter(string command, int damage, int rat, string verb, int monsterDamage, int hitPoints, string monster)
        {
            command.ToUpper();
            if (command == "ATTACK" && damage == 5)
            {
                int strike = attack(1, damage + 1);
                rat -= strike;
                verb = "throw a punch at";
                largeRatDamage(verb, strike, rat);
                if (rat <= 0)
                {
                    return (rat, hitPoints);
                }
                else
                {
                    monsterDamage = monsterAttack(1, 6);
                    hitPoints -= monsterDamage;
                    ratAttacks(monsterDamage);
                    return (rat, hitPoints);
                }
            }
            else if (command == "ATTACK" && damage == 6)
            {
                int strike = attack(4, damage + 1);
                rat -= strike;
                verb = "throw your rock at";
                largeRatDamage(verb, strike, rat);
                if (rat <= 0)
                {
                    return (rat, hitPoints);
                }
                else
                {
                    monsterDamage = monsterAttack(1, 6);
                    hitPoints -= monsterDamage;
                    ratAttacks(monsterDamage);
                    return (rat, hitPoints);
                }
            }
            else if (command == "ATTACK" && damage == 8)
            {
                int strike = attack(5, damage + 1);
                rat -= strike;
                verb = "swing your sword at";
                largeRatDamage(verb, strike, rat);
                if (rat <= 0)
                {
                    return (rat, hitPoints);
                }
                else
                {
                    monsterDamage = monsterAttack(1, 6);
                    hitPoints -= monsterDamage;
                    ratAttacks(monsterDamage);
                    return (rat, hitPoints);
                }
            }
            else if (command == "RUN")
            {
                monster = "large rat";
                int run = monsterAttack(1, 10);
                hitPoints -= youRun(run, monster);
                return (rat, hitPoints);
            }
            else
            {
                Console.WriteLine("Invalid Command.  Please try again.");
                Console.WriteLine("");
                return (rat, hitPoints);
            }

        }


        static string prompt()
        {
            string answer = "";
            Console.Write("ATTACK or RUN: ");
            answer = Console.ReadLine();
            return answer;
        }

        static int attack(int min, int max)
        {
            Random rnd = new Random();
            int damage = rnd.Next(min, max);
            return damage;
        }

        static int monsterAttack(int min, int max)
        {
            Random rnd = new Random();
            int attack = rnd.Next(min, max);
            return attack;
        }

        static void ratAttacks(int damage)
        {
            Console.WriteLine("");
            Console.WriteLine($"The large rat lunges at you, striking you for {damage} points of damage!");
            Console.WriteLine("");
            return;
        }

        static int youRun(int run, string monster)
        {
            Random rnd = new Random();
            int attack = rnd.Next(1, 11);
            Console.WriteLine("");
            Console.WriteLine($"You attempt to run.  In your haste, the {monster} stikes out!  It hits you for {run}!");
            Console.WriteLine("");
            return attack;
        }

        static void largeRatDamage(string verb, int strike, int rat)
        {
            Console.WriteLine("");
            Console.WriteLine($"You {verb} the large rat, striking it for {strike} damage!");
            if (rat > 0 && rat > 5)
            {
                Console.WriteLine("");
                Console.WriteLine("The large rat hisses at you in pain!  It closes in for a ferocious strike!");
                Console.WriteLine("");
                Console.WriteLine("Press ENTER to continue.");
                Console.ReadLine();
                return;
            }
            else if (rat > 0 && rat <= 5)
            {
                Console.WriteLine("");
                Console.WriteLine("The large rat seams terribly hurt!  However, it quickly regains its awareness, and it launches itself towards you to strike!");
                Console.WriteLine("");
                Console.WriteLine("Press ENTER to continue.");
                Console.ReadLine();
                return;
            }
            else if (rat <= 0)
            {
                Console.WriteLine("");
                Console.WriteLine("You have killed the rat!  Congratulations!  You live to fight another day!");
                Console.WriteLine("");
                Console.WriteLine("Press ENTER to continue.");
                Console.ReadLine();
                return;
            }
        }


        static void youHaveDied()
        {
            Console.WriteLine("");
            Console.WriteLine("As you feel the last moments of your life slip by, you have time to think of those chores that will go undone, and of your dear math homework that will be late....");
            Console.WriteLine("");
            Console.WriteLine("THE END");
            System.Environment.Exit(1);
        }
    }
}
