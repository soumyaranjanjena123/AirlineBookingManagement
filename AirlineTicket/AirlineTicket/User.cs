using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AirlineTicket
{
    
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }  
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        // Constructor to initialize User
        public User(string username, string password, string email, string firstName,string lastName,string address)
        {
            Username = username;
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Address = address;



        }

        public void DisplayUserInfo()
        {
            Console.WriteLine($"Username: {Username}, Full name: {FirstName} {LastName}");
        }
        public static void saveUsers(List<User> users, string pathname)
        {
            var jsonData = JsonSerializer.Serialize(users);

            File.WriteAllText(pathname, jsonData);


        }

        public static List<User> LoadUsers(string pathname)
        {
            if (!File.Exists(pathname))
            
                return new List<User>();
            var jsonData = File.ReadAllText(pathname);

            return JsonSerializer.Deserialize<List<User>>(jsonData);
            
        }
    }


}
