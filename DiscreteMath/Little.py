import numpy as np

def reduce_row(matrix, summ):
    min_row = []
    for i in range(len(matrix)):
        if matrix[i].count(np.inf) == 6: 
            min_row.append(0)
            continue
        min_row.append(min(matrix[i]))

    summ += sum(min_row)
    matrix = [[matrix[i][j] - min_row[i] for j in range(len(matrix))] for i in range(len(matrix))]
    return (matrix, summ)

def reduce_col(matrix, summ):
    min_col = []
    for i in range(len(matrix)):
        cur_col = [row[i] for row in matrix]
        if cur_col.count(np.inf) == 6: 
            min_col.append(0)
            continue
        min_col.append(min(cur_col))

    summ += sum(min_col)
    matrix = [[matrix[i][j] - min_col[j] for j in range(len(matrix))] for i in range(len(matrix))]
    return (matrix, summ)

def max_zero(matrix, path, visited):
    max_elem = [-1, -1, -1]
    for i in range(len(matrix)):
        for j in range(len(matrix)):
            if matrix[i][j] != 0:
                continue

            cur_row = [k for k in matrix[i]]
            cur_row[j] = np.inf
            cur_row = [k for k in cur_row if k != np.inf]

            cur_col = [row[j] for row in matrix]
            cur_col[i] = np.inf
            cur_col = [k for k in cur_col if k != np.inf]

            max_value = min(cur_row) + min(cur_col)
            if max_elem[0] == -1 or max_elem[2] < max_value:
                max_elem = [i, j, max_value]

    for i in range(len(matrix)):
        for j in range(len(matrix)):
            if i == max_elem[0] or j == max_elem[1]:
                matrix[i][j] = np.inf

    if max_elem[0] in visited and max_elem[1] in visited:
        first = -1
        second = -1
        for i in range(len(path)):
            if max_elem[0] in path[i]: first = i
            if max_elem[1] in path[i]: second = i
        first_index = path[first].index(max_elem[0])
        if first != second:
            if first_index == 0:  path[first] = path[second] + path[first]
            else: path[first] = path[first] + path[second]
        matrix[path[first][-1]][path[first][0]] = np.inf
        path.pop(second)
    elif not(max_elem[0] in visited) and not(max_elem[1] in visited):
        path.append([max_elem[0], max_elem[1]])
        matrix[max_elem[1]][max_elem[0]] = np.inf
        visited.add(max_elem[0])
        visited.add(max_elem[1])
    else:
        first = -1
        second = -1
        for i in range(len(path)):
            if max_elem[0] in path[i]: first = i
            if max_elem[1] in path[i]: second = i
        if first == -1:
            index = path[second].index(max_elem[1])
            if index == 0: path[second].insert(0, max_elem[0])
            else: path[second].append(max_elem[0])
            matrix[path[second][-1]][path[second][0]] = np.inf
            visited.add(max_elem[0])
        if second == -1:
            index = path[first].index(max_elem[0])
            if index == 0: path[first].insert(0, max_elem[1])
            else: path[first].append(max_elem[1])
            matrix[path[first][-1]][path[first][0]] = np.inf
            visited.add(max_elem[1])

    return (matrix, path, visited)




inp = open("input.txt")
graph = [[j for j in i.split()] for i in inp]
distance = 0
path = []
visited = set()
for i in range(len(graph)):
    for j in range(len(graph)):
        if graph[i][j] != "i":
            graph[i][j] = int(graph[i][j])
        else:
            graph[i][j] = np.inf

for i in range(len(graph)-2):
    graph, distance = reduce_row(graph, distance)
    graph, distance = reduce_col(graph, distance)
    graph, path, visited = max_zero(graph, path, visited)

graph, distance = reduce_row(graph, distance)
graph, distance = reduce_col(graph, distance)
for i in range(len(graph)):
    for j in range(len(graph)):
        if graph[i][j] != 0:
            continue
        if i in visited: path[0].append(j)
        if j in visited: path[0].insert(0, i)

print("Кратчайший эйлеров цикл:")
for i in range(len(path[0])):
    if i != len(path[0]) - 1:
        print(path[0][i]+1, end = " -> ")
    else:
        print(path[0][i]+1)
print("Длина", distance)