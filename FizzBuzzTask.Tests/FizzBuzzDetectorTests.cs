namespace FizzBuzzTask.Tests
{
    public class FizzBuzzDetectorTests
    {
        private FizzBuzzDetector _detector;

        [SetUp]
        public void Setup()
        {
            _detector = new FizzBuzzDetector();
        }

        [Test]
        public void ExampleInput_ShouldMatchExpectedCount()
        {
            string input = "Mary had a little lamb\n" +
                           "Little lamb, little lamb\n" +
                           "Mary had a little lamb\n" +
                           "It's fleece was white as snow";

            var result = _detector.GetOverlappings(input);

            Assert.That(result.Output, Does.Contain("FizzBuzz"));
            Assert.That(result.Count, Is.EqualTo(9));
        }

        [Test]
        public void ShortInput_NoReplacements()
        {
            string input = "One two";
            var result = _detector.GetOverlappings(input);

            Assert.That(result.Output, Is.EqualTo("One two"));
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void ThirdWord_ShouldBeFizz()
        {
            string input = "One two three";
            var result = _detector.GetOverlappings(input);

            Assert.That(result.Output, Is.EqualTo("One two Fizz"));
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void FifthWord_ShouldBeBuzz()
        {
            string input = "One two three four five";
            var result = _detector.GetOverlappings(input);

            Assert.That(result.Output, Is.EqualTo("One two Fizz four Buzz"));
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void FifteenthWord_ShouldBeFizzBuzz()
        {
            string input = string.Join(" ", Enumerable.Repeat("word", 15));
            var result = _detector.GetOverlappings(input);

            Assert.That(result.Output, Does.Contain("FizzBuzz"));
            Assert.That(result.Count, Is.EqualTo(7)); // replacements at 3,5,6,9,10,12,15

        }

        [Test]
        public void NullInput_ShouldThrow()
        {
            Assert.Throws<ArgumentNullException>(() => _detector.GetOverlappings(null));
        }

        [Test]
        public void TooShortInput_ShouldThrow()
        {
            string input = "short"; // length = 5
            Assert.Throws<ArgumentException>(() => _detector.GetOverlappings(input));
        }

        [Test]
        public void TooLongInput_ShouldThrow()
        {
            string input = new string('a', 101); // length = 101
            Assert.Throws<ArgumentException>(() => _detector.GetOverlappings(input));
        }

        [Test]
        public void MinLengthInput_ShouldWork()
        {
            string input = "1234567"; // exactly length 7
            var result = _detector.GetOverlappings(input);
            Assert.That(result.Output, Is.EqualTo("1234567"));
            Assert.That(result.Count, Is.EqualTo(0));
        }
    }
}
