errormsg = 'Invalid input'
sumval = count = inpmin = inpmax = 0.0

def min(a,b):
    if a > b:
        return b
    else:
        return a

def max(a,b):
    if a > b:
        return a
    else :
        return b

while True:
    inpi = input('Enter a number:')
    try:
        if inpi == 'done':
            if count > 0:
                print('sum:',sumval,'count:',count,'average',sumval/count,'min:',inpmin,'max',inpmax)
            else:
                print(errormsg)
            break

        inp = float(inpi)
        sumval = sumval + inp
        count = count + 1
        inpmin = min(inpmin, inp)
        inpmax = max(inpmax, inp)

    except Exception as e:
        print(errormsg,e)
