namespace DungeonsAndCodeWizards.Entities.Characters.Factory
{
    using System;
    using System.Linq;
    using System.Reflection;    
    using DungeonsAndCodeWizards.Entities.Characters;
    using DungeonsAndCodeWizards.Entities.Characters.Enums;
    using DungeonsAndCodeWizards.Static_data;

    public class CharacterFactory
    {
        public Character CreateCharacter(string fact, string characterType, string name)
        {
            bool isFaction = Enum.TryParse(typeof(Faction), fact, out object faction);
            if (!isFaction)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidFactionException, fact));
            }

            object[] parametersForConstruction = new object[] { name, (Faction)faction };

            Type typeOfCommand = Assembly
                                    .GetExecutingAssembly()
                                    .GetTypes()
                                    .FirstOrDefault(type => type.Name.Equals(characterType));

            if (typeOfCommand == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }

            Character character = (Character)Activator.CreateInstance(typeOfCommand, parametersForConstruction);
            return character;                                   
        }
    }
}
