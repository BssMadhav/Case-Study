using System;
using TechTalk.SpecFlow;
using Project_2.CommonMethodObjects;

namespace Project_2.Step_Definition
{
    [Binding]
    public class EmployeeSteps
    {
        EmployeeObjects obj = new EmployeeObjects();
        [When(@"User sends Get request")]
        public void WhenUserSendsGetRequest()
        {
            obj.GetListOfUserRequest();
        }
        
        [When(@"User sends post Create")]
        public void WhenUserSendsPostCreate()
        {
            obj.Postcreatenewemployee();
        }
        
        [When(@"user sends the delete request")]
        public void WhenUserSendsTheDeleteRequest()
        {
            obj.DeleteRequest();
        }
        
        [Then(@"User should be able to verify result successfully")]
        public void ThenUserShouldBeAbleToVerifyResultSuccessfully()
        {
            obj.verifyGetResult();
        }
        
        [Then(@"User should be able to verify Id and see success")]
        public void ThenUserShouldBeAbleToVerifyIdAndSeeSuccess()
        {
            obj.VerifyPostResult();
        }
        
        [Then(@"user should be able to delete the details and see success")]
        public void ThenUserShouldBeAbleToDeleteTheDetailsAndSeeSuccess()
        {
            obj.VerifyDeleteRequest();
        }
    }
}
