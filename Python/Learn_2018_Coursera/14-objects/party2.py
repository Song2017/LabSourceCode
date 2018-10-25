# class
class PartyAnimal:
    x=0
    def party(self):
        self.x = self.x+1
        print('so far', self.x)

an = PartyAnimal()
an.party()
an.party()
PartyAnimal.party(an)
#PartyAnimal.party() #TypeError: party() missing 1 required positional argument: 'self'

# class as type
print('type(an)', type(an))
print('dir(an)', dir(an))
print('type(an.x)', type(an.x))
print('type(an.party)', type(an.party))

# object life line
class PartyAnimalLife:
    x=0

    def __init__(self):
        print('I am constructed')

    def party(self):
        self.x = self.x+1
        print('so far', self.x)
    # If a base class has a __del__() method, the derived class’s __del__() method, 
    # if any, must explicitly call it to ensure proper deletion of the base class part of the instance.
    def __del__(self):
        print('I am destructed', self.x)

anl = PartyAnimalLife()
anl.party()
anl.party()
anl.party()
print('anl type', anl, type(anl))
anl=42
print('anl contains', anl, type(anl))

# multi instances
class PartyAnimalMulti:
    x=0
    name = ''
    def __init__(self, nam):
        self.name = nam
        print(self.name, 'constructed')

    def party(self):
        self.x = self.x + 1
        print(self.name, 'party count', self.x)

s = PartyAnimalMulti('Sally')
j = PartyAnimalMulti('Jim')

s.party()
j.party()
s.party()

# inheritance



