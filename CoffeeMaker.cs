namespace HighRiskCafe
{
    internal class CoffeeMaker
    {
        Random random = new Random();
        string ctype = "";
        List<string> coffeeTypes = new List<string>() { "Espresso", "Americano", "Macchiato", "Cortado", "Cappucino", "Mocca" };
        int[] steps = new int[6];
        List<string> failedSteps = new List<string>();

        private void AskForCoffee()
        {
            Console.WriteLine("Welcome to the high risk café! Would you like a coffee?");
            string answer = Console.ReadLine();
            while (!answer.Equals("yes"))
            {
                Console.WriteLine("Sorry, we only have coffee, try again!");
                answer = Console.ReadLine();
            }
        }

        private void AskForCoffeeType()
        {
            Console.WriteLine("What coffee type would you like?");
            string answer = Console.ReadLine();
            bool a = ValidateCoffeeType(answer);
            while (!a)
            {
                Console.WriteLine("That coffee type does not exist, try again");
                answer = Console.ReadLine();
            }
        }

        private bool ValidateCoffeeType(string c)
        {
            bool b = false;
            if (!coffeeTypes.Contains(c))
            {
                b = false;
            }
            else if (coffeeTypes.Contains(c))
            {
                ctype = c;
                b = true;
            }
            return b;
        }


        private void PutCoffeeInMachine()
        {
            bool b = CalculateSuccess();
            if (!b)
            {

                steps[1] = 1;

            }
            else if (b)
            {
                steps[1] = 0;
            }

        }

        private int PutWaterInMachine()
        {
            bool b = CalculateSuccess();
            if (!b)
            {
                steps[2] = 2;
            }
            else if (b)
            {
                steps[2] = 0;
            }
            return 0;
        }

        private int PlaceCupinMachine()
        {
            bool b = CalculateSuccess();
            if (!b)
            {
                steps[3] = 3;
            }
            else if (b)
            {
                steps[3] = 0;
            }
            return 0;
        }

        private void StartMachine()
        {
            bool b = CalculateSuccess();
            if (!b)
            {
                steps[4] = 4;
            }
            else if (b)
            {
                steps[4] = 0;
            }

        }

        private void ServeCoffeeToGuest()
        {
            bool b = CalculateSuccess();
            if (!b)
            {
                steps[5] = 5;
            }
            else if (b)
            {
                steps[5] = 0;
            }

        }

        private bool CalculateSuccess()
        {
            int randomNumber = random.Next(1, 100);
            bool IsSucess;
            if (randomNumber > 0 && randomNumber <= 20)
            {
                IsSucess = false;
            }
            else
            {
                IsSucess = true;
            }
            return IsSucess;
        }

        private List<string> LookForFailedSteps()
        {
            for (int i = 0; i < steps.Length; i++)
            {
                if (steps[i] != 0)
                {
                    failedSteps.Add(i.ToString());
                }
            }
            return failedSteps;
        }

        public void MakeCoffee()
        {

            AskForCoffee();
            AskForCoffeeType();

            // Each step is performed and either 0 (=success) or 1 (=error) is added to the steps array 
            PutCoffeeInMachine();
            PutWaterInMachine();
            PlaceCupinMachine();
            StartMachine();
            ServeCoffeeToGuest();
            List<string> fails = LookForFailedSteps();

            bool done;
            if (failedSteps.Count > 0)
            {
                done = false;

            }
            else
            {
                done = true;
            }

            Coffee c = new Coffee(done, ctype, fails);
            Console.WriteLine($"Coffee is done: {done}, Coffee type: {ctype}");
            Console.WriteLine("Number of fails: " + failedSteps.Count);
            Console.WriteLine("Fails at steps: ");
            PrintFails();
            Console.WriteLine("");
            Console.WriteLine("Step 1: put coffee in machine");
            Console.WriteLine("Step 2: put water in machine");
            Console.WriteLine("Step 3: place cup in machine");
            Console.WriteLine("Step 4: Start Machine");
            Console.WriteLine("Step 5: Serve coffee");
        }

        private void PrintFails()
        {
            foreach (var s in failedSteps)
            {
                Console.WriteLine(s);
            }
        }
    }


}


