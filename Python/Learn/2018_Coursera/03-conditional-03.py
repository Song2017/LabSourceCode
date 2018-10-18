
errormsg = 'Bad score'
scorei = input('Enter score: ')

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