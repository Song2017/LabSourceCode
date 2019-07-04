voted = {}


def check_voter(name):
    if voted.get(name):
        print('kick out')
    else:
        voted[name] = True
        print(name + ' voted')


check_voter('alice')
check_voter('han')
check_voter('alice')
