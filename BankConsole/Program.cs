using BankConsole;

if(args.Length == 0)
    EmailService.SendMail();
else
    ShowMenu();

void ShowMenu()
{
    Console.Clear();
    Console.WriteLine("Selecciona una opcion: ");
    Console.WriteLine("1- Crear un usuario nuevo. ");
    Console.WriteLine("2- Eliminar un usuario existente.");
    Console.WriteLine("3- Salir. ");

    int option = 0;
    do
    {
        string input = Console.ReadLine();

        if(!int.TryParse(input, out option))
            Console.WriteLine("Debes igresar u numero (1, 2 o 3). ");
        else if (option > 3)
            Console.WriteLine("Igresar una opcion valida. ");

    }while(option == 0 || option > 3);

    switch(option)
    {
        case 1:
            CreateUser();
            break;
        case 2:
            DeleteUser();
            break;
        case 3:
            Environment.Exit(0);
            break;
    }
}

void CreateUser()
{
    bool valid = false;

    Console.Clear();
    Console.WriteLine("Ingresa la informacion del usuario: ");

    Console.Write("ID: ");
    //int ID = int.Parse(Console.ReadLine());
    int ID = 0;
    do
    {
        ID = validations.inputID();
        if(validations.usedID(ID))
        {
            Console.WriteLine("El ID ingresado ya está asociado a otro usuario, ingrese uno diferente");
            valid = false;
        }
        else
            valid = true;
    }while(!valid);
    
        


    Console.Write("Nombre: ");
    string name = Console.ReadLine();

    Console.Write("Email: ");
    //string email = Console.ReadLine();
    string email = validations.inputEmail();

    Console.Write("Saldo: ");
    //decimal balance = decimal.Parse(Console.ReadLine());
    decimal balance = validations.inputBalance();

    Console.Write("Escribe 'c' si el usuario es Cliente, o 'e' si es Empleado: ");
    //char userType = char.Parse(Console.ReadLine());
    char userType = validations.inputType();

    User newUser;

    if(userType.Equals('c'))
    {
        Console.Write("Regimen Fiscal: ");
        char taxRegime = char.Parse(Console.ReadLine());

        newUser = new Client(ID, name, email, balance, taxRegime);
    }
    else
    {
        Console.Write("Departamento: ");
        string department = Console.ReadLine();

        newUser = new Employee(ID, name, email, balance, department);

    }

    Storage.addUser(newUser);

    Console.WriteLine("Usuario creado.");
    Thread.Sleep(2000);
    ShowMenu();

}

void DeleteUser()
{
    bool valid = false;
    int ID;
    Console.Clear();

    Console.Write("Ingresa el ID del usuario a eliminar: "); 
    //int ID  = int.Parse(Console.ReadLine());
    do
    {
        ID = validations.inputID();
        if(!validations.usedID(ID))
        {
            Console.WriteLine("El ID ingresado no corresponde a ningun usuario, ingrese un ID valido");
            valid = false;
        }
        else
            valid = true;
    }while(!valid);

    string result = Storage.DeleteUser(ID);

    if(result.Equals("Success"))
    {
        Console.Write("Usuario eliminado. ");
        Thread.Sleep(2000);
        ShowMenu();
    }
}