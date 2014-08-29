namespace _07.ConcurentChanges
{
    using System.Linq;

    using Northwind;

    /// <summary>
    /// Try to open two different data contexts and perform concurrent changes on the same records. 
    /// What will happen at SaveChanges()? How to deal with it?
    /// </summary>
    public class ConcurentChanges
    {
        public static void Main(string[] args)
        {
            // Link: http://msdn.microsoft.com/en-us/library/aa0416cz(v=vs.110).aspx
            using (var northwindEntities1 = new NorthwindEntities())
            {
                using (var northwindEntities2 = new NorthwindEntities())
                {
                    var territoryID = 01581;
                    var selectQuery = "SELECT * FROM Territories WHERE TerritoryID = {0}";
                    var updateQuery = @"UPDATE Territories SET RegionID = {0} WHERE TerritoryID = convert(nvarchar(20), {1}) AND TerritoryDescription = convert(nchar(50), {2}) AND RegionID = {3}";

                    var territoryFromFirstContext = northwindEntities1.Database.SqlQuery<Territory>(selectQuery, territoryID).FirstOrDefault();

                    var originalTerritoryID = territoryFromFirstContext.TerritoryID;
                    var originalTerritoryDescription = territoryFromFirstContext.TerritoryDescription;
                    var originalRegionID = territoryFromFirstContext.RegionID;

                    var newRegionID = 1;
                    northwindEntities1.Database.ExecuteSqlCommand(updateQuery, newRegionID, originalTerritoryID, originalTerritoryDescription, originalRegionID);
                    northwindEntities1.SaveChanges();

                    newRegionID = 2;
                    northwindEntities2.Database.ExecuteSqlCommand(updateQuery, newRegionID, originalTerritoryID, originalTerritoryDescription, originalRegionID);

                    northwindEntities2.SaveChanges();
                }
            }
        }
    }
}
