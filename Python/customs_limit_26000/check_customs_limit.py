import requests
import base64
from PIL import Image
import pytesseract


class ImageProcess:
    def processing_image(self):
        image_obj = Image.open('verify.png')  # 获取验证码
        img = image_obj.convert("L")  # 转灰度
        pix_data = img.load()
        w, h = img.size
        threshold = 160  # 该阈值不适合所有验证码，具体阈值请根据验证码情况设置
        # 遍历所有像素，大于阈值的为黑色
        for y in range(h):
            for x in range(w):
                if pix_data[x, y] < threshold:
                    pix_data[x, y] = 0
                else:
                    pix_data[x, y] = 255
        return img

    def delete_spot(self):
        images = self.processing_image()
        data = images.getdata()
        w, h = images.size
        black_point = 0
        for x in range(1, w - 1):
            for y in range(1, h - 1):
                mid_pixel = data[w * y + x]  # 中央像素点像素值
                if mid_pixel < 50:  # 找出上下左右四个方向像素点像素值
                    top_pixel = data[w * (y - 1) + x]
                    left_pixel = data[w * y + (x - 1)]
                    down_pixel = data[w * (y + 1) + x]
                    right_pixel = data[w * y + (x + 1)]
                    # 判断上下左右的黑色像素点总个数
                    if top_pixel < 10:
                        black_point += 1
                    if left_pixel < 10:
                        black_point += 1
                    if down_pixel < 10:
                        black_point += 1
                    if right_pixel < 10:
                        black_point += 1
                    if black_point < 1:
                        images.putpixel((x, y), 255)
                    black_point = 0
        images.show()
        return images


class CustomsLimit:
    cookie = ""

    def request_customs(self):
        url = "https://app.singlewindow.cn/ceb2pubweb/sw/personalAmountHJ"
        response = requests.request("GET", url, headers={}, data={})
        self.cookie = ''
        for name, value in response.cookies.iteritems():
            self.cookie += '{0}={1}'.format(name, value)
        print("requests first ", self.cookie)

    def get_creator_img(self):
        url = "https://app.singlewindow.cn:443/ceb2pubweb//verifyCode/creator"
        headers = {'Cookie': self.cookie}
        response = requests.get(url, headers=headers)
        with open('verify.png', "wb") as handle:
            handle.write(response.content)
        print('img download')
        img = ImageProcess()
        img.delete_spot().save("verify2", "png")
        print(pytesseract.image_to_string("verify2.png", lang='eng'))
        # print(pytesseract.image_to_string('verify.png', lang='eng'))
        print('img done')

    def get_limit(self, id_number):
        id_number = base64.b64encode(id_number.encode())
        print(id_number)
        url = "https://app.singlewindow.cn/ceb2pubweb/limit/outTotalAmount"
        payload = {'verifyCode': 'X9DW',
                   'personalName': 'asdf',
                   'idNumber': id_number,
                   'sessionKey': 'verifyCode',
                   'queryCodeHidden': 'cebpub'}

        headers = {
            'Cookie': self.cookie
        }

        response = requests.post(url, headers=headers, data=payload)

        print(response.text)


if __name__ == "__main__":
    print("beigin")
    limit = CustomsLimit()
    limit.request_customs()
    limit.get_creator_img()
    # limit.get_limit("420107196807300529")
    # img = ImageProcess()
    # img.delete_spot()
