using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class ImprovedInteractionManger : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemTypeString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemTypeString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemTypeString, itemLocation);
                    break;
                default:
                    item = base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                    break;
            }

            return item;
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    person = base.CreatePerson(personTypeString, personNameString, personLocation);
                    break;
            }
            return person;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    location = base.CreateLocation(locationTypeString, locationName);
                    break;
            }
            return location;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(actor, commandWords);
                    break;
                case "craft":
                    HandleCraftInteraction(actor, commandWords);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }


        private void HandleCraftInteraction(Person actor, string[] commandWords)
        {
            var inventory = actor.ListInventory();

            bool hasIron = false;
            bool hasWood = false;

            foreach (var item in inventory)
            {
                if (item is Iron)
                {
                    hasIron = true;
                }
                else if (item is Wood)
                {
                    hasWood = true;
                }
            }

            if (commandWords[2] == "armor" && hasIron)
            {
                this.AddToPerson(actor, new Armor(commandWords[3], actor.Location));
            }
            else if (commandWords[2] == "weapon" && hasIron && hasWood)
            {
                this.AddToPerson(actor, new Weapon(commandWords[3], "weapon", actor.Location));
            }
        }

        private void HandleGatherInteraction(Person actor, string[] commandWords)
        {
            if (actor.Location.LocationType == LocationType.Forest)
            {
                bool hasWeapon = false;
                var inventory = actor.ListInventory();

                foreach (var item in inventory)
                {
                    if (item is Weapon)
                    {
                        hasWeapon = true;
                        break;
                    }
                }

                if (hasWeapon)
                {
                    Wood wood = new Wood(commandWords[2], "wood", actor.Location);
                    this.AddToPerson(actor, wood);
                }
            }
            else if (actor.Location.LocationType == LocationType.Mine)
            {
                bool hasArmor = false;
                var inventory = actor.ListInventory();

                foreach (var item in inventory)
                {
                    if (item is Armor)
                    {
                        hasArmor = true;
                        break;
                    }
                }

                if (hasArmor)
                {
                    Iron iron = new Iron(commandWords[2], "iron", actor.Location);
                    this.AddToPerson(actor, iron);
                }
            }
        }
    }
}
