from constraint import *

numbers = [int(string) for string in open("input","r").read().splitlines()]
tuples = [] # built tuples of two consecutives depth
for i in range(1, len(numbers)):
    tuples.append((numbers[i-1], numbers[i]))

problem = Problem()
problem.addVariable("a", tuples)
problem.addConstraint(lambda a: a[0] < a[1], ("a"))
solutions = problem.getSolutions()
print(len(solutions))