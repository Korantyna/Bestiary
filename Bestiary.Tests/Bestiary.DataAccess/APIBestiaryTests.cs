using Bestiary.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bestiary.Tests
{
    [TestClass]
    public class APIBestiaryTests
    {
        [TestMethod]
        [TestCategory("GetBestiaryReferencesAsync Method")]
        public async Task CorrectURL_ReturnsBestiaryReferences()
        {
            using (var bestiary = new APIBestiary("https://www.dnd5eapi.co/api/monsters"))
            {
                var bestiaryReferences = await bestiary.GetBestiaryReferencesAsync();

                Assert.IsTrue(bestiaryReferences.Count > 0);
            }
        }

        [TestMethod]
        [TestCategory("GetBestiaryReferencesAsync Method")]
        [ExpectedException(typeof(HttpRequestException))]
        public async Task FalseURL_ThrowsHttpRequestException()
        {
            using (var bestiary = new APIBestiary("https://www.dnd5eapi.co/api/monsterss"))
            {
                var bestiaryReferences = await bestiary.GetBestiaryReferencesAsync();
            }
        }
    }
}