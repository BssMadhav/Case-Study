using System;
using TechTalk.SpecFlow;
using BigSmallSpecFlow.CommonMethodObjects;


namespace BigSmallSpecFlow.StepDefinition
{
    [Binding]
    public class WishListSteps
    {
        WishListObject obj = new WishListObject();
        SearchProductObject obj1 = new SearchProductObject();

        [When(@"User searches a valid product and User press Enter")]
        public void WhenUserSearchesAValidProductAndUserPressEnter()
        {
            obj1.EnterProductToSearch();
        }

        [When(@"User selects the item")]
        public void WhenUserSelectsTheItem()
        {
            obj.selectItem();
        }

        [When(@"User clicks on add to wishlist")]
        public void WhenUserClicksOnAddToWishlist()
        {
            obj.AddToWishlist();
        }

        [When(@"User clicks on wish list")]
        public void WhenUserClicksOnWishList()
        {
            obj.ClickWishList();
        }

        [Then(@"User should be able to view the item added to the wish list")]
        public void ThenUserShouldBeAbleToViewTheItemAddedToTheWishList()
        {
            obj.VerifyWishlistItem();
        }

    }
}


