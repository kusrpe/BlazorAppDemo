using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorClientDemo.Data.ViewModels
{
   
    public class RootDogBreedTypesResponseVM
    {
        public DogBreedTypesResponseVM message { get; set; } = new DogBreedTypesResponseVM();   
        public string status { get; set; }=string.Empty;
    }
}
