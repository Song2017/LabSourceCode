import time
import unittest
from selenium import webdriver
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC


class PythonOrSearch(unittest.TestCase):
    def setUp(self):
        self.driver = webdriver.Chrome(r'C:\_Software\chromedriver.exe')
        self.driver.implicitly_wait(5)

    def test_search_in_python_org(self):
        driver = self.driver
        driver.get("http://localhost/VK6/Login.aspx?tc=singapore")
        print('Page Title: ', driver.title)
        elem = driver.find_element_by_id("idUserName")
        elem.send_keys("admin", Keys.TAB)
        elem.send_keys(Keys.TAB)
        elem = driver.find_element_by_id("idPassword")
        elem.send_keys("pw")
        elem = driver.find_element_by_id("idSignin")
        elem.click()

        wait = WebDriverWait(driver, 10)
        elements = wait.until(
            EC.element_to_be_clickable((By.CLASS_NAME, 'dropdown-toggle')))
        print('Page Title: ', driver.title)
        print('element: ', elements)
        # logout = driver.find_element_by_xpath(
        #     "//ul[li[a/@href='/VK6/Logout.aspx']]]")
        # logout.click()
        driver.get("http://localhost/VK6/Logout.aspx")
        logout = wait.until(EC.element_to_be_clickable(
            (By.ID, 'ctl00_ContentPlaceHolder1_btnLogout')))
        logout.click()
        time.sleep(5)

    def tearDown(self):
        self.driver.quit()


class element_has_css_class(object):
    """An expectation for checking that an element has a particular css class.

    locator - used to find the element
    returns the WebElement once it has the particular css class
    """

    def __init__(self, locator, css_class):
        self.locator = locator
        self.css_class = css_class

    def __call__(self, driver):
        # Finding the referenced element
        element = driver.find_element(*self.locator)
        if self.css_class in element.get_attribute("class"):
            return element
        else:
            return False


if __name__ == "__main__":
    unittest.main()
