// See https://aka.ms/new-console-template for more information

using Exercise_DB.Classes;

List <Client> ClientList = new List<Client> ();
List<Technician> TechnicianList = new List<Technician>();
List<Photocopier> PhotocopierList = new List<Photocopier>();

bool exit = false;

while (!exit)
{
    ShowMenu();
    int choice = ReadNumericInput(1, 4);

    switch (choice)
    {
        case 1:
            CreateClient();
            break;
        case 2:
            CreateTechnician();
            break;
        case 3:
            CreatePhotocopier();
            break;
        case 4:
            exit = true;
            Console.WriteLine("Exit...");
            break;
        default:
            Console.WriteLine("Option invalid. Choose again.");
            break;
    }

    if (!exit)
    {
        Console.WriteLine("\nPress a key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
}


static void ShowMenu()
{
    Console.WriteLine("=== Main Menu ===");
    Console.WriteLine("1. add Client");
    Console.WriteLine("2. add Technician");
    Console.WriteLine("3. add Photocopier");
    Console.WriteLine("4. Exit");

}

static int ReadNumericInput(int min, int max)
{
    int result = 0;
    string input;
    bool isValid;

    do
    {
        Console.Write($"Your choice ({min}-{max}) : ");
        input = Console.ReadLine();

        // Verify if the input is empty or only space
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("The input cannot be empty");
            isValid = false;
            continue;
        }

        // Try to convert to int
        if (!int.TryParse(input, out result))
        {
            Console.WriteLine("Input a valid number");
            isValid = false;
            continue;
        }

        // Verify if number is in the valid range
        if (result < min || result > max)
        {
            Console.WriteLine($"The input must be between {min} and {max}.");
            isValid = false;
            continue;
        }

        isValid = true;

    } while (!isValid);

    return result;
}


void CreateClient()
{
    Console.Write("Nom :");
    String name = Console.ReadLine();
    Console.Write("Prenom :");
    String surname = Console.ReadLine();
    Console.Write("Email :");
    String email = Console.ReadLine();
    Console.Write("Tel :");
    int tel = int.Parse(Console.ReadLine());
    Console.Write("Adresse :");
    String address = Console.ReadLine();

    Client entry = new Client(name,surname,email,tel,address);

    AddListClient(entry);
}

void AddListClient(Client newClient)
{
    ClientList.Add(newClient);
    Console.WriteLine("\n");
    Console.WriteLine("List of clients :");
    foreach (var client in ClientList)
    {
        Console.WriteLine("client n° " + client.Id_client + " name : " + client.Name + " " + client.Surname + " address : " +
            client.Address + " mail : " + client.Email + " telephone : " + client.Telephone);
    }
}

void CreateTechnician()
{
    Console.Write("Nom :");
    String name = Console.ReadLine();
    Console.Write("Prenom :");
    String surname = Console.ReadLine();
    Console.Write("Tel :");
    int tel = int.Parse(Console.ReadLine());

    Technician entry = new Technician(name, surname, tel);

    AddListTechnician(entry);
}

void AddListTechnician(Technician newTechnician)
{
    TechnicianList.Add(newTechnician);
    Console.WriteLine("\n");
    Console.WriteLine("List of technicians :");
    foreach (var technician in TechnicianList)
    {
        Console.WriteLine("technician n° " + technician.Id_technician + " name : " + technician.Name + " " + technician.Surname + " telephone : " + technician.Telephone);
    }
}

void CreatePhotocopier()
{
    Console.Write("Model :");
    String model = Console.ReadLine();
    Console.Write("Est defaillant (o/n) :");
    bool isFailing;
    String isFailingInput = Console.ReadLine();
    if (isFailingInput == "o")
    {
        isFailing = true;
    }
    else
    {
        isFailing = false;
    }

    Photocopier entry = new Photocopier(model, isFailing);

    AddListPhotocopier(entry);
}

void AddListPhotocopier(Photocopier newPhotocopier)
{
    PhotocopierList.Add(newPhotocopier);
    Console.WriteLine("\n");
    Console.WriteLine("List of photocopiers :");
    foreach (var photocopier in PhotocopierList)
    {
        Console.WriteLine("photocopier n° " + photocopier.Id_photocopier + " model : " + photocopier.Model + " is failing : " + photocopier.Is_failing);
    }
}