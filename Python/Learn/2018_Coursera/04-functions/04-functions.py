def print_lyrics():
    print("I'm a lumberjack, and I'm okay.")
    print('I sleep all night and I work all day.')
#repeat_lyrics()   error:name 'repeat_lyrics' is not defined
def repeat_lyrics():
    print_lyrics()
    print_lyrics()
repeat_lyrics()
# Code: http://www.py4e.com/code3/lyrics.py


def print_twice(bruce):
    print(bruce)
    print(bruce)
twice_text = input('Input text which will be print twice: ')
print_twice(twice_text)


def addtwo(a,b):
    return a+b
print('3+5= '+str(addtwo(3,5)))

