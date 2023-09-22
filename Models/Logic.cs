using System;
using System.Net.WebSockets;
using System.Linq;

namespace apiforapp.Models
{
    public class Logic
    {
        public static List<Food> SelectFoods(List<Food> foodItems, double targetCalories, double targetProtein, double targetFat, double targetCarbs, int count)
        {
            var calo = targetCalories;
            var listfood = foodItems;
            List<Food> selectedFoods = new List<Food>();

            // Lặp để chọn count món ăn
            for (int i = 0; i < foodItems.Count; i++)
            {
                // Tìm món ăn tương tự với mục tiêu dựa trên cosine similarity
                Food selectedFood = FindMostSimilarFood(foodItems, targetCalories, targetProtein, targetFat, targetCarbs);

                if (selectedFood != null)
                {
                    // Trừ lượng dinh dưỡng của món ăn đã chọn
                    targetCalories -= selectedFood.Calories;
                    targetProtein -= selectedFood.Protein;
                    targetFat -= selectedFood.Fat;
                    targetCarbs -= selectedFood.Carbohydrates;

                    if (targetCalories < 0)
                        break;
                    // Thêm món ăn đã chọn vào danh sách và xóa đi khỏi danh sách ban đầu
                    selectedFoods.Add(selectedFood);
                    foodItems.Remove(selectedFood);
                }
            }

            // Lấy món theo đúng số lượng và cập nhật lại danh sách chỉ trừ mó đã lấy ra
            selectedFoods = selectedFoods.OrderByDescending(x => x.Calories).Take(count).ToList();
            foodItems = CleanFood(listfood, selectedFoods);
            return selectedFoods;

        }

        private static Food FindMostSimilarFood(List<Food> foodItems, double targetCalories, double targetProtein, double targetFat, double targetCarbs)
        {
            Food mostSimilarFood = null;
            double highestSimilarity = double.MinValue;

            // Tính cosine similarity cho mỗi món ăn và chọn món ăn có độ tương tự cao nhất
            var foodToRemove = foodItems;
            Random random = new Random();

            for (int i = 0; i < foodItems.Count; i++)
            {
                
                int randomIndex = random.Next(foodItems.Count);

                if (foodToRemove.FirstOrDefault(p => p.Equals(foodItems[randomIndex])) != null)
                {
                    double similarity = CalculateCosineSimilarity(foodItems[randomIndex], targetCalories, targetProtein, targetFat, targetCarbs);

                    if (similarity > highestSimilarity)
                    {
                        highestSimilarity = similarity;
                        mostSimilarFood = foodItems[randomIndex];
                        //foodToRemove.Remove(foodItems[randomIndex]);
                        Console.WriteLine(foodToRemove.Count);
                    }
                }
                else
                {
                    i--;
                }
            }


            return mostSimilarFood;
        }

        private static double CalculateCosineSimilarity(Food food, double targetCalories, double targetProtein, double targetFat, double targetCarbs)
        {
            double dotProduct = food.Calories * targetCalories +
                                food.Protein * targetProtein +
                                food.Fat * targetFat +
                                food.Carbohydrates * targetCarbs;

            double normFood = Math.Sqrt(food.Calories * food.Calories +
                                        food.Protein * food.Protein + 
                                        food.Fat * food.Fat + 
                                        food.Carbohydrates * food.Carbohydrates);

            double normTarget = Math.Sqrt(targetCalories * targetCalories +
                                          targetProtein * targetProtein +
                                          targetFat * targetFat + 
                                          targetCarbs * targetCarbs);

            if (normFood == 0 || normTarget == 0)
                return 0;

            return dotProduct / (normFood * normTarget);
        }

        private static List<Food> CleanFood(List<Food> foodList, List<Food> foodsRecommend) 
        {
            foreach(Food food in foodsRecommend)
            {
                foodList.Remove(food);
            }

            return foodList;
        }

    }
}
