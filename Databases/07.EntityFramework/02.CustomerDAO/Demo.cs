namespace _02.CustomerDAO
{
    public class Demo
    {
        public static void Main(string[] args)
        {
            CustomerDAO.Insert("P1e", "Pesho11", "Pesho11", "Pesho1", "Pesho1", "Pesho1", "Pesho1", "Pesho1", "Pesho1", "Pesho1", "Pesho1");
            CustomerDAO.UpdateCompanyName("P1e", "Gosho");
            CustomerDAO.UpdateCompanyName("P1e", "Vankata EOOD");
            //CustomerDAO.Delete("P1e");
        }
    }
}
