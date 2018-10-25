from party2 import PartyAnimalMulti

# inheritance
class CriketFan(PartyAnimalMulti):
    points = 0
    def six(self):
        self.points = self.points + 6
        self.party()
        print(self.name, "points", self.points, 'father class x', self.x)

s = PartyAnimalMulti('Salley')
s.party()
j=CriketFan('Jim')
j.party()
j.six()
print(dir(j))