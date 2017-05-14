## DailyProgrammer Challenge #311: Jolly Jumper
## reddit.com/r/dailyprogrammer/comments/65vgkh
## Objective:  Write a program to determine whether
##      each of a number of sequences is a "jolly jumper."
## Details:  A sequence of n > 0 integers is called a jolly
##      jumper if the absolute values of the differences
##      between successive elements take on all possible
##      values through n - 1.
## Author: Seth Creason
## Date: 5.14.2017

import collections
compare = lambda x, y: collections.Counter(x) == collections.Counter(y)

def checkAbs(mylist):
    stepper = 0
    vals = [None] * (len(mylist) - 2)
    while (stepper < len(vals)):
        vals[stepper] = abs(mylist[stepper + 1] - mylist[stepper + 2])
        stepper = stepper + 1

    counter = 0
    master = [None] * (len(mylist) - 1)
    while (counter < mylist[0]):
        master[counter] = abs(mylist[0] - (counter + 1))
        counter = counter + 1
        
    if (compare(vals[0:], master[:(len(master) - 1)])):
        print (*mylist, " JOLLY")
    else:
        print(*mylist, "NOT JOLLY")

checkAbs([4, 2, -1, 0, 2])
checkAbs([8, 1, 6, -1, 8, 9, 5, 2, 7])
checkAbs([4, 1, 4, 2, 3])
checkAbs([5, 1, 4, 2, -1, 6])
checkAbs([4, 19, 22, 24, 21])
checkAbs([4, 19, 22, 24, 25])
checkAbs([4, 2, -1, 0, 2])
