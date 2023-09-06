using Restaurant_MVC.Entities;
using Restaurant_MVC.Common;
using System.Collections.Generic;
using Restaurant_MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant_MVC.Interface
{
    public interface ISpecialties
    {
        List<FoodCategory> GetAllFoodCategories();
        List<FoodItem> GetAllFoodItems();
        List<Restaurants> GetAllRestaurants();
        List<FoodItem> Search_FoodItem(string search);
        void AddSpecialties(SpecialtiesModel spec);
        void SaveImage(SpecialtiesModel spec, IFormFile Image);
        void DeleteSpecialties (Guid id);
        void UpdateSpecialties (SpecialtiesModel spec);

        public FoodItem GetReservationById(Guid id);

        List<FoodItem> GetFoodItemsByCategory(Guid? foodCategoryId);
    }
}
