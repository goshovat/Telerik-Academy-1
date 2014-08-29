namespace _11.Groups
{
    using System;
    using System.Linq;
    using System.Transactions;

    using Group;

    /// <summary>
    /// Create a database holding users and groups. Create a transactional EF based method 
    /// that creates an user and puts it in a group "Admins". In case the group "Admins" do 
    /// not exist, create the group in the same transaction. If some of the operations fail 
    /// (e.g. the username already exist), cancel the entire transaction.
    /// </summary>
    public class GroupsDemo
    {
        public static void Main(string[] args)
        {
            InsertUserToAddmins("Ivaylo Kenov");
        }

        private static void InsertUserToAddmins(string userName)
        {
            using (var scope = new TransactionScope())
            {
                using (GroupsEntities context = new GroupsEntities())
                {
                    var adminGroup = new Group { GroupName = "Admins" };

                    if (context.Groups.Count(x => x.GroupName == "Admins") == 0)
                    {
                        context.Groups.Add(adminGroup);
                        context.SaveChanges();
                        scope.Complete();
                    }
                    else
                    {
                        if (context.Users.Count(x => x.UserName == userName) > 0)
                        {
                            Console.WriteLine("User already exists.");
                            scope.Dispose();
                        }

                        var currentgroup = context.Groups
                            .Where(x => x.GroupName == "Admins").First();

                        var newUser = new User()
                        {
                            UserName = userName,
                            GroupID = currentgroup.GroupID
                        };

                        context.Users.Add(newUser);
                        context.SaveChanges();
                        scope.Complete();
                    }
                }
            }
        }
    }
}
