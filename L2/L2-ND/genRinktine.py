# a small python script to generate random data for this project

from random import randrange, choice
import random
from datetime import datetime, timedelta

generateAmount = 100

possibleNames = ["Antanas", "Vardėnis", "Petras", "Aloyzas", "Juozas", "Motiejus"]
possibleSurnames = ["Pavardėnis", "Žukauskas", "Sabonis", "Jasikevičius", "Valančiūnas"]
possiblePositions = ["Attacker", "Defender", "Striker", "Sniper"]
possibleClubs = ["Šaulys", "Žalgiris", "L. Rytas", "Kruojos"]


f = open("tst-krepsininkai.csv", "w")


captainFound = False

for i in range(generateAmount):
    name = choice(possibleNames)
    surname = choice(possibleSurnames)

    age = randrange(18, 35)
    height = randrange(175, 210)

    position = choice(possiblePositions)

    club = choice(possibleClubs)

    invited = bool(random.getrandbits(1))
    captain = bool(random.getrandbits(1))

    if captain == True:
        if captainFound == False:
            invited = True
            captainFound = True
        else:
            captain = False
        

    line = f"{name};{surname};{age};{height};{position};{club};{invited};{captain}\n"
    print(line)
    f.write(line)

f.close()
