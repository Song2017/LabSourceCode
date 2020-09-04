import base64
from PIL import Image
import pytesseract

def processing_image(path):
    image_obj = Image.open(path)  # 获取验证码
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

        images = img
        # data = images.getdata()
        # w, h = images.size
        # black_point = 0
        # for x in range(1, w - 1):
        #     for y in range(1, h - 1):
        #         mid_pixel = data[w * y + x]  # 中央像素点像素值
        #         if mid_pixel < 50:  # 找出上下左右四个方向像素点像素值
        #             top_pixel = data[w * (y - 1) + x]
        #             left_pixel = data[w * y + (x - 1)]
        #             down_pixel = data[w * (y + 1) + x]
        #             right_pixel = data[w * y + (x + 1)]
        #             # 判断上下左右的黑色像素点总个数
        #             if top_pixel < 10:
        #                 black_point += 1
        #             if left_pixel < 10:
        #                 black_point += 1
        #             if down_pixel < 10:
        #                 black_point += 1
        #             if right_pixel < 10:
        #                 black_point += 1
        #             if black_point < 1:
        #                 images.putpixel((x, y), 255)
        #             black_point = 0                
    return images

def processing():
    img = processing_image("WechatIMG5499.jpeg")
    text = pytesseract.image_to_string(img, lang='chi_sim')
    import pdb
    pdb.set_trace()
    print(text)
    with open("result.txt", "w") as h:
        h.write(text)

if __name__ == "__main__":
    processing()