from constraint import *

numbers = [int(string) for string in open("input","r").read().splitlines()]

def part1():
    tuples = [] # built tuples of two consecutives depth
    for i in range(1, len(numbers)):
        tuples.append((numbers[i-1], numbers[i]))

    problem = Problem()
    problem.addVariable("a", tuples)
    problem.addConstraint(lambda a: a[0] < a[1], ("a"))
    solutions = problem.getSolutions()
    print(len(solutions))


def part2():
    ranges = [] # built range tuples of three consecutives depth
    for i in range(2, len(numbers)):
        ranges.append((numbers[i-2], numbers[i-1], numbers[i]))
    tuples = [] # built tuples of two consecutives range tuples
    for i in range(1, len(ranges)):
        tuples.append((ranges[i-1], ranges[i]))

    problem = Problem()
    problem.addVariable("a", tuples)
    problem.addConstraint(lambda a: a[0][0] + a[0][1] + a[0][2] < a[1][0] + a[1][1] + a[1][2], ("a"))
    solutions = problem.getSolutions()
    print(len(solutions))


part1()
part2()