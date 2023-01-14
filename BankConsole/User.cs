using Newtonsoft.Json;
namespace BankConsole;

public class User
{
    [JsonProperty]
    protected int ID { get; set; }
    [JsonProperty]
    protected string Name { get; set; }
    [JsonProperty]
    protected string Email { get; set; }
    [JsonProperty]
    protected decimal Balance { get; set; }
    [JsonProperty]
    protected DateTime RegisterDate { get; set; }



    public User(){ }

    public User(int id, string name, string email, decimal balance){
        this.ID = id;
        this.Name = name;
        this.Email = email;
        this.RegisterDate = DateTime.Now;
    }

    public int GetID()
    {
        return ID;
    }
    public DateTime GetRegisterDate()
    {
        return RegisterDate;
    }

    public virtual void setBalance(decimal amount)
    {
        this.Balance = amount;
    }

    public virtual string ShowData(){

        return $" ID: {this.ID}, Nombre: {this.Name}, Email: {this.Email}, Saldo: {this.Balance}, Fecha de registro: {this.RegisterDate.ToShortDateString()} ";
    }
    public virtual string ShowData(string initialMessage){

        return $"{initialMessage} -> Nombre: {this.Name}, Email: {this.Email}, Saldo: {this.Balance}, Fecha de registro: {this.RegisterDate} ";
    }


}