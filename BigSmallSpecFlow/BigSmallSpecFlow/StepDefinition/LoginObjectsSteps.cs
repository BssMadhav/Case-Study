using System;
using TechTalk.SpecFlow;
using BigSmallSpecFlow.CommonMethodObjects;

namespace BigSmallSpecFlow.StepDefinition
{
    [Binding]
    public class LoginObjectsSteps
    {
        LoginObjects obj = new LoginObjects();
        [Given(@"User is on homepage")]
        public void GivenUserIsOnHomepage()
        {
            obj.VerifyHome();
        }
        
        [When(@"User clicks on sign in")]
        public void WhenUserClicksOnSignIn()
        {
            obj.ClickSignIn();
        }
        
        [When(@"User enters the Invalid Email (.*)")]
        public void WhenUserEntersTheInvalidEmailAsdfgGmail_Com(string email)
        {
            obj.EnterEmail(email);
        }
        
        [When(@"User enters the Invalid Password (.*)")]
        public void WhenUserEntersTheInvalidPasswordAhsjsjsjsk(string password)
        {
            obj.EnterPassword(password);
        }
        
        [When(@"User clicks on the Sign In button")]
        public void WhenUserClicksOnTheSignInButton()
        {
            obj.ClickSignInBtn();
        }
      
        [Then(@"An error message should be displayed")]
        public void ThenAnErrorMessageShouldBeDisplayed()
        {
            obj.VerifyInvalidInput();
        }
    }
}
