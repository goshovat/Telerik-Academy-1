namespace Chef
{
    using System;

    public class Chef
    {
        public void Cook()
        {
            Potato potato = this.GetPotato();
            this.Peel(potato);
            this.Cut(potato);

            Bowl bowl;
            bowl = this.GetBowl();
            bowl.Add(potato);

            Carrot carrot = this.GetCarrot();
            this.Peel(carrot);
            this.Cut(carrot);
            bowl.Add(carrot);

            this.Serve();
        }

        private Bowl GetBowl()
        {
            Bowl bowl = new Bowl();
            return bowl;
        }

        private Potato GetPotato()
        {
            Potato potato = new Potato();
            return potato;
        }

        private Carrot GetCarrot()
        {
            Carrot carrot = new Carrot();
            return carrot;
        }

        private void Peel(Vegetable vegetable)
        {
            vegetable.Peel();
        }

        private void Cut(Vegetable vegetable)
        {
            vegetable.Cut();
        }

        private void Serve()
        {
            Console.WriteLine("Here you are your meal. Bon Appetit!");
        }
    }
}
