using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace BankConsole;

public static class validations
{
    static string filePath = AppDomain.CurrentDomain.BaseDirectory + @"\users.json";

    public static bool usedID(int id)
    {
        string usersInFile = "";
        var listUsers = new List<User>();
        bool exists = false;

        if(File.Exists(filePath))
            usersInFile = File.ReadAllText(filePath);
        
        var listObjects = JsonConvert.DeserializeObject<List<object>>(usersInFile);

        if(listObjects == null)
            return exists;
        
        foreach (object obj in listObjects)
        {
            User newUser;
            JObject user = (JObject)obj;
            if(user.ContainsKey("TaxRegime"))
                newUser = user.ToObject<Client>();
            else
                newUser = user.ToObject<Employee>();


            if(newUser.GetID().Equals(id))
            {
                exists = true;
                break;
            }
            else
                exists = false;
        }

        return exists;
    }

    public static int inputID()
    {
        string input = "";
        int output = 0;
        bool valid = false;

        do
        {
            input = Console.ReadLine();
            if(!int.TryParse(input, out output) || int.Parse(input) < 0)
                Console.WriteLine("Ingrese un ID valido (entero positivo)");
            else
                valid = true;
            

        }while(!valid);

        return output;
    }

    public static decimal inputBalance()
    {
        string input = "";
        decimal output;
        bool valid = false;

        do
        {
            input = Console.ReadLine();
            if(!decimal.TryParse(input, out output) || decimal.Parse(input) < 0)
                Console.WriteLine("Ingrese un monto valido (entero positivo)");
            else
                valid = true;
            

        }while(!valid);

        return output;
    }

    public static string inputEmail()
    {
        string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        Regex reg = new Regex(pattern);
        string input = "";
        bool valid = false;

        do
        {
            input = Console.ReadLine();
            if(reg.IsMatch(input))
                valid = true;
            else
                Console.WriteLine("formato de correo incorrecto, ingrese uno valido");

        }while(!valid);

        return input;
    }

    public static char inputType()
    {
        string input;
        char output; 
        bool valid = false;

        do
        {
            input = Console.ReadLine();
            if(!char.TryParse(input, out output) || (char.Parse(input) != 'c' && char.Parse(input) != 'e'))
                Console.WriteLine("Ingrese un caracter valido 'c' / 'e' ");
            else
                valid = true;

        }while(!valid);

        return output;
    }
    
}