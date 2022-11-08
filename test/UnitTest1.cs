using Microsoft.Playwright;

namespace test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            //await Playwright.InstallAsync();
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            await page.GotoAsync("https://playwright.dev/");
            await page.ClickAsync(".DocSearch-Button-Placeholder");
            //await File.WriteAllBytesAsync(Path.Combine(Directory.GetCurrentDirectory(), "playwright2.png"),
            await page.ScreenshotAsync(new()
            {
                Path = "screenshot.png"
            });
        }
    }
}