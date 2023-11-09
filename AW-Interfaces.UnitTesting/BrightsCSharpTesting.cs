namespace AW_Interfaces.UnitTesting
{
    public class Tests
    {
        //Arrange
        public BrightsCSharp brightsCSharp = new();

        [SetUp]
        public void Setup()
        {
            brightsCSharp = new();
            brightsCSharp.SignUpForCourse("Jarnathan");
            brightsCSharp.SignUpForCourse("J'son");
        }

        [Test]
        public void SignUpForCourse_OneStringIn_StringAddedToList()
        {
            //Arrange
            string expected = "Joolee Andrüs";
            brightsCSharp.SignUpForCourse(expected);

            //Act
            var actual = brightsCSharp.GetCourseParticipantName(brightsCSharp.GetCourseParticipantNames().Count - 1);

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetCourseParticipantName_OneIntegerIn_ReturnCorrectName()
        {
            //Arrange
            string expected = "Jarnathan";

            //Act
            var actual = brightsCSharp.GetCourseParticipantName(0);

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetCourseParticipantNames_CheckIfListIsNull_ReturnTrueIfListExists()
        {
            //Arrange
 
            //Act
            bool actual = brightsCSharp.GetCourseParticipantNames() != null;
            //Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void LoadFromFile_GetNamesFromFile_ReturnExpectedName()
        {
            brightsCSharp = new();
            brightsCSharp.LoadFromFile(@"C:\Users\RenéeJønsberg\source\repos\Module2-AW-Interfaces\AW-Interfaces\CourseParticipants.txt");
            var actual = brightsCSharp.GetCourseParticipantName(0);
            var expected = "Jim";
            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(brightsCSharp.CourseYear, Is.EqualTo(1991));
        }
    }
}