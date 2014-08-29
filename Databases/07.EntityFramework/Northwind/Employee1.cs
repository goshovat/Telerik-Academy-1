namespace Northwind
{
    using System;
    using System.Linq;
    using System.Data.Linq;

    /// <summary>
    /// By inheriting the Employee entity class create a class which allows employees 
    /// to access their corresponding territories as property of type EntitySet<T>.
    /// </summary>
    public partial class Employee
    {
        private EntitySet<Territory> entityTerritories;

        public EntitySet<Territory> EntityTerritories
        {
            get
            {
                var employeeTerritories = this.Territories;
                EntitySet<Territory> entityTerritories = new EntitySet<Territory>();
                entityTerritories.AddRange(employeeTerritories);
                return entityTerritories;
            }
        }
    }
}
