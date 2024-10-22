namespace DesignPatternsApp
{
    public abstract class CookingRecipe
    {
        // Template method
        public void CookMeal()
        {
            PrepareIngredients();
            Cook();
            Serve();
        }

        protected abstract void PrepareIngredients();
        protected abstract void Cook();

        // Common method used by all subclasses
        protected void Serve()
        {
            WriteLine("Serving the meal");
        }
    }

    public class PastaRecipe : CookingRecipe
    {
        protected override void Cook()
        {
            WriteLine("Preparing pasta and sauce");
        }

        protected override void PrepareIngredients()
        {
            WriteLine("Cooking past in the boiling water");
        }
    }

    public class SaladRecipe : CookingRecipe
    {
        protected override void Cook()
        {
            WriteLine("Mixing vegetables with dressing");
        }

        protected override void PrepareIngredients()
        {
            WriteLine("Chopping vegetables");
        }
    }
}
