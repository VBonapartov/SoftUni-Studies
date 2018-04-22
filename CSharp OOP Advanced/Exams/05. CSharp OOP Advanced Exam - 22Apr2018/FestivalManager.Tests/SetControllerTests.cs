namespace FestivalManager.Tests
{
    using System;
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;
    using NUnit.Framework;

    [TestFixture]
	public class SetControllerTests
    {
        private IStage stage;
        private ISetController setController;
        
        [SetUp]
        public void TestInit()
        {
            this.stage = new Stage();
            this.setController = new SetController(this.stage);
        }

		[Test]
	    public void PerformSetsShouldReturnDidNotPerformIfTheSetCannotBePerformed()
	    {
            // Arrange
            ISet set1 = new Short("Set1");
            this.stage.AddSet(set1);

            IPerformer performer = new Performer("Ivan", 20);
            this.stage.AddPerformer(performer);
            set1.AddPerformer(performer);
            
            ISong song = new Song("Song1", new TimeSpan(0, 1, 2));
            set1.AddSong(song);

            // Act
            string result = this.setController.PerformSets();

            // Assert
            Assert.That(result, Is.EqualTo("1. Set1:\r\n-- Did not perform"));
        }

        [Test]
        public void PerformSetsShouldReturnSetSuccessfulIfTheSetCanBePerformed()
        {
            // Arrange
            ISet set1 = new Short("Set1");
            this.stage.AddSet(set1);

            IPerformer performer = new Performer("Ivan", 20);
            performer.AddInstrument(new Guitar());
            this.stage.AddPerformer(performer);
            set1.AddPerformer(performer);

            ISong song = new Song("Song1", new TimeSpan(0, 1, 2));
            set1.AddSong(song);

            // Act
            string result = this.setController.PerformSets();

            // Assert            
            Assert.That(result, Is.EqualTo($"1. {set1.Name}:\r\n-- 1. {song.Name} ({this.FormatTime(song.Duration)})\r\n-- Set Successful"));
        }

        [Test]
        public void PerformSetsShouldWearDownInstrument()
        {
            // Arrange
            ISet set1 = new Short("Set1");
            this.stage.AddSet(set1);

            IPerformer performer = new Performer("Ivan", 20);
            IInstrument instrument = new Guitar();
            performer.AddInstrument(instrument);
            this.stage.AddPerformer(performer);
            set1.AddPerformer(performer);

            ISong song = new Song("Song1", new TimeSpan(0, 1, 2));
            set1.AddSong(song);

            // Act
            string result = this.setController.PerformSets();
            
            // Assert
            double actualWear = instrument.Wear;
            Assert.That(actualWear, Is.EqualTo(40));
        }

        private string FormatTime(TimeSpan ts)
        {
            int mins = (ts.Days * 1440) + (ts.Hours * 60) + ts.Minutes;
            int secs = ts.Seconds;

            return $"{mins:D2}:{secs:D2}";
        }
    }
}