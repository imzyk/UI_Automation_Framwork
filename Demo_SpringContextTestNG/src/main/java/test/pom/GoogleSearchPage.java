package main.java.test.pom;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.springframework.test.context.ContextConfiguration;

@ContextConfiguration("classpath:/main/java/test/pom/GoogleSearchPage.xml")
public class GoogleSearchPage {
    String btnSearchSelector;
    WebDriver driver;

    public void setDriver(WebDriver driver) {
        this.driver = driver;
    }

    public void searchWithKeyword(String keyword) {
        WebElement btnSearch = driver.findElement(By.cssSelector(btnSearchSelector));
        btnSearch.sendKeys(keyword + "\n");
    }

    public void setBtnSearchSelector(String btnSearchSelector) {
        this.btnSearchSelector = btnSearchSelector;
    }
}
