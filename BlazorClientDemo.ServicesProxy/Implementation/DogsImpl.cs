using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BlazorClientDemo.Data.ViewModels;
using BlazorClientDemo.ServicesProxy.Interfaces;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System.Linq;
using System.Linq.Expressions;

namespace BlazorClientDemo.ServicesProxy.Implementation
{
    public class DogsImpl : IDogs
    {
        private readonly HttpClient httpClient;

        public DogsImpl(HttpClient httpClient) =>
            this.httpClient = httpClient;

        public async Task<List<BreedTypeVM?>> GetBreedTypes()
        {
            List<BreedTypeVM?> breedTypeVMs = new List<BreedTypeVM?>()
            {
               new BreedTypeVM("1","affenpinscher"),
                new BreedTypeVM("2","african"),
                new BreedTypeVM("3","airedale"),
                new BreedTypeVM("4","akita"),
                new BreedTypeVM("5","appenzeller"),
                new BreedTypeVM("6","australian"),
                new BreedTypeVM("7","basenji"),
                new BreedTypeVM("8","beagle"),
                new BreedTypeVM("9","bluetick"),
                new BreedTypeVM("10","borzoi"),
                new BreedTypeVM("11","bouvier"),
                new BreedTypeVM("12","boxer"),
                new BreedTypeVM("13","brabancon"),
                new BreedTypeVM("14","briard"),
                new BreedTypeVM("15","buhund"),
                new BreedTypeVM("16","bulldog"),
                new BreedTypeVM("17","bullterrier"),
                new BreedTypeVM("18","cattledog"),
                new BreedTypeVM("19","chihuahua"),
                new BreedTypeVM("20","chow"),
                new BreedTypeVM("21","clumber"),
                new BreedTypeVM("22","cockapoo"),
                new BreedTypeVM("23","collie"),
                new BreedTypeVM("24","coonhound"),
                new BreedTypeVM("25","corgi"),
                new BreedTypeVM("26","cotondetulear"),
                new BreedTypeVM("27","dachshund"),
                new BreedTypeVM("28","dalmatian"),
                new BreedTypeVM("29","dane"),
                new BreedTypeVM("30","deerhound"),
                new BreedTypeVM("31","dhole"),
                new BreedTypeVM("32","dingo"),
                new BreedTypeVM("33","doberman"),
                new BreedTypeVM("34","elkhound"),
                new BreedTypeVM("35","entlebucher"),
                new BreedTypeVM("36","eskimo"),
                new BreedTypeVM("37","finnish"),
                new BreedTypeVM("38","frise"),
                new BreedTypeVM("39","germanshepherd"),
                new BreedTypeVM("40","greyhound"),
                new BreedTypeVM("41","groenendael"),
                new BreedTypeVM("42","havanese"),
                new BreedTypeVM("43","hound"),
                new BreedTypeVM("44","husky"),
                new BreedTypeVM("45","keeshond"),
                new BreedTypeVM("46","kelpie"),
                new BreedTypeVM("47","komondor"),
                new BreedTypeVM("48","kuvasz"),
                new BreedTypeVM("49","labradoodle"),
                new BreedTypeVM("50","labrador"),
                new BreedTypeVM("51","leonberg"),
                new BreedTypeVM("52","lhasa"),
                new BreedTypeVM("53","malamute"),
                new BreedTypeVM("54","malinois"),
                new BreedTypeVM("55","maltese"),
                new BreedTypeVM("56","mastiff"),
                new BreedTypeVM("57","mexicanhairless"),
                new BreedTypeVM("58","mix"),
                new BreedTypeVM("59","mountain"),
                new BreedTypeVM("60","newfoundland"),
                new BreedTypeVM("61","otterhound"),
                new BreedTypeVM("62","ovcharka"),
                new BreedTypeVM("63","papillon"),
                new BreedTypeVM("64","pekinese"),
                new BreedTypeVM("65","pembroke"),
                new BreedTypeVM("66","pinscher"),
                new BreedTypeVM("67","pitbull"),
                new BreedTypeVM("68","pointer"),
                new BreedTypeVM("69","pomeranian"),
                new BreedTypeVM("70","poodle"),
                new BreedTypeVM("71","pug"),
                new BreedTypeVM("72","puggle"),
                new BreedTypeVM("73","pyrenees"),
                new BreedTypeVM("74","redbone"),
                new BreedTypeVM("75","retriever"),
                new BreedTypeVM("76","ridgeback"),
                new BreedTypeVM("77","rottweiler"),
                new BreedTypeVM("78","saluki"),
                new BreedTypeVM("79","samoyed"),
                new BreedTypeVM("80","schipperke"),
                new BreedTypeVM("81","schnauzer"),
                new BreedTypeVM("82","setter"),
                new BreedTypeVM("83","sheepdog"),
                new BreedTypeVM("84","shiba"),
                new BreedTypeVM("85","shihtzu"),
                new BreedTypeVM("86","spaniel"),
                new BreedTypeVM("87","springer"),
                new BreedTypeVM("88","stbernard"),
                new BreedTypeVM("89","terrier"),
                new BreedTypeVM("90","tervuren"),
                new BreedTypeVM("91","vizsla"),
                new BreedTypeVM("92","waterdog"),
                new BreedTypeVM("93","weimaraner"),
                new BreedTypeVM("94","whippet"),
                new BreedTypeVM("95","wolfhound")
            };
            return await Task.FromResult(breedTypeVMs);

        }

