namespace RefactorStatements
{
    using System;
    using Chef;

    public class Demo
    {
        private const int MIN_X = -123;
        private const int MAX_X = 123;
        private const int MIN_Y = -123;
        private const int MAX_Y = 123;

        public static void Main(string[] args)
        {
            RefactorFirstIf();
            Console.WriteLine();
            RefactorSecondIf();
        }

        public static void RefactorFirstIf()
        {
            Potato potato = new Potato();
            potato.Peel();

            if (potato != null)
            {
                // This is how i thing is corret to be
                if (potato.HasBeenPeeled || potato.IsFresh)
                {
                    Cook(potato);
                }

                /*
                // This is one of the De Morgan’s laws
                if(!(potato.HasNotBeenPeeled || potato.IsRotten))
                {
                    Cook(potato);
                }
                */
            }
        }

        public static void RefactorSecondIf()
        {
            int x = 0;
            int y = 0;
            bool shouldVisitCell = true;
            bool isXInField = (MIN_X <= x) && (x <= MAX_X);
            bool isYInField = (MIN_Y <= y) && (y <= MAX_Y);
            bool isPointInField = isXInField && isYInField;

            if (isPointInField && shouldVisitCell)
            {
                VisitCell();
            }
        }

        private static void VisitCell()
        {
            Console.WriteLine("Cell is visited");
        }

        private static void Cook(Potato potato)
        {
            Console.WriteLine("Cooking {0}", potato);
        }
    }
}
