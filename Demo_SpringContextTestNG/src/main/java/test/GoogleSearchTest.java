package main.java.test;

import io.github.bonigarcia.wdm.WebDriverManager;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeOptions;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.testng.AbstractTestNGSpringContextTests;
import main.java.test.pom.GoogleResultPage;
import main.java.test.pom.GoogleSearchPage;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.AbstractApplicationContext;
import org.testng.ITestContext;
import org.testng.annotations.*;
import org.testng.Assert;

@ContextConfiguration("classpath:/main/java/test/GoogleSearchTest.xml")
public class GoogleSearchTest extends AbstractTestNGSpringContextTests {

    @Autowired
    protected ApplicationContext applicationContext;
    ChromeDriver driver;

    @Parameters("URL")
    @BeforeClass
    void prepareTest(String URL) {
        WebDriverManager.chromedriver().setup();
        driver = new ChromeDriver(new ChromeOptions());
        driver.navigate().to(URL);
    }

    @Test
    void testGoogleSearch() {
        String keyword = "specflow";
        // Get PageObject through applicationContext
        GoogleSearchPage searchPage = (GoogleSearchPage) applicationContext.getBean("searchPage");
        searchPage.setDriver(driver);
        searchPage.searchWithKeyword(keyword);
        GoogleResultPage resultPage = (GoogleResultPage) applicationContext.getBean("resultPage");
        resultPage.setDriver(driver);
        Assert.assertTrue(resultPage.getFirstCite().contains(keyword));
    }

    @AfterClass(alwaysRun = true)
    void cleanUp(ITestContext testContext) {
        if (applicationContext != null) {
            ((AbstractApplicationContext) applicationContext).close();
        }
        if (driver != null) {
            driver.close();
        }
    }
}
