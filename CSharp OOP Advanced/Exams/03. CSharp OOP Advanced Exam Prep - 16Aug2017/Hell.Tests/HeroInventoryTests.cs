using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

[TestFixture]
public class HeroInventoryTests
{
    private IInventory heroInventory;

    [SetUp]
    public void TestInit()
    {
        this.heroInventory = new HeroInventory();
    }

    [Test]
    public void ConstuctorShouldInitializeHeroInventory()
    {
        // Assert
        Assert.DoesNotThrow(() => new HeroInventory(), "Constructor did not initialize HeroInventory!");
    }

    [Test]
    public void CtorInitializeEmptyCommonItems()
    {
        // Assert
        Assert.That(this.GetCommonItems().Count == 0);
    }

    [Test]
    public void CtorInitializeEmptyRecipeItems()
    {
        // Assert
        Assert.That(this.GetRecipeItems().Count == 0);
    }

    [Test]
    public void AddCommonItemShouldIncreaseItemsCollectionCount()
    {
        // Arrange
        IItem item = new CommonItem("item1", 100, 100, 100, 100, 100);

        // Act
        this.heroInventory.AddCommonItem(item);

        // Assert
        Dictionary<string, IItem> commonItems = this.GetCommonItems();
        Assert.That(commonItems.Count, Is.EqualTo(1));
    }

    [Test]
    public void AddCommonItemShouldAddItemToCommonItemsCollectionCorrectly()
    {
        // Arrange
        IItem item1 = new CommonItem("item1", 100, 100, 100, 100, 100);

        // Act
        this.heroInventory.AddCommonItem(item1);

        // Assert
        Dictionary<string, IItem> commonItems = this.GetCommonItems();
        Assert.IsTrue(commonItems.Count == 1 && commonItems.Keys.First() == "item1");
    }

    [Test]
    public void AddRecipeItemShouldIncreaseRecipeCollectionCount()
    {
        // Arrange
        List<string> requiredItems = new List<string> { "requireItem1", "requireItem2" };
        IRecipe item1 = new RecipeItem("item1", 100, 100, 100, 100, 100, requiredItems);

        // Act
        this.heroInventory.AddRecipeItem(item1);

        // Assert
        Dictionary<string, IRecipe> recipeItems = this.GetRecipeItems();
        Assert.That(recipeItems.Count, Is.EqualTo(1));
    }

    [Test]
    public void AddRecipeItemShouldAddItemToRecipeItemsCollectionCorrectly()
    {
        // Arrange
        List<string> requiredItems = new List<string> { "requireItem1", "requireItem2" };
        IRecipe item1 = new RecipeItem("item1", 100, 100, 100, 100, 100, requiredItems);

        // Act
        this.heroInventory.AddRecipeItem(item1);

        // Assert
        Dictionary<string, IRecipe> recipeItems = this.GetRecipeItems();
        Assert.IsTrue(recipeItems.Count == 1 && recipeItems.Keys.First() == "item1");
    }

    [Test]
    public void TotalStrengthBonusReturnsCorrectSumValue()
    {
        // Arrange
        IItem item1 = new CommonItem("item1", int.MaxValue, 0, 0, 0, 0);
        IItem item2 = new CommonItem("item2", int.MaxValue, 0, 0, 0, 0);
        IItem item3 = new CommonItem("item3", int.MaxValue, 0, 0, 0, 0);

        this.AddValueToCommonItems("item1", item1);
        this.AddValueToCommonItems("item2", item2);
        this.AddValueToCommonItems("item3", item3);

        // Act
        long expectedStrengthBonus = 3 * (long)int.MaxValue;
        long actualStrengthBonus = this.heroInventory.TotalStrengthBonus;

        // Assert
        Assert.That(actualStrengthBonus, Is.EqualTo(expectedStrengthBonus), "The Sum of bonuses is incorrect!");
    }

    [Test]
    public void TotalAgilityBonusReturnsCorrectSumValue()
    {
        // Arrange
        IItem item1 = new CommonItem("item1", 0, int.MaxValue, 0, 0, 0);
        IItem item2 = new CommonItem("item2", 0, int.MaxValue, 0, 0, 0);
        IItem item3 = new CommonItem("item3", 0, int.MaxValue, 0, 0, 0);

        this.AddValueToCommonItems("item1", item1);
        this.AddValueToCommonItems("item2", item2);
        this.AddValueToCommonItems("item3", item3);

        // Act
        long expectedAgilityBonus = 3 * (long)int.MaxValue;
        long actualAgilityBonus = this.heroInventory.TotalAgilityBonus;

        // Assert
        Assert.That(actualAgilityBonus, Is.EqualTo(expectedAgilityBonus), "The Sum of bonuses is incorrect!");
    }

    [Test]
    public void TotalIntelligenceBonusReturnsCorrectSumValue()
    {
        // Arrange
        IItem item1 = new CommonItem("item1", 0, 0, int.MaxValue, 0, 0);
        IItem item2 = new CommonItem("item2", 0, 0, int.MaxValue, 0, 0);
        IItem item3 = new CommonItem("item3", 0, 0, int.MaxValue, 0, 0);

        this.AddValueToCommonItems("item1", item1);
        this.AddValueToCommonItems("item2", item2);
        this.AddValueToCommonItems("item3", item3);

        // Act
        long expectedIntelligenceBonus = 3 * (long)int.MaxValue;
        long actualIntelligenceBonus = this.heroInventory.TotalIntelligenceBonus;

        // Assert
        Assert.That(actualIntelligenceBonus, Is.EqualTo(expectedIntelligenceBonus), "The Sum of bonuses is incorrect!");
    }

