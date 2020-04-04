using LogIt.Models.FoodItem;
using LogIt.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LogIt.WebMVC.Controllers.WebAPI
{
    [Authorize]
    [RoutePrefix("api/FoodItem")]
    public class FoodItemController : ApiController
    {
        private bool SetStarState(int foodItemId, bool newState)
        {
            // Create the service
            var userId = User.Identity.GetUserId();
            var service = new FoodItemService(userId);

            // Get the food item
            var detail = service.GetFoodItemById(foodItemId);

            // Create the FoodItemEdit model instance with the new star state
            var updatedFoodItem =
                new FoodItemEdit
                {
                    FoodItemId = detail.FoodItemId,
                    Name = detail.Name,
                    Description = detail.Description,
                    Calories = detail.Calories,
                    CarbohydrateGrams = detail.CarbohydrateGrams,
                    FiberGrams = detail.FiberGrams,
                    FatGrams = detail.FatGrams,
                    ProteinGrams = detail.ProteinGrams,
                    SodiumMilligrams = detail.SodiumMilligrams,
                    PotassiumMilligrams = detail.PotassiumMilligrams,
                    IsStarred = newState
                };

            // Return a value indicating whether the update succeeded
            return service.UpdateFoodItem(updatedFoodItem);
        }

        [Route("{id}/Star")]
        [HttpPut]
        public bool ToggleStarOn(int id) => SetStarState(id, true);

        [Route("{id}/Star")]
        [HttpDelete]
        public bool ToggleStarOff(int id) => SetStarState(id, false);
    }
}
