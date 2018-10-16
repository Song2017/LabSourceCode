inp = input('enter fahrenheit temprature: ')
try:
    fahr = float(inp)
    cel = (fahr - 32.0) *5/9
    print(cel)
except:
    print('please input a number')