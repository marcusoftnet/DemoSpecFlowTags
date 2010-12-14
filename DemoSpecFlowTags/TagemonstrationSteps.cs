using System.Linq;
using Should.Fluent;
using TechTalk.SpecFlow;

namespace DemoSpecFlowTags
{
    [Binding]
    public class TagemonstrationSteps
    {
        private bool _beforeScenarioWithNoTags = false;
        private bool _testTag1 = false;
        private bool _testTag2 = false;
        private bool _testTag3 = false;
        private bool _testTags = false;

        [BeforeScenario]
        public void BeforeScenarioWith_0Tags()
        {
            _beforeScenarioWithNoTags = true;
        }

        [BeforeScenario("testTag1")]
        public void BeforeScenario_testTag1()
        {
            _testTag1 = true;
        }

        [BeforeScenario("testTag2")] 
        public void BeforeScenario_testTag2()
        {
            _testTag2 = true;
        }

        [BeforeScenario("testTag3")]
        public void BeforeScenario_testTag3()
        {
            _testTag3 = true;
        }

        [BeforeScenario("testTag1", "testTag2", "testTag3")]
        public void BeforeScenario_testTags()
        {
            _testTags = true;
        }

        [When(@"I run the scenario")]
        public void WhenIRunTheScenario() 
        {
            // Nothing to do here
        }

        [Given(@"that my scenario has no tags")]
        public void GivenThatMyScenarioHasNoTags()
        {
            ScenarioContext.Current.ScenarioInfo.Tags.Should().Be.Null();
        }

        [Given(@"that my scenario has 1 tag")]
        public void GivenThatMyScenarioHas1Tag()
        {
            ScenarioContext.Current.ScenarioInfo.Tags.Should().Not.Be.Null();
            ScenarioContext.Current.ScenarioInfo.Tags.ToList().Count.Should().Equal(1);
        }

        [Given(@"that my scenario has 3 tags")]
        public void GivenThatMyScenarioHasMultipleTags()
        {
            ScenarioContext.Current.ScenarioInfo.Tags.Should().Not.Be.Null();
            ScenarioContext.Current.ScenarioInfo.Tags.ToList().Count.Should().Equal(3);
        }

        [Then(@"before scenario hook without tag is run")]
        public void ThenBeforeScenarioHookWithoutTagIsRun()
        {
            _beforeScenarioWithNoTags.Should().Be.True();

            _testTag1.Should().Be.False();
            _testTag2.Should().Be.False();
            _testTag3.Should().Be.False();
            _testTags.Should().Be.False();
        }

        [Then(@"before scenario hook with the tags is run")]
        public void ThenBeforeScenarioHookWithTheTagsIsRun()
        {
            _beforeScenarioWithNoTags.Should().Be.True();
            _testTag1.Should().Be.True();
            _testTag2.Should().Be.True();
            _testTag3.Should().Be.True();
            _testTags.Should().Be.True();
        }

        [Then(@"before scenario hook with the tag is run")]
        public void ThenBeforeScenarioHookWithTheTagIsRun()
        {
            _beforeScenarioWithNoTags.Should().Be.True();
            _testTag1.Should().Be.True();
            _testTags.Should().Be.True();


            _testTag2.Should().Be.False();
            _testTag3.Should().Be.False();
        }

        
    }
}
