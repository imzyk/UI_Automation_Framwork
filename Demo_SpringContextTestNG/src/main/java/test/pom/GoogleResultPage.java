package main.java.test.pom;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.springframework.test.context.ContextConfiguration;

@ContextConfiguration("classpath:/main/java/test/pom/GoogleResultPage.xml")
public class GoogleResultPage {
    String textCiteSelector;
    WebDriver driver;

    public void setDriver(WebDriver driver) {
        this.driver = driver;
    }

    public void setTextCiteSelector(String textCiteSelector) {
        this.textCiteSelector = textCiteSelector;
    }

    public String getFirstCite() {
        return driver.findElements(By.cssSelector(textCiteSelector)).get(0).getText();
    }
}
