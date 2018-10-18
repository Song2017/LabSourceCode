inp = input('enter fahrenheit temprature: ')
try:
    fahr = float(inp)
    cel = (fahr - 32.0) *5/9
    print(cel)
except:
    print('please input a number')

try:
    hoursi = input('Enter Hours: ')
    hours = float(hoursi)
    ratei = input('Enter Rate: ')
    rate = float(ratei)

    if(hours > 40):
        pay = (hours-40)*rate*1.5+40*rate
    else:
        pay = hours*rate

    print('Pay: '+ str(pay))
except:
    print('Error, please enter numberic input')


