using System.Threading.Tasks;
using BlazorClientDemo.Data.ViewModels;
using BlazorClientDemo.ServicesProxy.Interfaces;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorClientDemo.Pages
{
    public partial class DogDetails : IDisposable
    {

        string selectedBreed = string.Empty;

        string SelectedBreed
        {
            get => selectedBreed;
            set { selectedBreed = value; }
        }
        private DogBreedListResponseVM? objDogBreedListResponseVM { get; set; }
        private RandomDogResponseVM? randomDogResponseVM { get; set; }
        private List<BreedTypeVM?> lstBreedTypeVM = new List<BreedTypeVM?>();
        protected override async Task OnInitializedAsync()
        {
            lstBreedTypeVM = await Dogs.GetBreedTypes();
        }

        private async Task ClickHere(MouseEventArgs e)
        {
            objDogBreedListResponseVM = await Dogs.GetDogBreedList(SelectedBreed);
        }

        private async Task RandomImage(MouseEventArgs e)
        {
            try
            {


                randomDogResponseVM = await Dogs.GetRandomImage(SelectedBreed);

            }
            catch (Exception ex)
            {
                //ErrorComponent.ShowError(ex.Message, ex.StackTrace);
                randomDogResponseVM = null;

            }
        }
            public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
