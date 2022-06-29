using System;
using TechTalk.SpecFlow;
using BigSmallSpecFlow.CommonMethodObjects;

namespace BigSmallSpecFlow.StepDefinition
{
    [Binding]
    public class AddToCartSteps
    {
        AddToCartObjects obj = new AddToCartObjects();
        SearchProductObject obj1 = new SearchProductObject();
        WishListObject obj2 = new WishListObject();

        [When(@"User searches for an item and selects an item")]
        public void WhenUserSearchesForAnItemAndSelectsAnItem()
        {
            obj1.EnterProductToSearch();
            obj2.selectItem();

        }

        [When(@"User clicks on Add to Cart")]
        public void WhenUserClicksOnAddToCart()
        {
            obj.AddItemToCart();
        }
        
        [Then(@"User should be able to view the item in shopping cart")]
        public void ThenUserShouldBeAbleToViewTheItemInShoppingCart()
        {
            obj.VerifyCartItem();
        }
    }
}
