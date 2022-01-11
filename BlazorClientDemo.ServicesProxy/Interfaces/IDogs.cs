using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorClientDemo.Data.ViewModels;
namespace BlazorClientDemo.ServicesProxy.Interfaces
{
    public interface IDogs
    {
        Task<DogBreedListResponseVM?> GetDogBreedList(string BreedName);

        Task<RootDogBreedTypesResponseVM?> GetDogBreedTypes();

        Task<List<BreedTypeVM?>> GetBreedTypes();

        Task<RandomDogResponseVM?> GetRandomImage(string BreedName);
    }
}
