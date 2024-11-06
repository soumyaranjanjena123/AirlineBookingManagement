using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineTicket
{
    public class Login
    {
        private const string pathname = "C:\\Users\\soumy\\source\\repos\\AirlineTicket\\AirlineTicket\\User.json";

        public User CurrentUser { get; private set; }


        public void LoginUser()
        {
            Console.WriteLine("Enter your username");
            string userName = Console.ReadLine();

            Console.WriteLine("Enter yor password");
            string password = Console.ReadLine();


            //Load existing users
            List<User> users = User.LoadUsers(pathname);

            //Check if user exists and password matches
            User foundUser = users.Find(u=>u.Username.Equals(userName,StringComparison.OrdinalIgnoreCase));

            if (foundUser != null && foundUser.Password == password)
            {
                CurrentUser = foundUser;
                Console.WriteLine($"Welcome, { foundUser.FirstName}!");
            }
            else
            {
                Console.WriteLine("Invalid username or password. Please try again");
            }
        }
    }
}
