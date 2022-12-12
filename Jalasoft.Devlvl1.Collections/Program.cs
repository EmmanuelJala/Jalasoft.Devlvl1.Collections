// Constantes
string[] dishes = new string[] { "Spaghetti", "Lasagna", "Pizza", "Calzone" };
double[] dishesPrices = new double[] { 10.99, 12, 99, 8, 6 };
string[] beverages = new string[] { "Soda", "Wine", "Beer" };
double[] beveragesPrices = new double[] { 6.5, 9, 7.5 };
string[] PayMethods = new string[] { "Cash", "Card" };
string[] orderLabels = new string[] { "Delivering Order", "Customer", "Order", "Total Cost", "Payment Method" };

//Variables
Queue<int> dishPointer = new Queue<int>();
Queue<int> beveragesPointer = new Queue<int>();

Queue<int> orderNumbers = new Queue<int>();
Queue<string> costumerNames = new Queue<string>();
Queue<string> dishesQueue = new Queue<string>();
Queue<int> dishesQuantity = new Queue<int>();
Queue<string> beveragesQueue = new Queue<string>();
Queue<int> beveragesQuantity = new Queue<int>();

Queue<double> totalPrices = new Queue<double>();


// Ejecución

// Menú de bienvenida
welcomeMenu();

//Funciones
void welcomeMenu()
{
    int orderNum = 300;
    int orderCount = 0;
    int option = 0;

    if (orderCount < 5)
    {
        Console.WriteLine("Welcome to your order assistant, please select an option:");
        Console.WriteLine("1. Order \n2. Finish \n3. Exit");
        option = Convert.ToInt32(Console.ReadLine());
    }
    else option = 2;

        switch (option)
        {
            case 1:
                Console.WriteLine("Elegiste tomar tu orden");
                TakeOrder(orderNum);
                Console.WriteLine("\n");
                orderNum++;
                orderCount++;
                welcomeMenu();
                break;
            case 2:
                Console.WriteLine("Elegiste Procesar las ordenes");
                PrintOrders();
                Console.WriteLine("\n");
                welcomeMenu();
                break;
            case 3:
                break;
            default:
                Console.WriteLine("Esa opción no existe, intenta de nuevo");
                Console.WriteLine("\n");
                welcomeMenu();
                break;
        }    
    return;
}

void TakeOrder(int orderNum)
{
    bool dishSelection = true;
    bool beverageSelection = true;
    int dishCount = 0;
    int beverageCount = 0;
    double Total = 0;
    Console.WriteLine("Please introduce your name:");
    costumerNames.Enqueue(Console.ReadLine());

    while (dishSelection)
    {
        Console.WriteLine("Select the dish you want to order:");
        ShowOptions(dishes, dishesPrices);
        int option = Convert.ToInt32(Console.ReadLine()) - 1;
        dishesQueue.Enqueue(dishes[option]);

        Console.WriteLine($"Insert the quantity of {dishes[option]} dishes that you want:");
        option = Convert.ToInt32(Console.ReadLine());
        dishesQuantity.Enqueue(option);
        Total = Total + option * dishesPrices[Array.IndexOf(dishes, dishesQueue.Peek())];
        dishCount++;
        Console.WriteLine("Do you want to order another dish from the menu?");
        Console.WriteLine("1. Yes \n2.No, thanks");
        if (Console.ReadLine() == "2")
        { 
            dishSelection = false;
            dishPointer.Enqueue(dishCount);
            totalPrices.Enqueue(Total);
        }
        
    }

    

    while (beverageSelection)
    {
        Console.WriteLine("Select the beverage you want to order:");
        ShowOptions(beverages, beveragesPrices);
        int option = Convert.ToInt32(Console.ReadLine()) - 1;
        beveragesQueue.Enqueue(beverages[option]);

        Console.WriteLine($"Insert the quantity of {beverages[option]} glasses that you want:");
        option = Convert.ToInt32(Console.ReadLine());
        beveragesQuantity.Enqueue(option);
        Total = Total + option * beveragesPrices[Array.IndexOf(beverages, beveragesQueue.Peek())];
        beverageCount++;

        Console.WriteLine("Do you want to order another beverage from the menu?");
        Console.WriteLine("1. Yes \n2.No, thanks");
        if (Console.ReadLine() == "2") 
        { 
            beverageSelection = false;
            beveragesPointer.Enqueue(beverageCount);
            totalPrices.Enqueue(Total);
        }        
    }
    
    

    Console.WriteLine($"Your number order is: {orderNum}");
    orderNumbers.Enqueue(orderNum); 
}

void ShowOptions(string[] options, double[] prices)
{
    for (var i = 0; i < options.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {options[i]}  ${prices[i]}");
    }
}

void PrintOrders(){
    int limit = orderNumbers.Count();

    for (int i = 0; i < limit; i++)
    {
        Console.WriteLine("The orders are:");
        Console.WriteLine($"Order #{orderNumbers.Dequeue()}");
        Console.WriteLine($"Costumer: {costumerNames.Dequeue()}");
        Console.WriteLine("Dishes: ");

        int pointer = dishPointer.Dequeue();
        for (int j = 0; j < pointer; j++)
        {
            Console.WriteLine($"{dishesQuantity.Dequeue()} dishes of ......{dishesQueue.Dequeue()}");
        }
        pointer = beveragesPointer.Dequeue();
        for (int j = 0; j < pointer; j++)
        {
            Console.WriteLine($"{beveragesQuantity.Dequeue()} glasses of ......{beveragesQueue.Dequeue()}");
        }
        Console.WriteLine($"Total cost:......{totalPrices.Dequeue() + totalPrices.Dequeue()}");
        Console.WriteLine("\n\n");
    }    
}