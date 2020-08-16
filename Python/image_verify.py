import requests
import base64
from PIL import Image
import pytesseract


def processing_image(self):
    print(pytesseract.image_to_string("WechatIMG5499.jpeg", lang='eng'))