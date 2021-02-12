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

        string gender = string.Empty;
        public string Gender
        {
            get { return gender; }
            set { SetProperty(ref gender, value); }
        }

        int age;
        public int Age
        {
            get { return age; }
            set { SetProperty(ref age, value); }
        }

        float height;
        public float Height
        {
            get { return height; }
            set { SetProperty(ref height, value); }
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
                CalculateBMI();
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

        private void CalculateBMI()
        {
            float weightInKg = (float)(weight * 0.45359237);
            float heightInMeters = height / 100;

            BMI = weightInKg / (heightInMeters * heightInMeters);
        }
    }
}