        public async Task<DogBreedListResponseVM?> GetDogBreedList(string BreedName)
        {
            DogBreedListResponseVM? postResponse = null;
            try
            {
                postResponse = await httpClient.GetFromJsonAsync<DogBreedListResponseVM?>($"breed/{BreedName}/images");

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Reason: {ex.Message}, Message: {ex.StackTrace}");
            }
            return postResponse;


        }

        public async Task<RootDogBreedTypesResponseVM?> GetDogBreedTypes()
        {
            var queryString = $"https://dog.ceo/api/breeds/list/all";
            //var httpClient = _httpClientFactory.CreateClient();

            RootDogBreedTypesResponseVM? postResponse = await httpClient.GetFromJsonAsync<RootDogBreedTypesResponseVM>(queryString);

            //DogBreedTypesResponseVM dogBreedTypesResponseVM = postResponse;
            // List<BreedTypeVM?> lstBreedTypeVM = new List<BreedTypeVM?>();

            return postResponse;

        }

        public async Task<RandomDogResponseVM?> GetRandomImage(string BreedName)
        {
            RandomDogResponseVM? postResponse = null;
            try
            {
                postResponse = await httpClient.GetFromJsonAsync<RandomDogResponseVM>($"breed/{ BreedName}/images/random");
            }
            catch ( Exception ex)
            {
                throw new ApplicationException($"Reason: {ex.Message}, Message: {ex.StackTrace}");
            }
            return postResponse;
        }
    }
}


//using System;
//using System.Threading.Tasks;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Net.Http.Json;
//using System.Text;
//using System.Threading.Tasks;
//using BlazorClientDemo.Data.ViewModels;
//using BlazorClientDemo.ServicesProxy.Interfaces;
//using Microsoft.Net.Http.Headers;
//using Newtonsoft.Json;
//using System.Linq;
//using System.Linq.Expressions;

//namespace BlazorClientDemo.ServicesProxy.Implementation
//{
//    public class DogsImpl : IDogs
//    {
//        private readonly IHttpClientFactory _httpClientFactory;
//        private string _queryString = string.Empty;
//        public DogsImpl(IHttpClientFactory httpClientFactory) =>
//        _httpClientFactory = httpClientFactory;


