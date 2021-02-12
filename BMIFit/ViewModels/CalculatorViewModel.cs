using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BMIFit.ViewModels
{
    public class CalculatorViewModel : BaseViewModel
    {  
        public Command CalculateBMICommand { get; set; }
        
        public CalculatorViewModel()
        {
            Title = "Calculator";
            CalculateBMICommand = new Command(async () => await ExecuteCalculateCommand());
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

        private async Task ExecuteCalculateCommand()
        {
            IsBusy = true;

            try
            {
                var heightInches = (float)((feet * 12) + inches);
                BMI = (703 * weight) / (heightInches * heightInches);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
