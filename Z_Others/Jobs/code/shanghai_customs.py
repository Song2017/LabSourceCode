import requests
import json


def declare_payment(tid: str):
    url = "https://www.shcepp.com/cepp-pm-server/order/queryPage"
    """
    {"merchantOrderId":"E202006151537470376000011210SH",
    "assBillNo":"","orderState":"014","serverType":"-1",
    "updateTimeStart":"2020-06-16 00:00:00",
    "updateTimeEnd":"2020-06-23  23:59:59",
    "createTimeStart":"","createTimeEnd":"",
    "trxSerialNo":"","rowsPerPage":10,"pageNo":1}
    """
    payload = 'data=%7B%22merchantOrderId%22%3A%22' + tid + \
              '%22%2C%22assBillNo%22%3A%22%22%2C%22' \
              'orderState%22%3A%22014%22%2C%22' \
              'serverType%22%3A%22-1%22%2C%22' \
              'updateTimeStart%22%3A%222020-06-15%2000%3A00%3A00%22%2C%22' \
              'updateTimeEnd%22%3A%222020-06-22%20%2023%3A59%3A59%22%2C%22' \
              'createTimeStart%22%3A%22%22%2C%22' \
              'createTimeEnd%22%3A%22%22%2C%22trxSerialNo%22%3A%22%22%2C%22' \
              'rowsPerPage%22%3A10%2C%22pageNo%22%3A1%7D'

    headers = {
        'epToken': 'RT-1871-VAkciHZ06ku2fmfIex3z0yRMxYETYSXRMXeq4p0icf8aPOh7yu',
        'Content-Type': 'application/x-www-form-urlencoded'
    }

    response = requests.request("POST", url, headers=headers,
                                data=payload)
    resp = json.loads(response.text.encode('utf8'))
    rtn = ""
    try:
        rtn = resp["data"]["rows"][0]["crossOrderId"]
    except Exception as e:
        type(e)
    return rtn


if __name__ == "__main__":
    orders: list = []
    with open("cache.json", 'r') as fh:
        orders = fh.readlines()
    print(orders)
    result = []
    for order in orders:
        if order[0] != "E":
            continue
        result.append((order.replace('\n', ''), declare_payment(order)))
    with open("result.json", 'a+') as fh:
        for o in result:
            fh.writelines(",".join(o))
            fh.writelines('\n')
