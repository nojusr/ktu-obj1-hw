# a small python script to generate random data for this project

from random import randrange, choice
from datetime import datetime, timedelta

generateAmount = 100

possibleBreeds = ["Taksas", "Senbernaras", "Dalmantinas", "Buldogas", "Haskis", "Samoyenas", "Retriveris", "Vok. Aviganis"]
possibleNames = ["Reksas", "Megė", "Rikis", "Pifas", "Margis", "Burgas", "Pipiras", "Amsis"]

f = open("dogs.csv", "w")

#This function will return a random datetime between two datetime objects.
def random_date(start, end):
    delta = end - start
    int_delta = (delta.days * 24 * 60 * 60) + delta.seconds
    random_second = randrange(int_delta)
    return start + timedelta(seconds=random_second)

for i in range(generateAmount):
    ID = randrange(100, 999)
    name = choice(possibleNames)
    breed = choice(possibleBreeds)
    date = random_date(datetime.strptime("1/1/2008 1:00 PM", '%m/%d/%Y %I:%M %p'), datetime.strptime("1/1/2019 1:00 PM", '%m/%d/%Y %I:%M %p'))
    gender = choice(["Male", "Female"])
    timestr = date.strftime("%Y-%m-%d")
    line = f"{ID};{name};{breed};{timestr};{gender}\n"
    print(line)
    f.write(line)

f.close()