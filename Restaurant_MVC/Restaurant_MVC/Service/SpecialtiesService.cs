using Restaurant_MVC.Interface;
using Restaurant_MVC.Entities;
using Restaurant_MVC.Common;
using System.Collections.Generic;
using Restaurant_MVC.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant_MVC.Service
{
    public class SpecialtiesService : ISpecialties
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly RestaurantsDbContext _restaurantsDbContext;
        private readonly IMapper _mapper;

        public SpecialtiesService(RestaurantsDbContext restaurantsDbContext, IMapper mapper, IWebHostEnvironment hostingEnvironment)
        {
            _restaurantsDbContext = restaurantsDbContext;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }

        public List<FoodCategory> GetAllFoodCategories()
        {
            return _restaurantsDbContext.FoodCategories.ToList();
        }
        
        public List<FoodItem> GetAllFoodItems()
        {
            return _restaurantsDbContext.FoodItems.ToList();
        }

        public List<Restaurants> GetAllRestaurants()
        {
            return _restaurantsDbContext.Restaurantss.ToList();
        }

        [HttpPost]
        public void AddSpecialties(SpecialtiesModel spec)
        {
            var specia = _mapper.Map<FoodItem>(spec);

            _restaurantsDbContext.FoodItems.Add(specia);
            _restaurantsDbContext.SaveChanges();
        }

        public void SaveImage(SpecialtiesModel spec, IFormFile Image)
        {
            if (Image != null && Image.Length > 0)
            {
                var moreName = Path.GetExtension(Image.FileName);
                var fullName = Guid.NewGuid() + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + moreName;

                var imagePath = Path.Combine("wwwroot/images", fullName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }
                spec.Images = fullName;
            }
        }

        public void DeleteSpecialties(Guid id)
        {
            var foodItemToDelete = _restaurantsDbContext.FoodItems.FirstOrDefault(item => item.FoodItemId == id);

            if (foodItemToDelete != null)
            {
                _restaurantsDbContext.FoodItems.Remove(foodItemToDelete);
                _restaurantsDbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Food item not found.");
            }
        }

        public void UpdateSpecialties(SpecialtiesModel spec)
        {
            var existingFoodItem = _restaurantsDbContext.FoodItems.FirstOrDefault(x => x.FoodItemId == spec.FoodItemId);

            if (existingFoodItem != null)
            {
                _mapper.Map(spec, existingFoodItem); // Cập nhật thông tin từ SpecialtiesModel vào existingFoodItem

                _restaurantsDbContext.SaveChanges();
            }
        }

        public List<FoodItem> Search_FoodItem(string search)
        {
            return _restaurantsDbContext.FoodItems.Where(s => s.Name.Contains(search)).ToList();
             
        }

        public FoodItem GetReservationById(Guid id)
        {
            return _restaurantsDbContext.FoodItems.FirstOrDefault(r => r.FoodItemId == id);

        }

        public List<FoodItem> GetFoodItemsByCategory(Guid? foodCategoryId)
        {
            //if (foodCategoryId == null)
            //    return _db.FoodItems.ToList();
            return _restaurantsDbContext.FoodItems.Where(item => item.FoodCategoryId == foodCategoryId).ToList();
        }
    }
}