//        public async Task<List<BreedTypeVM?>> GetBreedTypes()
//        {
//            List<BreedTypeVM?> breedTypeVMs = new List<BreedTypeVM?>()
//            {
//               new BreedTypeVM("1","affenpinscher"),
//                new BreedTypeVM("2","african"),
//                new BreedTypeVM("3","airedale"),
//                new BreedTypeVM("4","akita"),
//                new BreedTypeVM("5","appenzeller"),
//                new BreedTypeVM("6","australian"),
//                new BreedTypeVM("7","basenji"),
//                new BreedTypeVM("8","beagle"),
//                new BreedTypeVM("9","bluetick"),
//                new BreedTypeVM("10","borzoi"),
//                new BreedTypeVM("11","bouvier"),
//                new BreedTypeVM("12","boxer"),
//                new BreedTypeVM("13","brabancon"),
//                new BreedTypeVM("14","briard"),
//                new BreedTypeVM("15","buhund"),
//                new BreedTypeVM("16","bulldog"),
//                new BreedTypeVM("17","bullterrier"),
//                new BreedTypeVM("18","cattledog"),
//                new BreedTypeVM("19","chihuahua"),
//                new BreedTypeVM("20","chow"),
//                new BreedTypeVM("21","clumber"),
//                new BreedTypeVM("22","cockapoo"),
//                new BreedTypeVM("23","collie"),
//                new BreedTypeVM("24","coonhound"),
//                new BreedTypeVM("25","corgi"),
//                new BreedTypeVM("26","cotondetulear"),
//                new BreedTypeVM("27","dachshund"),
//                new BreedTypeVM("28","dalmatian"),
//                new BreedTypeVM("29","dane"),
//                new BreedTypeVM("30","deerhound"),
//                new BreedTypeVM("31","dhole"),
//                new BreedTypeVM("32","dingo"),
//                new BreedTypeVM("33","doberman"),
//                new BreedTypeVM("34","elkhound"),
//                new BreedTypeVM("35","entlebucher"),
//                new BreedTypeVM("36","eskimo"),
//                new BreedTypeVM("37","finnish"),
//                new BreedTypeVM("38","frise"),
//                new BreedTypeVM("39","germanshepherd"),
//                new BreedTypeVM("40","greyhound"),
//                new BreedTypeVM("41","groenendael"),
//                new BreedTypeVM("42","havanese"),
//                new BreedTypeVM("43","hound"),
//                new BreedTypeVM("44","husky"),
//                new BreedTypeVM("45","keeshond"),
//                new BreedTypeVM("46","kelpie"),
//                new BreedTypeVM("47","komondor"),
//                new BreedTypeVM("48","kuvasz"),
//                new BreedTypeVM("49","labradoodle"),
//                new BreedTypeVM("50","labrador"),
//                new BreedTypeVM("51","leonberg"),
//                new BreedTypeVM("52","lhasa"),
//                new BreedTypeVM("53","malamute"),
//                new BreedTypeVM("54","malinois"),
//                new BreedTypeVM("55","maltese"),
//                new BreedTypeVM("56","mastiff"),
//                new BreedTypeVM("57","mexicanhairless"),
//                new BreedTypeVM("58","mix"),
//                new BreedTypeVM("59","mountain"),
//                new BreedTypeVM("60","newfoundland"),
//                new BreedTypeVM("61","otterhound"),
//                new BreedTypeVM("62","ovcharka"),
//                new BreedTypeVM("63","papillon"),
//                new BreedTypeVM("64","pekinese"),
//                new BreedTypeVM("65","pembroke"),
//                new BreedTypeVM("66","pinscher"),
//                new BreedTypeVM("67","pitbull"),
//                new BreedTypeVM("68","pointer"),
//                new BreedTypeVM("69","pomeranian"),
//                new BreedTypeVM("70","poodle"),
//                new BreedTypeVM("71","pug"),
//                new BreedTypeVM("72","puggle"),
//                new BreedTypeVM("73","pyrenees"),
//                new BreedTypeVM("74","redbone"),
//                new BreedTypeVM("75","retriever"),
//                new BreedTypeVM("76","ridgeback"),
//                new BreedTypeVM("77","rottweiler"),
//                new BreedTypeVM("78","saluki"),
//                new BreedTypeVM("79","samoyed"),
//                new BreedTypeVM("80","schipperke"),
//                new BreedTypeVM("81","schnauzer"),
//                new BreedTypeVM("82","setter"),
//                new BreedTypeVM("83","sheepdog"),
//                new BreedTypeVM("84","shiba"),
//                new BreedTypeVM("85","shihtzu"),
//                new BreedTypeVM("86","spaniel"),
//                new BreedTypeVM("87","springer"),
//                new BreedTypeVM("88","stbernard"),
//                new BreedTypeVM("89","terrier"),
//                new BreedTypeVM("90","tervuren"),
//                new BreedTypeVM("91","vizsla"),
//                new BreedTypeVM("92","waterdog"),
//                new BreedTypeVM("93","weimaraner"),
//                new BreedTypeVM("94","whippet"),
//                new BreedTypeVM("95","wolfhound")
//            };
//            return await Task.FromResult(breedTypeVMs);

//        }

//        public async Task<DogBreedListResponseVM?> GetDogBreedList(string BreedName)
//        {
//            DogBreedListResponseVM? postResponse = null;
//            var queryString = $"https://dog.ceo/api/breed/{ BreedName}/images";
//            var httpClient = _httpClientFactory.CreateClient();
//            try
//            {
//                postResponse = await httpClient.GetFromJsonAsync<DogBreedListResponseVM?>(queryString);
//            }
//            catch (Exception ex)
//            {
//                return null;
//            }
//            return postResponse;


//        }

//        public async Task<RootDogBreedTypesResponseVM?> GetDogBreedTypes()
//        {
//            var queryString = $"https://dog.ceo/api/breeds/list/all";
//            var httpClient = _httpClientFactory.CreateClient();

//            RootDogBreedTypesResponseVM? postResponse = await httpClient.GetFromJsonAsync<RootDogBreedTypesResponseVM>(queryString);

//            DogBreedTypesResponseVM dogBreedTypesResponseVM = postResponse.message;
//            // List<BreedTypeVM?> lstBreedTypeVM = new List<BreedTypeVM?>();

//            return postResponse;

//        }

//        public async Task<RandomDogResponseVM?> GetRandomImage(string BreedName)
//        {
//            var queryString = $"https://dog.ceo/api/breed/{ BreedName}/images/random";
//            var httpClient = _httpClientFactory.CreateClient();
//            RandomDogResponseVM? postResponse = await httpClient.GetFromJsonAsync<RandomDogResponseVM>(queryString);
//            return postResponse;
//        }
//    }
//}
