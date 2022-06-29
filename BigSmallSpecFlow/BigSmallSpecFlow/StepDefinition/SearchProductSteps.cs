using System;
using TechTalk.SpecFlow;
using BigSmallSpecFlow.CommonMethodObjects;

namespace BigSmallSpecFlow.StepDefinition
{
    [Binding]
    public class SearchProductSteps
    {
        SearchProductObject obj = new SearchProductObject();
        [When(@"User enters product name in search bar and User press Enter")]
        public void WhenUserEntersProductNameInSearchBarAndUserPressEnter()
        {
            obj.EnterProductToSearch();
        }
        
        [Then(@"Products related the searched product should be displayed")]
        public void ThenProductsRelatedTheSearchedProductShouldBeDisplayed()
        {
            obj.VerifyProductSearch();
        }
    }
}
