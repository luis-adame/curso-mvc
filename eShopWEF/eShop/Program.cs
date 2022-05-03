// See https://aka.ms/new-console-template for more information

using eShop.UserInterface;
using Model;

using (var context = new AppDbContext())
{
    try
    {
        await AppDbContextSeed.SeedAsync(context);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }
}

var eShop = new EShopConsole();
while (eShop.ShowMainMenu());