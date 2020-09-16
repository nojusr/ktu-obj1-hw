# a small python script to generate random data for this project

from random import randrange, choice
from datetime import datetime, timedelta

generateAmount = 100

possibleNames = ["Antanas", "Vardėnis", "Petras", "Aloyzas", "Juozas", "Motiejus"]
possibleRaces = ["Žmogus", "Elfas", "Driežažmogis", "Lokys", "Šuo", "Zombis", "Varliažmogis", "Tamsusis elfas"]
possibleClasses = ["Kunigas", "Karys", "Vyskupas", "Lankininkas", "Riteris", "Burtininkas", "Magas", "Dainininkas", "Gydytojas"]
possibleSpecials = ["Ugnies valdymas", "Labai gražios akys", "Labai laimingas", "Gerai gamina maistą"]


f = open("Klasės.csv", "w")


for i in range(generateAmount):
    name = choice(possibleNames)
    race = choice(possibleRaces)
    _class = choice(possibleClasses)
    special = choice(possibleSpecials)

    lifePoints = randrange(10, 100)
    manaPoints = randrange(0, 100)
    atkPoints = randrange(5, 100)
    defPoints = randrange(5, 100)

    strPoints = randrange(0, 10)
    speedPoints = randrange(0, 10)
    intPoints = randrange(0, 10)

    line = f"{name};{race};{_class};{lifePoints};{manaPoints};{atkPoints};{defPoints};{strPoints};{speedPoints};{intPoints};{special}\n"
    print(line)
    f.write(line)

f.close()