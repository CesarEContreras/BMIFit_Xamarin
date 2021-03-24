using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AppCenter.Analytics;
using Xamarin.Forms;

namespace BMIFit.ViewModels
{
    public class CalculatorViewModel : BaseViewModel
    {
        public Command CalculateBMICommand { get; set; }

        public CalculatorViewModel()
        {
            Title = "Calculator";
            CalculateBMICommand = new Command(() => ExecuteCalculateCommand());
        }

        float bmi;
        public float BMI
        {
            get { return bmi; }
            set { SetProperty(ref bmi, value); }
        }

        int feet;
        public int Feet
        {
            get { return feet; }
            set { SetProperty(ref feet, value); }
        }

        int inches;
        public int Inches
        {
            get { return inches; }
            set { SetProperty(ref inches, value); }
        }

        float weight;
        public float Weight
        {
            get { return weight; }
            set { SetProperty(ref weight, value); }
        }

        string bmiCategory;
        public string BMICatergory
        {
            get { return bmiCategory; }
            set { SetProperty(ref bmiCategory, value); }
        }

        private void ExecuteCalculateCommand()
        {
            IsBusy = true;

            try
            {
                var heightInches = (float)((feet * 12) + inches);
                BMI = (703 * weight) / (heightInches * heightInches);
                BMICatergory = GetBodyMassIndexCategory(BMI);
                Analytics.TrackEvent($"BMI Calculated Successfully");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Analytics.TrackEvent(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private string GetBodyMassIndexCategory(float bmi)
        {
            if (bmi <= 18.5)
                return "Underweight";
            else if (bmi >= 18.5 && bmi <= 24.9)
                return "Normal";
            else if (bmi >= 25 && bmi <= 29.9)
                return "Overweight";
            else return"Obese";
        }
    }
}