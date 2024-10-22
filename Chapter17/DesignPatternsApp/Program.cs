using DesignPatternsApp;

// Builder
WriteLine("Builder:");
UserProfile userProfile = new UserProfileBuilder()
    .SetFirstName("Ross")
    .SetLastName("Keenan")
    .SetAge(30)
    .SetEmail("fake@email.com")
    .SetAddress("123 Fake Dr")
    .Build();
WriteLine(userProfile.Email);
WriteLine();

// Factory
WriteLine("Factory:");
Project project = new WebProject();
IProjectManager manager = project.CreateProject();
manager.HandleProject();

project = new MobileProject();
manager = project.CreateProject();
manager.HandleProject();
WriteLine();

// Adapter
WriteLine("Adapter:");
ITextProcessor processor = new TextProcessor();
processor.ProcessText("Hello, world.");

IAdvancedTextAnalytics analytics = new AdvancedTextAnalytics();
ITextProcessor advancedProcessor = new TextAnalyticsAdapter(analytics);
advancedProcessor.ProcessText("Exploring the Adapter pattern in .Net");
WriteLine();

// Template Method
WriteLine("Template:");
CookingRecipe pasta = new PastaRecipe();
pasta.CookMeal();

CookingRecipe salad = new SaladRecipe();
salad.CookMeal();
WriteLine();
