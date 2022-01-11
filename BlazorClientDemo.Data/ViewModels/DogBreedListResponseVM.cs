using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorClientDemo.Data.ViewModels
{
    public class DogBreedListResponseVM
    {
        public List<string> message { get; set; } = new List<string>();
        public string status { get; set; } = String.Empty;
    }

}
