using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AnimalCount
{
    public class ScoringAnimal
    {
        public ScoringAnimal(string name, int score)
        {
            this.Score = score;
            this.Name = name;
        }

        public int Score { get; }
        public string Name { get; }
    }

    public partial class MainPage : ContentPage
    {
        int score = 0;

        List<ScoringAnimal> scoringAnimals = new List<ScoringAnimal>()
        {
            new ScoringAnimal("Sheep", 1),
            new ScoringAnimal("Cow", 3),
            new ScoringAnimal("Dog", 1),
            new ScoringAnimal("Pig", 4),
            new ScoringAnimal("Bird", 1),
            new ScoringAnimal("Cat", 2),
            new ScoringAnimal("Horse", 5),
            new ScoringAnimal("Other", 10)
        };

        public List<ScoringAnimal> ScoringAnimals { get { return this.scoringAnimals; } }

        public MainPage()
        {
            InitializeComponent();
            this.collectionView.BindingContext = this;
        }

        private void ResetScore_Clicked(object sender, EventArgs e)
        {
            score = 0;
            updateScoreDisplay();
        }

        private void updateScoreDisplay()
        {
            this.scoreLabel.Text = String.Format("{0}", this.score);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var animalName = button.Text;
            var animal = (ScoringAnimal)button.BindingContext;
            //var animal = findAnimalByName(animalName);
            score += animal.Score;
            updateScoreDisplay();
        }

        private ScoringAnimal findAnimalByName(string name)
        {
            foreach (var animal in ScoringAnimals)
            {
                if (animal.Name == name)
                    return animal;
            }

            throw new ApplicationException($"animal={name} not found");
        }
    }
}