    [Test]
    public void TotalHitPointsBonusReturnsCorrectSumValue()
    {
        // Arrange
        IItem item1 = new CommonItem("item1", 0, 0, 0, int.MaxValue, 0);
        IItem item2 = new CommonItem("item2", 0, 0, 0, int.MaxValue, 0);
        IItem item3 = new CommonItem("item3", 0, 0, 0, int.MaxValue, 0);

        this.AddValueToCommonItems("item1", item1);
        this.AddValueToCommonItems("item2", item2);
        this.AddValueToCommonItems("item3", item3);

        // Act
        long expectedHitPointsBonus = 3 * (long)int.MaxValue;
        long actualHitPointsBonus = this.heroInventory.TotalHitPointsBonus;

        // Assert
        Assert.That(actualHitPointsBonus, Is.EqualTo(expectedHitPointsBonus), "The Sum of bonuses is incorrect!");
    }

    [Test]
    public void TotalDamageBonusReturnsCorrectSumValue()
    {
        // Arrange
        IItem item1 = new CommonItem("item1", 0, 0, 0, 0, int.MaxValue);
        IItem item2 = new CommonItem("item2", 0, 0, 0, 0, int.MaxValue);
        IItem item3 = new CommonItem("item3", 0, 0, 0, 0, int.MaxValue);

        this.AddValueToCommonItems("item1", item1);
        this.AddValueToCommonItems("item2", item2);
        this.AddValueToCommonItems("item3", item3);

        // Act
        long expectedDamageBonus = 3 * (long)int.MaxValue;
        long actualDemageBonus = this.heroInventory.TotalDamageBonus;

        // Assert
        Assert.That(actualDemageBonus, Is.EqualTo(expectedDamageBonus), "The Sum of bonuses is incorrect!");
    }

    [Test]
    public void AddingItemsAccordingTheListOfRequiredItemsOfARecipeShouldCombineTheRecipeIntoANewCommonItem()
    {
        // Arrange
        List<string> requiredItems = new List<string>(new string[] { "f", "s", "t" });
        IRecipe recipe = new RecipeItem("recipe", 45, 86, 26, 34, 75, requiredItems);
        IItem firstItem = new CommonItem("f", 10, 15, 13, 12, 14);
        IItem secondfirstItem = new CommonItem("s", 11, 14, 12, 13, 15);
        IItem thirdItem = new CommonItem("t", 13, 12, 15, 14, 10);       

        // Act 
        this.heroInventory.AddRecipeItem(recipe);
        this.heroInventory.AddCommonItem(firstItem);
        this.heroInventory.AddCommonItem(secondfirstItem);
        this.heroInventory.AddCommonItem(thirdItem);

        // Assert
        IDictionary<string, IItem> collectionItems = this.GetCommonItems();
        Assert.That(collectionItems.Count, Is.EqualTo(1), "Collection of Common Items is not correct");
        Assert.That(collectionItems.First().Key, Is.EqualTo(recipe.Name), "Collection of Common Items is not correct");
    }

    [Test]
    public void AddingRecipeWithRequiredItemsAlreadyAvailableInTheInventoryShouldAutomaticallyTransformItToANewCommonItem()
    {
        // Arrange
        List<string> requiredItems = new List<string>(new string[] { "f", "s", "t" });
        IRecipe recipe = new RecipeItem("recipe", 45, 86, 26, 34, 75, requiredItems);
        IItem firstItem = new CommonItem("f", 10, 15, 13, 12, 14);
        IItem secondfirstItem = new CommonItem("s", 11, 14, 12, 13, 15);
        IItem thirdItem = new CommonItem("t", 13, 12, 15, 14, 10);

        // Act         
        this.heroInventory.AddCommonItem(firstItem);
        this.heroInventory.AddCommonItem(secondfirstItem);
        this.heroInventory.AddCommonItem(thirdItem);
        this.heroInventory.AddRecipeItem(recipe);

        // Assert
        IDictionary<string, IItem> collectionItems = this.GetCommonItems();
        Assert.That(collectionItems.Count, Is.EqualTo(1), "Collection of Common Items is not correct");
        Assert.That(collectionItems.First().Key, Is.EqualTo(recipe.Name), "Collection of Common Items is not correct");
    }

    // Helper mthods
    private Dictionary<string, IItem> GetCommonItems()
    {
        FieldInfo[] fields = this.heroInventory
                            .GetType()
                            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                            .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(ItemAttribute)))
                            .ToArray();

        Dictionary<string, IItem> commonItems = (Dictionary<string, IItem>)fields[0].GetValue(this.heroInventory);
        return commonItems;
    }

    private Dictionary<string, IRecipe> GetRecipeItems()
    {
        FieldInfo[] fields = this.heroInventory
                            .GetType()
                            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                            .Where(f => f.CustomAttributes.Any() == false)
                            .ToArray();

        Dictionary<string, IRecipe> recipeItems = (Dictionary<string, IRecipe>)fields[0].GetValue(this.heroInventory);
        return recipeItems;
    }

    private void AddValueToCommonItems(string itemName, IItem item)
    {
        FieldInfo[] fields = this.heroInventory
                            .GetType()
                            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                            .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(ItemAttribute)))
                            .ToArray();

        Dictionary<string, IItem> commonItems = (Dictionary<string, IItem>)fields[0].GetValue(this.heroInventory);
        commonItems[itemName] = item;
    }
}