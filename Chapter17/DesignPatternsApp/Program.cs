using DesignPatternsApp;

// Builder
UserProfile userProfile = new UserProfileBuilder()
    .SetFirstName("Ross")
    .SetLastName("Keenan")
    .SetAge(30)
    .SetEmail("fake@email.com")
    .SetAddress("123 Fake Dr")
    .Build();

WriteLine(userProfile.Email);

// Adapter
ITextProcessor processor = new TextProcessor();
processor.ProcessText("Hello, world.");

IAdvancedTextAnalytics analytics = new AdvancedTextAnalytics();
ITextProcessor advancedProcessor = new TextAnalyticsAdapter(analytics);
advancedProcessor.ProcessText("Exploring the Adapter pattern in .Net");

// Template Method
CookingRecipe pasta = new PastaRecipe();
pasta.CookMeal();

CookingRecipe salad = new SaladRecipe();
salad.CookMeal();
