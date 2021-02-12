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

        int height;
        public int Height
        {
            get { return height; }
            set { SetProperty(ref height, value); }
        }

        double weight;
        public double Weight
        {
            get { return weight; }
            set { SetProperty(ref weight, value); }
        }

        async Task ExecuteCalculateCommand()
        {
            IsBusy = true;

            try
            {
                
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
