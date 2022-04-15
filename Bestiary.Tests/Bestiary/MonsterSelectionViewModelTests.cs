using Bestiary.DataAccess;
using Bestiary.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Events;
using Prism.Services.Dialogs;

namespace Bestiary.Tests
{
    [TestClass]
    public class MonsterSelectionViewModelTests
    {
        private Mock<IEventAggregator> _eventAggregatorMock = null!;
        private Mock<IDialogService> _dialogServiceMock = null!;
        private Mock<IBestiary> _bestiaryMock = null!;

        private MonsterSelectionViewModel _monsterSelectionViewModel = null!;

        [TestInitialize]
        public void TestInitialize()
        {
            _eventAggregatorMock = new Mock<IEventAggregator>();
            _dialogServiceMock = new Mock<IDialogService>();
            _bestiaryMock = new Mock<IBestiary>();

            _monsterSelectionViewModel = new MonsterSelectionViewModel(_bestiaryMock.Object, _eventAggregatorMock.Object, _dialogServiceMock.Object);
        }

        [TestMethod]
        [TestCategory("LoadDataCommand")]
        public void CallsGetBestiaryReferencesAsync()
        {
            var monsters = new BestiaryReference[] { new BestiaryReference("Aboleth", "/api/monsters/aboleth") };
            _bestiaryMock.SetupSequence(x => x.GetBestiaryReferencesAsync()).ReturnsAsync(monsters);

            _monsterSelectionViewModel.LoadDataCommand.Execute();

            _bestiaryMock.Verify(x => x.GetBestiaryReferencesAsync(), Times.Once);
        }

        [TestMethod]
        [TestCategory("LoadDataCommand")]
        public void LoadsMonsters()
        {
            var monsters = new BestiaryReference[] { new BestiaryReference("Aboleth", "/api/monsters/aboleth") };
            _bestiaryMock.SetupSequence(x => x.GetBestiaryReferencesAsync()).ReturnsAsync(monsters);

            _monsterSelectionViewModel.LoadDataCommand.Execute();

            CollectionAssert.AreEqual(monsters, _monsterSelectionViewModel.Monsters);
        }
    }
}