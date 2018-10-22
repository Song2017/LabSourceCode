# compute pay
hoursi = input('Enter Hours: ')
ratei = input('Enter Rate: ')

def computepay(hoursi,ratei):
    try:
        hours = float(hoursi)
        rate = float(ratei)
        if(hours > 40):
            pay = (hours-40)*rate*1.5+40*rate
        else:
            pay = hours*rate

        print('Pay: '+ str(pay))
    except:
        print('Error, please enter numberic input')

computepay(hoursi,ratei)

#compute grade
errormsg = 'Bad score'
scorei = input('Enter score: ')
def computegrade(scorei):
    try:
        score = float(scorei)
        if score > 1 or score < 0 :
            print(errormsg)
        elif score >= 0.9 and score <= 1 :
            print('A')
        elif score >= 0.8 and score < 0.9 :
            print('B')
        elif score >= 0.7 and score < 0.8 :
            print('C')
        elif score >= 0.6 and score < 0.7 :
            print('D')
        elif score >= 0 and score < 0.6 :
            print('F')                        
    except:
        print(errormsg)

computegrade(scorei)
