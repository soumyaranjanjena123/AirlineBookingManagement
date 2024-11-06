using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineTicket
{
    public class Registration
    {
        private const string pathname = "C:\\Users\\soumy\\source\\repos\\AirlineTicket\\AirlineTicket\\User.json";

        public void RegisterUser() 
        {
            List<User> users = User.LoadUsers(pathname);
            string username;

            //validation for username
             Console.WriteLine("Enter a UserName");
             username = Console.ReadLine();

            if (string.IsNullOrEmpty(username)) {
                Console.WriteLine("Username can't be empty");
            }
            else if(users.Exists(u=>u.Username.Equals(username,StringComparison.OrdinalIgnoreCase)))
                {
                Console.WriteLine("Username already registred");
                    return;
                }

            //validation for password
            string password;

            

            Console.WriteLine("Enter a PassWord");
             password = Console.ReadLine();
            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Password can't be empty");
                return;

            }
            

            Console.WriteLine("Enter your email");
            string email = Console.ReadLine();
            if (string.IsNullOrEmpty(email)) 
            {
                Console.WriteLine("Email can't be Empty");
            }
            
            else if(!email.Contains("@") || !email.Contains("."))
            {
                Console.WriteLine("Please enter a valid mail");
            }
           

            Console.WriteLine("Enter your First Name");
            string firstName = Console.ReadLine();
            if (string.IsNullOrEmpty(firstName))
            {
                Console.WriteLine("firstName can't be Empty");
                return;
            }

            Console.WriteLine("Enter your lastName");
            string lastName = Console.ReadLine();
            if (string.IsNullOrEmpty(lastName))
            {
                Console.WriteLine("lastname can't be Empty");
            }

            Console.WriteLine("Enter your Address");
            string address = Console.ReadLine();

            User newUser = new User(username, password,email,firstName,lastName,address);

            //List<User> user = User.LoadUsers(pathname);

            users.Add(newUser);

           User.saveUsers(users, pathname);


            Console.WriteLine("User redg. successfull");
        }

    }
}
