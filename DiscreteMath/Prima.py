input = open('input.txt').readlines() #input.txt - матрица весов графа
weightMatrix = [[int(j) for j in i.split()] for i in input]
visited = [1]
sum = 0

while (len(visited) != len(weightMatrix)):
    minEdge = 0
    index = -1
    for i in visited:
        k = i - 1
        for j in range(len(weightMatrix)):
            if (not j+1 in visited) and weightMatrix[k][j] != 0 and (weightMatrix[k][j] < minEdge or minEdge == 0):
                minEdge = weightMatrix[k][j]
                index = j+1
    visited.append(index)
    sum += minEdge

print(sum)