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
        count = 100
        while count > 0:
            count -= 1
            print(count)
            driver = self.driver
            driver.get("https://blog.csdn.net/sgs595595/article/details/89360804")
            print(count)

            time.sleep(10)

    def tearDown(self):
        self.driver.quit()


if __name__ == "__main__":
    unittest.main()
