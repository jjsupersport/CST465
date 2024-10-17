using System;
using System.Collections.Generic;
using Lab4.Objects;

    public static class ChoreWorkforceExtensions
    {
        public static void AddLaborer(this ChoreWorkforce workforce, string name, int age, int difficulty, string chore)
        {
            ChoreLaborer newLaborer = new ChoreLaborer
            {
                Name = name,
                Age = age,
                Difficulty = difficulty,
            };

            workforce.Laborers.Add(newLaborer);
        }

        private static readonly List<string> randomNames = new List<string>
        {
            "Allen", "Bob", "Coraline", "Devin", "Evan",
            "Frank", "Grace", "Hank", "Ivy", "Jack", "Kate"
        };

        public static void AddRandomLaborer(this ChoreWorkforce workforce)
        {
            Random random = new Random();
            string randomName = randomNames[random.Next(randomNames.Count)];
            int randomAge = random.Next(1, 19); 
            int randomDifficulty = random.Next(1, 11); 

            if (randomDifficulty == 10)
            {
                workforce.Laborers.Add(null);
            }
            else
            {
                workforce.Laborers.Add(new ChoreLaborer
                {
                    Name = randomName,
                    Age = randomAge,
                    Difficulty = randomDifficulty
                });
            }
        }

        public static void AddRandomLaborers(this ChoreWorkforce workforce, int count)
        {
            for (int i = 0; i < count; i++)
            {
                workforce.AddRandomLaborer();
            }
        }
    }