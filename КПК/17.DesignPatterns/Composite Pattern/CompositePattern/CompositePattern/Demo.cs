namespace CompositePattern
{
    using System;

    public class Demo
    {
        public static void Main(string[] args)
        {
            Boss theBigBoss = new Boss("Nasser Al-Khelaifi", "The Big Boss");

            Boss chiefExecutiveOfficer = new Boss("Jack Leon", "CEO");

            Boss manager = new Boss("Laurent Blanc", "Manager");

            Person scoutGK = new Person("Ji Yu Ney", "Scout GK");

            chiefExecutiveOfficer.Add(scoutGK);

            Person scoutST = new Person("Nasakoto Yakata", "Scout ST");

            chiefExecutiveOfficer.Add(scoutST);

            Person lionelMessi = new Person("Lionel Messi", "Footballer");

            manager.Add(lionelMessi);

            Person neymar = new Person("Neymar Jr.", "Footballer");

            manager.Add(neymar);

            Person buffon = new Person("Gianluigi Buffon", "Footballer");

            manager.Add(buffon);

            theBigBoss.Add(chiefExecutiveOfficer);
            theBigBoss.Add(manager);

            theBigBoss.Work(1);
        }
    }
}
