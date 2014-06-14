namespace TradeAndTravel
{
    public class ExtendedInteractionManager : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    item = base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                    break;
            }

            return item;
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

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(commandWords, actor);
                    break;
                case "craft":
                    HandleCraftInteraction(commandWords, actor);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        private void HandleCraftInteraction(string[] commandWords, Person actor)
        {
            //A Person can craft items, provided he has some items in his inventory
            //A Person should be able to craft Weapons and Armor
            //Crafting an Armor requires that the Person has Iron in his inventory
            //Results in adding an Armor item in the Person’s inventory
            //Crafting a Weapon requires that the Person has Iron and Wood in his inventory
            //Syntax: Joro craft newItemName - gathers an item, naming it newItemName if the Person Joro has the necessary

            string newItemType = commandWords[2];
            string newItemName = commandWords[3];

            bool hasIron = false;
            bool hasWood = false;

            foreach (Item item in actor.ListInventory())
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

            if (newItemType == "armor" && hasIron)
            {
                Armor armor = new Armor(newItemName, null);
                AddToPerson(actor, armor);
            }

            if (newItemType == "weapon" && hasIron && hasWood)
            {
                Weapon weapon = new Weapon(newItemName, null);
                AddToPerson(actor, weapon);
            }
        }

        private void HandleGatherInteraction(string[] commandWords, Person actor)
        {
            //Gathering means a Person takes an item from a special location
            //A Person should be able to gather from mines and from forests
            //A Person can gather from a forest only if he has a Weapon in his inventory
            //Gathering from a forests results in adding a Wood item in the Person’s inventory
            //A Person can gather from a mine only if he has an Armor in his inventory
            //Gathering from a mine results in adding an Iron item in the Person’s inventory
            //Syntax: Joro gather newItemName – gathers an item, naming it newItemName if the Person Joro is at a mine or forest, and respectively has an Armor or Weapon

            string newItemName = commandWords[2];

            if (actor.Location.LocationType == LocationType.Forest)
            {
                foreach (Item item in actor.ListInventory())
                {
                    if (item is Weapon)
                    {
                        Wood wood = new Wood(newItemName, null);
                        AddToPerson(actor, wood);
                        break;
                    }
                }
            }
            else if (actor.Location.LocationType == LocationType.Mine) 
            {
                foreach (Item item in actor.ListInventory())
                {
                    if (item is Armor)
                    {
                        Iron iron = new Iron(newItemName, null);
                        AddToPerson(actor, iron);
                        break;
                    }
                }
            }
        }
    }
}
