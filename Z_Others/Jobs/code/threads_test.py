import datetime
import threading
import time
from concurrent.futures import ThreadPoolExecutor, as_completed


def update_sku_quantity(sku_id: str, quantity: int):
    time.sleep(2)
    print("the quantity of {sku_id} has been updated", datetime.datetime.now())


def create_sku(sku_id: str):
    time.sleep(1)
    print(f"{sku_id} has been created")
    return sku_id


if __name__ == '__main__':
    print(datetime.datetime.now())
    # 创建一个sku需要1s
    # 更新sku的数量需要2s
    # 创建3个sku并更新每个sku的数量最少需要多长时间?
    sku_ids = ["sku1", "sku2", "sku3"]
    sku_quantity = {"sku1": 1, "sku2": 2, "sku3": 3}

    # answer
    executor = ThreadPoolExecutor(max_workers=3)
    create_tasks = [executor.submit(
        create_sku, sku_id) for sku_id in sku_ids]
    for future in as_completed(create_tasks):
        sku = future.result()
        task = threading.Thread(target=update_sku_quantity,
                                args=(sku, sku_quantity.get(sku)))
        task.start()
        print("get {} page".format(sku))
    print(datetime.datetime.now())
