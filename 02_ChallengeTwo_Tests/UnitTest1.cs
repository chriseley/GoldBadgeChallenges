using Xunit;

 [TestClass]
    public class RepositoryTests
    {
        private ClaimRepository _repo;
        private Claim newClaim;


        [TestInitialize]
        public void Seed()
        {
            _repo = new ClaimRepository();
            newClaim = new Claim();
        }

        [TestMethod]
        public void AddClaimToQueueTest()
        {
            _repo.AddClaimToQueue(newClaim);

            int expected = 1;
            int actual = _repo.GetAllClaims().Count;

            Assert.AreEqual(actual, expected);
        }
    }