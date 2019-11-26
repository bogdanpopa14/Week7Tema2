namespace LinqAndLamdaExpressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;


    
    internal class Program
    {
        private static void Main(string[] args)
        {
            var allUsers = ReadUsers("users.json");
            var allPosts = ReadPosts("posts.json");

            // 1 - find all users having email ending with ".net".
            var users1 = from u in allUsers
                where u.Email.EndsWith(".net")
                select u;

            var users2 = allUsers.Where(x => x.Email.EndsWith(".net"));

            var emails = allUsers.Select(x => x.Email).ToList();


            // 2 - find all posts for users having email ending with ".net".
            var postall = from u in allUsers
                          where u.Email.EndsWith(".net")
                          select u.Id;
            var usersPost = from p in allPosts
                            where postall.Contains(p.UserId)
                            select p;



            // 3 - print number of posts for each user.
            var nrpost = from p in allPosts
                         group p by p.UserId into grp
                         select new { userID = grp.Key, nrPost = grp.Count() };
            foreach (var item in nrpost)
            {
                Console.WriteLine($"{item.userID}-{item.nrPost}");
            }

            // 4 - find all users that have lat and long negative.
            var userneg = from u in allUsers
                          where u.Address.Geo.Lat < 0 && u.Address.Geo.Lng < 0
                          select u;


            // 5 - find the post with longest body.
            var maxlongpost = (from x in allPosts select x.Body.Length).Max();
            var longpost = from p in allPosts
                           where p.Body.Length == maxlongpost
                           select p;

            var longpostID = from p in allPosts
                             where p.Body.Length == maxlongpost
                             select p.UserId;

            // 6 - print the name of the employee that have post with longest body.
            var employee = from u in allUsers
                           where longpostID.Contains(u.Id)
                           select u;
            foreach (var item in employee)
            {
                Console.WriteLine(item.Name);
            }




            // 7 - select all addresses in a new List<Address>. print the list.
            var adressUsers = from adress in allUsers
                                       select adress.Address;
            List<Address> list = new List<Address>();
            list.AddRange(adressUsers);
            foreach (var item in list)
            {
                Console.WriteLine($"{item.City}  {item.Street} {item.Suite}  {item.Zipcode} {item.Geo.Lat} {item.Geo.Lng}");
            } 

            // 8 - print the user with min lat
            var minlat = (from u in allUsers select u.Address.Geo.Lat).Min();
            var userMinLat = from u in allUsers
                             where u.Address.Geo.Lat == minlat
                             select u;

            // 9 - print the user with max long
            var maxlong = (from u in allUsers select u.Address.Geo.Lng).Max();
            var userMaxLong = from u in allUsers
                             where u.Address.Geo.Lat == maxlong
                              select u;

            // 10 - create a new class: public class UserPosts { public User User {get; set}; public List<Post> Posts {get; set} }
            //    - create a new list: List<UserPosts>
            //    - insert in this list each user with his posts only


            // 11 - order users by zip code
            var orderZip = from u in allUsers
                           orderby u.Address.Zipcode
                           select u;

            // 12 - order users by number of posts
             


            Console.ReadLine();
           
        }

        private static List<Post> ReadPosts(string file)
        {
            return ReadData.ReadFrom<Post>(file);
        }

        private static List<User> ReadUsers(string file)
        {
            return ReadData.ReadFrom<User>(file);
        }
    }

    public class  UserPosts
    { 
        public User User { get; set; }
        public List<Post> Posts { get; set; }
    }
}
